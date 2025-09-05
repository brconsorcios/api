using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace exp.core.WebService
{
    public class WebServicesSoap
    {
        public string WebServicesExecutar(string _soapEnvelope, string _url, string _action, string _content)
        {
            try
            {
                ///////////////////////////////////////////////////////////////////////////
                //string _content = System.IO.File.ReadAllText(_inputPath);

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
                if (soapResult.Length > 0) return soapResult;

                return string.Empty;
            }
            catch (WebException)
            {
                //Console.WriteLine("WebException raised!");
                //Console.WriteLine("\n{0}", e.Message);
                //Console.WriteLine("\n{0}", e.Status);
                //retorna vasio se houver qualquer erro
                return string.Empty;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception raised!");
                //Console.WriteLine("Source : " + e.Source);
                //Console.WriteLine("Message : " + e.Message);
                //retorna vasio se houver qualquer erro
                return string.Empty;
            }
        }


        public string
            WebServicesSoapAcao(string _soapEnvelope, string _url, string _action,
                string _content) //, string _outputPath)
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
                    // System.IO.File.WriteAllText(_outputPath, Resultado);
                    status = "sucesso";
                    XmlDaCunsulta = Resultado;
                }
                else
                {
                    status = "erro";
                }
            }
            catch (WebException)
            {
                //Console.WriteLine("WebException raised!");
                //Console.WriteLine("\n{0}", e.Message);
                //Console.WriteLine("\n{0}", e.Status);
                status = "erro";
            }
            catch (Exception)
            {
                //Console.WriteLine("Exception raised!");
                //Console.WriteLine("Source : " + e.Source);
                //Console.WriteLine("Message : " + e.Message);
                status = "erro";
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            //if (status != "sucesso")
            //{
            //    //Se o Soap não funcionaou adequadamente abre o XML da ultima consulta
            //    // O Objetivo é evitar erro na pagina
            //    if (System.IO.File.Exists(_outputPath))
            //    {
            //        XmlDaCunsulta = System.IO.File.ReadAllText(_outputPath);
            //    }

            //}

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
    }
}