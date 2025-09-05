using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace exp.core.WebService
{
    public class WebService
    {
        public string WebServicesExecutar(string _soapEnvelope, string _url, string _action, string _content)
        {
            try
            {
                var soapEnvelopeXml = CreateSoapEnvelope(_content, _soapEnvelope);
                var webRequest = CreateWebRequest(_url, _action);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
                // begin async call to web request.
                var asyncResult = webRequest.BeginGetResponse(null, null);
                // Suspender este segmento até chamada é completa. Você pode querer
                // fazer algo útil aqui como atualizar a interface do usuário.
                asyncResult.AsyncWaitHandle.WaitOne();

                // get the response from the completed web request.
                string soapResult;
                using (var webResponse = webRequest.EndGetResponse(asyncResult))
                using (var rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }

                //Salvando a ultima consulta bem sucedida
                //System.IO.File.WriteAllText(_outputPath, soapResult);
                if (soapResult.Length > 0)
                    return soapResult;
                return string.Empty;
            }
            catch (WebException)
            {
                //retorna vazio se houver qualquer erro
                return string.Empty;
            }
            catch (Exception)
            {
                //retorna vazio se houver qualquer erro
                return string.Empty;
            }
        }

        public string WebServicesSoapAcao(string _soapEnvelope, string _url, string _action, string _content,
            string _outputPath)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var status = string.Empty;
            var XmlDaCunsulta = string.Empty;

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////
                //Executando soap-------------------------------------------------------------------------------
                // WebServicesSoap _WebServicesSoap;
                // _WebServicesSoap = new WebServicesSoap();
                var Resultado = WebServicesExecutar(_soapEnvelope, _url, _action, _content);
                //----------------------------------------------------------------------------------------------
                ///////////////////////////////////////////////////////////////////////////////////////////////
                if (Resultado != "")
                {
                    // salvando ultima consulta bem sucedida
                    File.WriteAllText(_outputPath, Resultado);
                    status = "sucesso";
                    XmlDaCunsulta = Resultado;
                }
                else
                {
                    status = "erro";
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                status = "erro";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = "erro";
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            if (status != "sucesso")
                //Se o Soap não funcionaou adequadamente abre o XML da ultima consulta
                // O Objetivo é evitar erro na pagina
                if (File.Exists(_outputPath))
                    XmlDaCunsulta = File.ReadAllText(_outputPath);

            return XmlDaCunsulta;
        }

        private static XmlDocument CreateSoapEnvelope(string _content, string _soapEnvelope)
        {
            /*
            Rede.  Primeiro você precisa criar o envelope xml, esta função recebe uma string de
            dados XML como o conteúdo eo insere em um envelope sabão.  Basta abrir o seu serviço
            de web no IE, digitando a URL na barra de endereços para ver o que a estrutura
            do sabão: Corpo deve ser.
            */
            var sb = new StringBuilder(_soapEnvelope);
            sb.Insert(sb.ToString().IndexOf("</soap:Body>"), _content);

            // create an empty soap envelope
            var soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(sb.ToString());

            return soapEnvelopeXml;
        }


        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            /*
             Em seguida, você cria o objeto HttpWebRequest.  O url é a url do arquivo aspx
             e da ação é o seu espaço para além do método da web, por exemplo: ".
             Mikehadlow.com / víbora '.
            */
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (var stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }


        /// <summary>
        ///     Este método deverá ir em uma outra classe.
        ///     Deixei apenas para exemplo de como deve ser usado.
        ///     Copiado do projeto da TCGL na classe "SoapBuscaHorarios".
        /// </summary>
        /// <param name="_xml">XML que será enviado para o Web Service.</param>
        /// <returns>Retorna o resultado da consulta no Web Service.</returns>
        public string CriaXmlDaBuscaPorHorarios(string _xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(_xml);

            //if you want to save reply....
            //xmlDoc.Save(logfile);

            //Use namespace accordingly, this is an example
            var NMmanager = new XmlNamespaceManager(xmlDoc.NameTable);
            NMmanager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            //Montando o XML com o resultado do webservice
            var Resultado = string.Empty;

            //pega todo conteúdo do nó buscaLinhasResult
            if (xmlDoc.SelectSingleNode("//soap:Body/buscaHorariosResponse/buscaHorariosResult", NMmanager) == null)
                //Resultado += @"<?xml version='1.0'?>
                //<conteudoXml xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>";
                // Resultado += "<lista>";
                Resultado += xmlDoc.InnerText;
            //Resultado += "</lista>";
            //Resultado += "</conteudoXml>";
            return Resultado;
        }
    }
}