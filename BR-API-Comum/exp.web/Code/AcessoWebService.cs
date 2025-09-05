using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using exp.core;
using exp.core.Utilitarios;
using exp.core.WebService;
using exp.dados;

namespace exp.web.Code
{
    public class AcessoWebService
    {
        #region -- ENVELOPES --

        private static string Envelope(bool login)
        {
            var _soapEnvelope = string.Empty;

            if (login)
            {
                var TokenAtual = GerarToken();


                _soapEnvelope = @"<?xml version='1.0' encoding='utf-8'?>" +
                                "<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>" +
                                "<soap:Header>" +
                                "<TokenHeader xmlns='https://example.com/'>" +
                                "<Token>" + TokenAtual.token + "</Token>" +
                                "<ID_Usuario>" + TokenAtual.id_usuario + "</ID_Usuario>" +
                                "</TokenHeader>" +
                                "</soap:Header>" +
                                "<soap:Body>" +
                                "</soap:Body>" +
                                "</soap:Envelope>";
            }
            else
            {
                _soapEnvelope = @"<?xml version='1.0' encoding='utf-8'?>
                <soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
                  <soap:Body>
                  </soap:Body>
                </soap:Envelope>";
            }

            return _soapEnvelope;
        }

        #endregion


        #region -- Produtos Para Importacão --

        public static TokenModel GerarToken()
        {
            var Token = new TokenModel();

            var msg = string.Empty;

            #region -- Configurações --

            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "https://example.com/obterIdUsuario"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false); //, 

            _content = @"<obterIdUsuario xmlns='https://example.com/'>" +
                       "<CD_Usuario>" + SiteSettings.WsTokenUser + "</CD_Usuario>" +
                       "<Senha>" + SiteSettings.WsTokenPws + "</Senha>" +
                       "</obterIdUsuario>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            try
            {
                if (ResultadoSoap != "")
                {
                    Token.token = GetValueTagString(ResultadoSoap, "Token");
                    Token.id_usuario = GetValueTagString(ResultadoSoap, "ID_Usuario");

                    if (GetValueTagString(ResultadoSoap, "Return_Code") != "0")
                        if (GetValueTagString(ResultadoSoap, "ErrMsg") != null)
                            Token.ErroMensagem = GetValueTagString(ResultadoSoap, "Return_Code") + " - " +
                                                 GetValueTagString(ResultadoSoap, "ErrMsg");
                }
            }
            catch (Exception e)
            {
                Token.ErroMensagem = e.Message;
            }

            if (Token.ErroMensagem != null)
                try
                {
                    var SendSimple = new SendEmailBg();
                    SendSimple.To.Add(SiteSettings.EmailSuporte);
                    SendSimple.CC.Add(SiteSettings.EmailNotificacoes);
                    SendSimple.Subject = "*** Notificação: Autenticação do WebServices Falhou";
                    SendSimple.Body =
                        "<html><body><font color=\"#ff0000\" size=\"3\"><h1>Notificação:</h1><p>Houve um erro na tentativa de gerar o Token na integração. " +
                        Token.ErroMensagem + ". " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") +
                        "</p></font></body></html>";
                    SendSimple.StartEmailRun();
                }
                catch (Exception)
                {
                }


            return Token;
        }

        #endregion


        #region -- Identificação de Parceiro --

        public static TokenModel IdentificarParceiro(string CD_Usuario, string Senha)
        {
            var Token = new TokenModel();

            var msg = string.Empty;

            #region -- Configurações --

            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "https://example.com/obterIdUsuario"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false); //, 

            _content = @"<obterIdUsuario xmlns='https://example.com/'>" +
                       "<CD_Usuario>" + CD_Usuario + "</CD_Usuario>" +
                       "<Senha>" + Senha + "</Senha>" +
                       "</obterIdUsuario>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            try
            {
                if (ResultadoSoap != "")
                {
                    Token.token = GetValueTagString(ResultadoSoap, "Token");
                    Token.id_usuario = GetValueTagString(ResultadoSoap, "ID_Usuario");

                    if (GetValueTagString(ResultadoSoap, "Return_Code") != "0")
                        if (GetValueTagString(ResultadoSoap, "ErrMsg") != null)
                            //Token.ErroMensagem = GetValueTagString(ResultadoSoap, "Return_Code") + " - " + GetValueTagString(ResultadoSoap, "ErrMsg");
                            Token.ErroMensagem = GetValueTagString(ResultadoSoap, "ErrMsg");
                }
            }
            catch (Exception e)
            {
                Token.ErroMensagem = e.Message;
            }

            if (Token.ErroMensagem != null)
                try
                {
                    var SendSimple = new SendEmailBg();
                    SendSimple.To.Add(SiteSettings.EmailSuporte);
                    SendSimple.CC.Add(SiteSettings.EmailNotificacoes);
                    SendSimple.Subject = "*** Notificação: Autenticação do Parceiro (" + CD_Usuario + ") Falhou";
                    SendSimple.Body =
                        "<html><body><font color=\"#ff0000\" size=\"3\"><h1>Notificação:</h1><p>Houve um erro na tentativa de identificar o parceiro (" +
                        CD_Usuario + ") na integração. " + Token.ErroMensagem + ". " +
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "</p></font></body></html>";
                    SendSimple.StartEmailRun();
                }
                catch (Exception)
                {
                }


            return Token;
        }

        #endregion

        public static string GetValueTagString(string xml, string tagName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            var xmlNodeList = xmlDocument.GetElementsByTagName(tagName);

            var resp = "";

            if (xmlNodeList.Count > 0) resp = xmlNodeList[0].InnerText;

            return resp;
        }


        #region -- Taxa dos Planos --

        public static viewtaxas ProdutosTaxas(int id_plano_venda, int id_taxa_plano, int id_bem, int Regiao_Fiscal)
        {
            var path = string.Empty;
            var msg = string.Empty;
            var dataLog = DateTime.Now.ToString("dd-MM-yyyy");

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            //string _url = SiteSettings.WsUrlVendaExterna;

            var _action = "https://example.com/DetalhesPlanos"; // Acão do WebService que queremos consultar
            var _outputPath =
                @"" + folder + "DetalhesPlanosResult.xml"; //Path onde irá ser salvo o XML da ultima consulta

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            var _content = @"<DetalhesPlanos xmlns='https://example.com/'>" +
                           "<ID_Plano_Venda>" + id_plano_venda + "</ID_Plano_Venda>" +
                           "<ID_Taxa_Plano>" + id_taxa_plano + "</ID_Taxa_Plano>" +
                           "<ID_Bem>" + id_bem + "</ID_Bem>" +
                           "<ID_Empresa>108</ID_Empresa>" +
                           "<ID_Ponto_Venda>0</ID_Ponto_Venda>" +
                           "<ID_Regiao_Fiscal>" + Regiao_Fiscal + "</ID_Regiao_Fiscal>" +
                           "</DetalhesPlanos>";

            //      <ID_Plano_Venda>int</ID_Plano_Venda>
            //<ID_Taxa_Plano>int</ID_Taxa_Plano>
            //<ID_Bem>int</ID_Bem>
            //<ID_Empresa>int</ID_Empresa>
            //<ID_Ponto_Venda>int</ID_Ponto_Venda>
            //<ID_Regiao_Fiscal>int</ID_Regiao_Fiscal>

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var DetalhePlano = new viewtaxas();

            //#region ===== LOG 1 =====

            //path = @"content/[" + dataLog + "]-PRODUTOSTAXAS_LOG_1.txt";
            //msg = "=========== [XML] ===========\r\n";
            //msg += "[XML]: " + ResultadoSoap;

            //Logs.Save(path, msg);

            //#endregion

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("DetalhesPlanosResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    DetalhePlano.VL_Bem =
                        Convert.ToDecimal(item["VL_Bem"].InnerText.Replace(",", "").Replace(".", ","));
                    DetalhePlano.VL_TA_Inscricao =
                        Convert.ToDecimal(item["VL_TA_Inscricao"].InnerText.Replace(",", "").Replace(".", ","));
                    DetalhePlano.Faixa_Valores = item["Faixa_Valores"].InnerText;
                    DetalhePlano.PE_FC = item["PE_FC"].InnerText;
                    DetalhePlano.Faixa_PE_FC = item["Faixa_PE_FC"].InnerText;
                    DetalhePlano.PE_TA_Inscricao = item["PE_TA_Inscricao"].InnerText;
                    DetalhePlano.Faixa_TA = item["Faixa_TA"].InnerText;
                    DetalhePlano.PE_TA_Plano = item["PE_TA_Plano"].InnerText;
                    DetalhePlano.PE_FR_Plano = item["PE_FR_Plano"].InnerText;
                    DetalhePlano.PE_SG = item["PE_SG"].InnerText;
                    DetalhePlano.PE_TA = item["PE_TA"].InnerText;
                    DetalhePlano.VL_Parcela_F =
                        Convert.ToDecimal(item["VL_Parcela_F"].InnerText.Replace(",", "").Replace(".", ","));
                    DetalhePlano.VL_Parcela_J =
                        Convert.ToDecimal(item["VL_Parcela_J"].InnerText.Replace(",", "").Replace(".", ","));
                    DetalhePlano.CD_Plano_Venda = item["CD_Plano_Venda"].InnerText;
                    DetalhePlano.NM_Plano_Venda = item["NM_Plano_Venda"].InnerText;
                    DetalhePlano.NO_Parcela_Inicial = item["NO_Parcela_Inicial"].InnerText;
                    DetalhePlano.NO_Parcela_Final = item["NO_Parcela_Final"].InnerText;
                    DetalhePlano.PZ_Comercializacao = item["PZ_Comercializacao"].InnerText;
                    DetalhePlano.QT_Participante = item["QT_Participante"].InnerText;
                    DetalhePlano.NM_Bem = item["NM_Bem"].InnerText;
                    DetalhePlano.NM_Fabricante = item["NM_Fabricante"].InnerText;


                    //if (item["VL_Bem"].InnerText != "0")
                    //{
                    //    DetalhePlano.ErrMsg = item["ErrMsg"].InnerText;
                    //}
                }
            }

            return DetalhePlano;
        }

        #endregion


        #region -- BuscarPessoaFisica --

        public static PessoaFisicaModel BuscarPessoaFisica(string documento)
        {
            var path = string.Empty;
            var msg = string.Empty;
            var dataLog = DateTime.Now.ToString("dd-MM-yyyy");

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/PessoaFisica"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "DetalhesPlanosResult.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<PessoaFisica xmlns='https://example.com/'>" +
                       "<CD_Inscricao_Nacional>" + documento + "</CD_Inscricao_Nacional>" +
                       "</PessoaFisica>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var PessoaFisica = new PessoaFisicaModel();

            #region ===== LOG 1 =====

            //path = @"content/[" + dataLog + "]-WS_PF_LOG_1.txt";
            //msg = "=========== [XML] ===========\r\n";
            //msg += "[XML]: " + ResultadoSoap;

            //Logs.Save(path, msg);

            #endregion

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("PessoaFisicaResult");

                foreach (XmlNode item in xmlNodeList)
                    if (item["ID_Pessoa"].InnerText != "0")
                    {
                        PessoaFisica.ID_Pessoa = item["ID_Pessoa"].InnerText;
                        PessoaFisica.ID_Pessoa_Conjuge = item["ID_Pessoa_Conjuge"].InnerText;
                        PessoaFisica.SN_Politicamente_Exposto = item["SN_Politicamente_Exposto"].InnerText;
                        PessoaFisica.NM_Pessoa = item["NM_Pessoa"].InnerText;
                        PessoaFisica.CD_Inscricao_Nacional = item["CD_Inscricao_Nacional"].InnerText;
                        PessoaFisica.NO_Documento = item["NO_Documento"].InnerText;
                        PessoaFisica.ID_Tipo_Documento = item["ID_Tipo_Documento"].InnerText;
                        PessoaFisica.DT_Expedicao = item["DT_Expedicao"].InnerText;
                        PessoaFisica.NM_Orgao_Emissor = item["NM_Orgao_Emissor"].InnerText;
                        PessoaFisica.DT_Nascimento = item["DT_Nascimento"].InnerText;
                        PessoaFisica.ST_Sexo = item["ST_Sexo"].InnerText;
                        PessoaFisica.ID_Estado_Civil = item["ID_Estado_Civil"].InnerText;
                        PessoaFisica.NM_Nacionalidade = item["NM_Nacionalidade"].InnerText;
                        PessoaFisica.Naturalidade = item["Naturalidade"].InnerText;
                        PessoaFisica.ID_Profissao = item["ID_Profissao"].InnerText;
                        PessoaFisica.VL_Renda = item["VL_Renda"].InnerText;
                        PessoaFisica.ID_Regime_Casamento = item["ID_Regime_Casamento"].InnerText;
                        PessoaFisica.DT_Casamento = item["DT_Casamento"].InnerText;
                        PessoaFisica.ID_Naturalidade_Pais = item["ID_Naturalidade_Pais"]?.InnerText;
                        PessoaFisica.ID_UF_Naturalidade = item["ID_UF_Naturalidade"]?.InnerText;
                        PessoaFisica.Return_Code = item["Return_Code"].InnerText;
                        if (item["Return_Code"].InnerText != "0") PessoaFisica.ErrMsg = item["ErrMsg"].InnerText;
                    }
            }

            return PessoaFisica;
        }

        #endregion


        #region -- BuscarPessoaJuridica --

        public static PessoaJuridicaModel BuscarPessoaJuridica(string documento)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/PessoaJuridica"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "DetalhesPlanosResult.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<PessoaJuridica xmlns='https://example.com/'>" +
                       "<CD_Inscricao_Nacional>" + documento + "</CD_Inscricao_Nacional>" +
                       "</PessoaJuridica>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var PessoaJuridica = new PessoaJuridicaModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("PessoaJuridicaResult");


                foreach (XmlNode item in xmlNodeList)
                {
                    PessoaJuridica.ID_Pessoa = item["ID_Pessoa"].InnerText;

                    if (item["SN_Politicamente_Exposto"] != null)
                        PessoaJuridica.SN_Politicamente_Exposto = item["SN_Politicamente_Exposto"].InnerText;
                    else PessoaJuridica.SN_Politicamente_Exposto = "N";

                    if (item["NM_Razao_Social"] != null)
                        PessoaJuridica.NM_Razao_Social = item["NM_Razao_Social"].InnerText;
                    else PessoaJuridica.NM_Razao_Social = string.Empty;

                    if (item["CD_Inscricao_Nacional"] != null)
                        PessoaJuridica.CD_Inscricao_Nacional = item["CD_Inscricao_Nacional"].InnerText;
                    else PessoaJuridica.CD_Inscricao_Nacional = string.Empty;

                    if (item["NM_Fantasia"] != null)
                        PessoaJuridica.NM_Fantasia = item["NM_Fantasia"].InnerText;
                    else PessoaJuridica.NM_Fantasia = string.Empty;

                    if (item["DT_Fundacao"] != null)
                        PessoaJuridica.DT_Fundacao = item["DT_Fundacao"].InnerText;
                    else PessoaJuridica.DT_Fundacao = string.Empty;

                    if (item["VL_Capital_Social"] != null)
                        PessoaJuridica.VL_Capital_Social = item["VL_Capital_Social"].InnerText;
                    else PessoaJuridica.VL_Capital_Social = string.Empty;

                    if (item["Observacao"] != null)
                        PessoaJuridica.Observacao = item["Observacao"].InnerText;
                    else PessoaJuridica.Observacao = string.Empty;

                    if (item["VL_Faturamento_Medio"] != null)
                        PessoaJuridica.VL_Faturamento_Medio = item["VL_Faturamento_Medio"].InnerText;
                    else PessoaJuridica.VL_Faturamento_Medio = string.Empty;

                    if (item["NO_Documento"] != null)
                        PessoaJuridica.NO_Documento = item["NO_Documento"].InnerText;
                    else PessoaJuridica.NO_Documento = string.Empty;

                    if (item["ID_Tipo_Documento"] != null)
                        PessoaJuridica.ID_Tipo_Documento = item["ID_Tipo_Documento"].InnerText;
                    else PessoaJuridica.ID_Tipo_Documento = string.Empty;

                    if (item["ID_Pessoa_Socio"] != null)
                        PessoaJuridica.ID_Pessoa_Socio = item["ID_Pessoa_Socio"].InnerText;
                    else PessoaJuridica.ID_Pessoa_Socio = string.Empty;

                    if (item["Cargo_Socio"] != null)
                        PessoaJuridica.Cargo_Socio = item["Cargo_Socio"].InnerText;
                    else PessoaJuridica.Cargo_Socio = string.Empty;

                    if (item["PE_Participacao_Socio"] != null)
                        PessoaJuridica.PE_Participacao_Socio = item["PE_Participacao_Socio"].InnerText;
                    else PessoaJuridica.PE_Participacao_Socio = string.Empty;

                    if (item["Return_Code"] != null)
                        PessoaJuridica.Return_Code = item["Return_Code"].InnerText;
                    else PessoaJuridica.Return_Code = string.Empty;


                    if (item["Return_Code"].InnerText != "0") PessoaJuridica.ErrMsg = item["ErrMsg"].InnerText;
                }
            }

            return PessoaJuridica;
        }

        #endregion


        #region -- BuscarPessoaEmail --

        public static PessoaEmailModel BuscarPessoaEmail(string id_pessoa)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/EmailPessoal"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "EmailPessoal.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<EmailPessoal xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + id_pessoa + "</ID_Pessoa>" +
                       "</EmailPessoal>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PessoaEmail = new PessoaEmailModel();


            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("EmailPessoalResult");


                foreach (XmlNode item in xmlNodeList)
                    if (item["ID_Pessoa"].InnerText == id_pessoa)
                    {
                        PessoaEmail.ID_Pessoa = item["ID_Pessoa"].InnerText;
                        PessoaEmail.ID_E_Mail = item["ID_E_Mail"].InnerText;
                        PessoaEmail.E_Mail = item["E_Mail"].InnerText;
                        PessoaEmail.NO_Sequencia = item["NO_Sequencia"].InnerText;
                        PessoaEmail.Return_Code = item["Return_Code"].InnerText;
                        if (item["Return_Code"].InnerText != "0") PessoaEmail.ErrMsg = item["ErrMsg"].InnerText;
                    }
            }

            return PessoaEmail;
        }

        #endregion

        #region -- ManutencaoPessoaEmail --

        public static PessoaEmailModel ManutencaoPessoaEmail(PessoaEmailModel email)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/prcEmailPessoaAddUpd"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "prcEmailPessoaAddUpd.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<prcEmailPessoaAddUpd xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + email.ID_Pessoa + "</ID_Pessoa>" +
                       "<ID_E_Mail>" + email.ID_E_Mail + "</ID_E_Mail>" +
                       "<E_Mail>" + email.E_Mail + "</E_Mail>" +
                       "</prcEmailPessoaAddUpd>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PessoaEmail = new PessoaEmailModel();


            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcEmailPessoaAddUpdResult");


                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"].InnerText != "0")
                    {
                        PessoaEmail.ErrMsg = item["ErrMsg"].InnerText;
                        PessoaEmail.Return_Code = item["Return_Code"].InnerText;
                    }


                    PessoaEmail.ID_E_Mail = item["ID_E_Mail"].InnerText;
                }
            }

            return PessoaEmail;
        }

        #endregion

        #region -- BuscarPessoaTelefone --

        public static PessoaTelefoneModel BuscarPessoaTelefone(string id_pessoa)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/Telefone"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "Telefone.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<Telefone xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + id_pessoa + "</ID_Pessoa>" +
                       "</Telefone>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PessoaTelefone = new PessoaTelefoneModel();


            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("TelefoneResult");


                foreach (XmlNode item in xmlNodeList)
                    if (item["ID_Pessoa"].InnerText == id_pessoa)
                    {
                        PessoaTelefone.ID_Pessoa = item["ID_Pessoa"].InnerText;
                        PessoaTelefone.ID_Telefone = item["ID_Telefone"].InnerText;
                        PessoaTelefone.ID_Cidade = item["ID_Cidade"].InnerText;
                        PessoaTelefone.ID_UF = item["ID_UF"].InnerText;
                        PessoaTelefone.ID_Tipo_Telefone = item["ID_Tipo_Telefone"].InnerText;
                        PessoaTelefone.Telefone = item["Telefone"].InnerText;
                        PessoaTelefone.NO_Sequencia = item["NO_Sequencia"].InnerText;
                        PessoaTelefone.Return_Code = item["Return_Code"].InnerText;

                        if (item["Return_Code"].InnerText != "0") PessoaTelefone.ErrMsg = item["ErrMsg"].InnerText;
                    }
            }

            return PessoaTelefone;
        }

        #endregion

        #region -- ManutençãoPessoaTelefone --

        public static PessoaTelefoneModel ManutencaoPessoaTelefone(PessoaTelefoneModel telefone)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/prcTelefonePessoaAddUpd"; // Acão do WebService que queremos consultar
            _outputPath =
                @"" + folder + "prcTelefonePessoaAddUpd.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<prcTelefonePessoaAddUpd xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + telefone.ID_Pessoa + "</ID_Pessoa>" +
                       "<ID_Telefone>" + telefone.ID_Telefone + "</ID_Telefone>" +
                       "<ID_Cidade>" + telefone.ID_Cidade + "</ID_Cidade>" +
                       "<ID_Tipo_Telefone>" + telefone.ID_Tipo_Telefone + "</ID_Tipo_Telefone>" +
                       "<Telefone>" + telefone.Telefone + "</Telefone>" +
                       "</prcTelefonePessoaAddUpd>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PessoaTelefone = new PessoaTelefoneModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcTelefonePessoaAddUpdResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"].InnerText != "0")
                    {
                        PessoaTelefone.ErrMsg = item["ErrMsg"].InnerText;
                        PessoaTelefone.Return_Code = item["Return_Code"].InnerText;
                    }


                    PessoaTelefone.ID_Telefone = item["ID_Telefone"].InnerText;
                }
            }

            return PessoaTelefone;
        }

        #endregion

        #region -- BuscarPessoaEndereco --

        public static PessoaEnderecoModel BuscarPessoaEndereco(string id_pessoa)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/Endereco"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "DetalhesPlanosResult.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<Endereco xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + id_pessoa + "</ID_Pessoa>" +
                       "</Endereco>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PessoaEndereco = new PessoaEnderecoModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("EnderecoResult");

                foreach (XmlNode item in xmlNodeList)
                    if (item["ID_Pessoa"].InnerText == id_pessoa)
                    {
                        PessoaEndereco.ID_Pessoa = item["ID_Pessoa"].InnerText;

                        PessoaEndereco.ID_Endereco = item["ID_Endereco"].InnerText;
                        PessoaEndereco.ID_Cidade = item["ID_Cidade"].InnerText;
                        PessoaEndereco.ID_Tipo_Endereco = item["ID_Tipo_Endereco"].InnerText;
                        PessoaEndereco.NM_Tipo_Endereco = item["NM_Tipo_Endereco"].InnerText;
                        PessoaEndereco.NM_Cidade = item["NM_Cidade"].InnerText;
                        PessoaEndereco.ID_UF = item["ID_UF"].InnerText;
                        PessoaEndereco.CEP = item["CEP"].InnerText;
                        PessoaEndereco.Endereco = item["Endereco"].InnerText;
                        PessoaEndereco.NO_Endereco = item["NO_Endereco"].InnerText;
                        PessoaEndereco.Complemento = item["Complemento"].InnerText;
                        PessoaEndereco.Bairro = item["Bairro"].InnerText;
                        PessoaEndereco.Caixa_Postal = item["Caixa_Postal"].InnerText;
                        //PessoaEndereco.DS_Referencia_Endereco = item["DS_Referencia_Endereco"].InnerText;
                        PessoaEndereco.NO_Sequencia = item["NO_Sequencia"].InnerText;
                        PessoaEndereco.Return_Code = item["Return_Code"].InnerText;

                        if (item["Return_Code"].InnerText != "0") PessoaEndereco.ErrMsg = item["ErrMsg"].InnerText;
                    }
            }

            return PessoaEndereco;
        }

        #endregion


        #region -- ManutencaoPessoaEndereco --

        public static PessoaEnderecoModel ManutencaoPessoaEndereco(PessoaEnderecoModel endereco)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/prcEnderecoPessoaAddUpd"; // Acão do WebService que queremos consultar
            _outputPath =
                @"" + folder + "prcEnderecoPessoaAddUpd.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<prcEnderecoPessoaAddUpd xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + endereco.ID_Pessoa + "</ID_Pessoa>" +
                       "<ID_Endereco>" + endereco.ID_Endereco + "</ID_Endereco>" +
                       "<ID_Cidade>" + endereco.ID_Cidade + "</ID_Cidade>" +
                       "<ID_Tipo_Endereco>" + endereco.ID_Tipo_Endereco + "</ID_Tipo_Endereco>" +
                       "<ID_UF>" + endereco.ID_UF + "</ID_UF>" +
                       "<CEP>" + endereco.CEP + "</CEP>" +
                       "<Endereco>" + endereco.Endereco + "</Endereco>" +
                       "<NO_Endereco>" + endereco.NO_Endereco + "</NO_Endereco>" +
                       "<Complemento>" + endereco.Complemento + "</Complemento>" +
                       "<Bairro>" + endereco.Bairro + "</Bairro>" +
                       "<Caixa_Postal>" + endereco.Caixa_Postal + "</Caixa_Postal>" +
                       "<DS_Referencia_Endereco>" + endereco.DS_Referencia_Endereco + "</DS_Referencia_Endereco>" +
                       "</prcEnderecoPessoaAddUpd>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PessoaEndereco = new PessoaEnderecoModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcEnderecoPessoaAddUpdResult");


                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"].InnerText != "0")
                    {
                        PessoaEndereco.ErrMsg = item["ErrMsg"].InnerText;
                        PessoaEndereco.Return_Code = item["Return_Code"].InnerText;
                    }


                    PessoaEndereco.ID_Endereco = item["ID_Endereco"].InnerText;
                }
            }

            return PessoaEndereco;
        }

        #endregion

        
        #region -- Adicionar Proposta --

        public static PropostaRetornoModel AdicionarNovaProposta(PropostaModel Proposta)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/prcPropostaAdd"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "prcPropostaAdd.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<prcPropostaAdd xmlns='https://example.com/'>" +
                       " <ID_Identificador>" + Proposta.ID_Identificador + "</ID_Identificador>" +
                       " <ID_Pessoa>" + Proposta.ID_Pessoa + "</ID_Pessoa>" +
                       " <ID_Endereco>" + Proposta.ID_Endereco + "</ID_Endereco>" +
                       " <ID_Telefone>" + Proposta.ID_Telefone + "</ID_Telefone>" +
                       " <ID_Fax>" + Proposta.ID_Fax + "</ID_Fax>" +
                       " <ID_E_Mail>" + Proposta.ID_E_Mail + "</ID_E_Mail>" +
                       " <ID_Conta_Bancaria>" + Proposta.ID_Conta_Bancaria + "</ID_Conta_Bancaria>" +
                       " <Dia_Debito>" + Proposta.Dia_Debito + "</Dia_Debito>" +
                       " <SN_Dia_Util_Debito>" + Proposta.SN_Dia_Util_Debito + "</SN_Dia_Util_Debito>" +
                       " <ST_Grupo>" + Proposta.ST_Grupo + "</ST_Grupo>" +
                       " <ID_Produto>" + Proposta.ID_Produto + "</ID_Produto>" +
                       " <ID_Ponto_Venda>" + Proposta.ID_Ponto_Venda + "</ID_Ponto_Venda>" +
                       " <ID_Plano_Venda>" + Proposta.ID_Plano_Venda + "</ID_Plano_Venda>" +
                       " <ID_Taxa_Plano>" + Proposta.ID_Taxa_Plano + "</ID_Taxa_Plano>" +
                       " <PZ_Comercializacao>" + Proposta.PZ_Comercializacao + "</PZ_Comercializacao>" +
                       " <ID_Tipo_Venda_Grupo>" + Proposta.ID_Tipo_Venda_Grupo + "</ID_Tipo_Venda_Grupo>" +
                       " <ID_Bem>" + Proposta.ID_Bem + "</ID_Bem>" +
                       " <ID_Grupo>" + Proposta.ID_Grupo + "</ID_Grupo>" +
                       " <ST_Tipo_Venda>" + Proposta.ST_Tipo_Venda + "</ST_Tipo_Venda>" +
                       " <SN_Aprovada>" + Proposta.SN_Aprovada + "</SN_Aprovada>" +
                       " <ID_Comissionado>" + Proposta.ID_Comissionado + "</ID_Comissionado>" +
                       " <ID_Ponto_Entrega>" + Proposta.ID_Ponto_Entrega + "</ID_Ponto_Entrega>" +
                       " <ST_Tipo_Cliente>" + Proposta.ST_Tipo_Cliente + "</ST_Tipo_Cliente>" +
                       " <ST_Tipo_Agencia>" + Proposta.ST_Tipo_Agencia + "</ST_Tipo_Agencia>" +
                       " <CD_Agencia_Login>" + Proposta.CD_Agencia_Login + "</CD_Agencia_Login>" +
                       " <ID_Reserva>" + Proposta.ID_Reserva + "</ID_Reserva>" +
                       " <ID_CONPV007>" + Proposta.ID_CONPV007 + "</ID_CONPV007>" +
                       " <QT_Participante>" + Proposta.QT_Participante + "</QT_Participante>" +
                       " <ID_Forma_Recebimento>" + Proposta.ID_Forma_Recebimento + "</ID_Forma_Recebimento>" +
                       " <ID_Regiao_Fiscal>" + Proposta.ID_Regiao_Fiscal + "</ID_Regiao_Fiscal>" +
                       " <ID_Empresa>" + Proposta.ID_Empresa + "</ID_Empresa>";
            if (!string.IsNullOrEmpty(Proposta.CD_Unidade_Negocio_Parceiro))
                _content += " <CD_Unidade_Negocio_Parceiro>" + Proposta.CD_Unidade_Negocio_Parceiro +
                            "</CD_Unidade_Negocio_Parceiro>";
            _content += "</prcPropostaAdd>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PropostaRetorno = new PropostaRetornoModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcPropostaAddResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"].InnerText != "0")
                    {
                        PropostaRetorno.ErrMsg = item["ErrMsg"].InnerText;
                        PropostaRetorno.Msg = item["Msg"].InnerText;
                        PropostaRetorno.Return_Code = item["Return_Code"].InnerText;
                    }

                    PropostaRetorno.ID_Documento = item["ID_Documento"].InnerText;
                    PropostaRetorno.ID_Tipo_Documento = item["ID_Tipo_Documento"].InnerText;
                    PropostaRetorno.ID_Empresa = item["ID_Empresa"].InnerText;
                }
            }

            return PropostaRetorno;
        }

        #endregion


        #region -- Adicionar Proposta --

        //public static PropostaRetornoModel AdicionarProposta(PropostaModel Proposta)
        public static PropostaRetornoModel AdicionarProposta(PropostaModel Proposta, string CD_Usuario, string Senha)
        {
            var path = string.Empty;
            var msg = string.Empty;
            var envelope = string.Empty;
            var dataLog = DateTime.Now.ToString("dd-MM-yyyy");

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/prcPropostaAdd"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "prcPropostaAdd.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<prcPropostaAdd xmlns='https://example.com/'>" +
                       " <ID_Identificador>" + Proposta.ID_Identificador + "</ID_Identificador>" +
                       " <ID_Pessoa>" + Proposta.ID_Pessoa + "</ID_Pessoa>" +
                       " <ID_Endereco>" + Proposta.ID_Endereco + "</ID_Endereco>" +
                       " <ID_Telefone>" + Proposta.ID_Telefone + "</ID_Telefone>" +
                       " <ID_Fax>" + Proposta.ID_Fax + "</ID_Fax>" +
                       " <ID_E_Mail>" + Proposta.ID_E_Mail + "</ID_E_Mail>" +
                       " <ID_Conta_Bancaria>" + Proposta.ID_Conta_Bancaria + "</ID_Conta_Bancaria>" +
                       " <Dia_Debito>" + Proposta.Dia_Debito + "</Dia_Debito>" +
                       " <SN_Dia_Util_Debito>" + Proposta.SN_Dia_Util_Debito + "</SN_Dia_Util_Debito>" +
                       " <ST_Grupo>" + Proposta.ST_Grupo + "</ST_Grupo>" +
                       " <ID_Produto>" + Proposta.ID_Produto + "</ID_Produto>" +
                       " <ID_Ponto_Venda>" + Proposta.ID_Ponto_Venda + "</ID_Ponto_Venda>" +
                       " <ID_Plano_Venda>" + Proposta.ID_Plano_Venda + "</ID_Plano_Venda>" +
                       " <ID_Taxa_Plano>" + Proposta.ID_Taxa_Plano + "</ID_Taxa_Plano>" +
                       " <PZ_Comercializacao>" + Proposta.PZ_Comercializacao + "</PZ_Comercializacao>" +
                       " <ID_Tipo_Venda_Grupo>" + Proposta.ID_Tipo_Venda_Grupo + "</ID_Tipo_Venda_Grupo>" +
                       " <ID_Bem>" + Proposta.ID_Bem + "</ID_Bem>" +
                       " <ID_Grupo>" + Proposta.ID_Grupo + "</ID_Grupo>" +
                       " <ST_Tipo_Venda>" + Proposta.ST_Tipo_Venda + "</ST_Tipo_Venda>" +
                       " <ID_Condicao_Pagto>" + Proposta.ID_Condicao_Pagto + "</ID_Condicao_Pagto>" +
                       " <SN_Aprovada>" + Proposta.SN_Aprovada + "</SN_Aprovada>" +
                       " <ID_Comissionado>" + Proposta.ID_Comissionado + "</ID_Comissionado>" +
                       " <ID_Ponto_Entrega>" + Proposta.ID_Ponto_Entrega + "</ID_Ponto_Entrega>" +
                       " <ST_Tipo_Cliente>" + Proposta.ST_Tipo_Cliente + "</ST_Tipo_Cliente>" +
                       " <ST_Tipo_Agencia>" + Proposta.ST_Tipo_Agencia + "</ST_Tipo_Agencia>" +
                       " <CD_Agencia_Login>" + Proposta.CD_Agencia_Login + "</CD_Agencia_Login>" +
                       " <ID_Reserva>" + Proposta.ID_Reserva + "</ID_Reserva>" +
                       " <ID_CONPV007>" + Proposta.ID_CONPV007 + "</ID_CONPV007>" +
                       " <QT_Participante>" + Proposta.QT_Participante + "</QT_Participante>" +
                       " <ID_Forma_Recebimento>" + Proposta.ID_Forma_Recebimento + "</ID_Forma_Recebimento>" +
                       " <ID_Regiao_Fiscal>" + Proposta.ID_Regiao_Fiscal + "</ID_Regiao_Fiscal>" +
                       " <ID_Empresa>" + Proposta.ID_Empresa + "</ID_Empresa>";
            if (!string.IsNullOrEmpty(Proposta.CD_Unidade_Negocio_Parceiro))
                _content += " <CD_Unidade_Negocio_Parceiro>" + Proposta.CD_Unidade_Negocio_Parceiro +
                            "</CD_Unidade_Negocio_Parceiro>";
            _content += "</prcPropostaAdd>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            if (!string.IsNullOrEmpty(CD_Usuario) && !string.IsNullOrEmpty(CD_Usuario))
            {
                var TokenAtual = IdentificarParceiro(CD_Usuario, Senha);
                envelope = @"<?xml version='1.0' encoding='utf-8'?>" +
                           "<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>" +
                           "<soap:Header>" +
                           "<TokenHeader xmlns='https://example.com/'>" +
                           "<Token>" + TokenAtual.token + "</Token>" +
                           "<ID_Usuario>" + TokenAtual.id_usuario + "</ID_Usuario>" +
                           "</TokenHeader>" +
                           "</soap:Header>" +
                           "<soap:Body>" +
                           "</soap:Body>" +
                           "</soap:Envelope>";
            }
            else
            {
                envelope = Envelope(true);
            }

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var PropostaRetorno = new PropostaRetornoModel();

            #region ===== LOG 1 =====

            path = @"content/[" + dataLog + "]-WS_ADD-PROPOSTA_LOG_1.txt";
            msg = "=========== [XML] ===========\r\n";
            msg += "[XML]: " + ResultadoSoap;

            Logs.Save(path, msg);

            #endregion

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcPropostaAdd");

                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"] != null)
                    {
                        if (item["Return_Code"].InnerText != "0")
                        {
                            PropostaRetorno.ErrMsg = item["ErrMsg"].InnerText;
                            PropostaRetorno.Msg = item["Msg"].InnerText;
                        }
                        else
                        {
                            PropostaRetorno.ErrMsg = string.Empty;
                            PropostaRetorno.Msg = string.Empty;
                        }

                        PropostaRetorno.Return_Code = item["Return_Code"].InnerText;
                    }


                    PropostaRetorno.ID_Documento = item["ID_Documento"].InnerText;
                    PropostaRetorno.ID_Tipo_Documento = item["ID_Tipo_Documento"].InnerText;
                    PropostaRetorno.ID_Empresa = item["ID_Empresa"].InnerText;
                }
            }


            //     <stcPropostaAdd>
            //  <Msg>Numero do Contrato: 800000006</Msg>
            //  <Return_Code>0</Return_Code>
            //  <ID_Documento>800000006</ID_Documento>
            //  <ID_Tipo_Documento>32</ID_Tipo_Documento>
            //  <ID_Empresa>108</ID_Empresa>
            //</stcPropostaAdd>

            return PropostaRetorno;
        }

        #endregion


        #region -- Emissao boleto

        public static EmissaoBoletoRetornoModel EmitirBoleto(EmissaoBoletoModel boleto)
        {
            var path = string.Empty;
            var msg = string.Empty;
            var dataLog = DateTime.Now.ToString("dd-MM-yyyy");

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/EmissaoBoleto"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "prcPropostaAdd.xml"; //Path onde irá ser salvo o XML da ultima consulta
            //_content = @"<EmissaoBoleto xmlns='https://example.com/'>" +
            //            "<ID_Usuario>" + boleto.ID_Usuario + "</ID_Usuario>" +
            //            "<ID_Empresa>" + boleto.ID_Empresa + "</ID_Empresa>" +
            //            "<ID_Documento>" + boleto.ID_Documento + "</ID_Documento>" +
            //            "<ID_Ponto_Venda>" + boleto.ID_Ponto_Venda + "</ID_Ponto_Venda>" +
            //            "</EmissaoBoleto>";


            _content = @"<EmissaoBoleto xmlns='https://example.com/'>" +
                       "<ID_Empresa>" + boleto.ID_Empresa + "</ID_Empresa>" +
                       "<ID_Documento>" + boleto.ID_Documento + "</ID_Documento>" +
                       "<ID_Tipo_Documento>" + boleto.ID_Tipo_Documento + "</ID_Tipo_Documento>" +
                       "</EmissaoBoleto>";


            #region ===== LOG 1 =====

            path = @"content/[" + dataLog + "]-WS_LOG_1.txt";
            msg = "=========== [XML] ===========\r\n";
            msg += "[XML]: " + _content;

            Logs.Save(path, msg);

            #endregion

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var EmissaoBoletoRetorno = new EmissaoBoletoRetornoModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("EmissaoBoletoResult");

                #region ===== LOG 2 =====

                path = @"content/[" + dataLog + "]-WS_LOG_2.txt";
                msg = "=========== [XML_RETORNO] ===========\r\n";
                msg += "[XML_RETORNO]: " + ResultadoSoap;

                Logs.Save(path, msg);

                #endregion

                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"] != null)
                        if (item["Return_Code"].InnerText != "0")
                        {
                            EmissaoBoletoRetorno.ErrMsg = item["ErrMsg"].InnerText;
                            EmissaoBoletoRetorno.Return_Code = item["Return_Code"].InnerText;
                        }

                    EmissaoBoletoRetorno.NM_Local_Pagto = item["NM_Local_Pagto"].InnerText;
                    EmissaoBoletoRetorno.NM_Cedente = item["NM_Cedente"].InnerText;
                    EmissaoBoletoRetorno.DT_Documento = item["DT_Documento"].InnerText;
                    EmissaoBoletoRetorno.NO_Documento = item["NO_Documento"].InnerText;
                    EmissaoBoletoRetorno.Especie_Documento = item["Especie_Documento"].InnerText;
                    EmissaoBoletoRetorno.SN_Aceite = item["SN_Aceite"].InnerText;
                    EmissaoBoletoRetorno.DT_Processamento = item["DT_Processamento"].InnerText;
                    EmissaoBoletoRetorno.NO_Carteira_Impressa_Boleto = item["NO_Carteira_Impressa_Boleto"].InnerText;
                    EmissaoBoletoRetorno.Especie_Moeda = item["Especie_Moeda"].InnerText;
                    EmissaoBoletoRetorno.QT_Moeda = item["QT_Moeda"].InnerText;
                    EmissaoBoletoRetorno.VL_Moeda = item["VL_Moeda"].InnerText;
                    EmissaoBoletoRetorno.DT_Vencimento = item["DT_Vencimento"].InnerText;
                    EmissaoBoletoRetorno.Agencia_Cedente = item["Agencia_Cedente"].InnerText;
                    EmissaoBoletoRetorno.Nosso_Numero = item["Nosso_Numero"].InnerText;
                    EmissaoBoletoRetorno.VL_Documento = item["VL_Documento"].InnerText;
                    EmissaoBoletoRetorno.VL_Desconto = item["VL_Desconto"].InnerText;
                    EmissaoBoletoRetorno.VL_Outras_Deducoes = item["VL_Outras_Deducoes"].InnerText;
                    EmissaoBoletoRetorno.VL_Multa = item["VL_Multa"].InnerText;
                    EmissaoBoletoRetorno.VL_Outros_Acrescimos = item["VL_Outros_Acrescimos"].InnerText;
                    EmissaoBoletoRetorno.VL_Cobrado = item["VL_Cobrado"].InnerText;
                    EmissaoBoletoRetorno.Sacado = item["Sacado"].InnerText;
                    EmissaoBoletoRetorno.Linha_Digitavel = item["Linha_Digitavel"].InnerText;
                    EmissaoBoletoRetorno.CD_Barra = item["CD_Barra"].InnerText;
                    EmissaoBoletoRetorno.CD_Banco = item["CD_Banco"].InnerText;
                    EmissaoBoletoRetorno.Mensagem_Compensacao = item["Mensagem_Compensacao"].InnerText;
                    EmissaoBoletoRetorno.Mensagem_Recibo = item["Mensagem_Recibo"].InnerText;
                    EmissaoBoletoRetorno.NM_Banco_Reduzido = item["NM_Banco_Reduzido"].InnerText;
                    EmissaoBoletoRetorno.Uso_Banco = item["Uso_Banco"].InnerText;
                    EmissaoBoletoRetorno.CD_Baixa = item["CD_Baixa"].InnerText;
                    EmissaoBoletoRetorno.Endereco_Completo = item["Endereco_Completo"].InnerText;
                    EmissaoBoletoRetorno.CD_Inscricao_Nacional = item["CD_Inscricao_Nacional"].InnerText;
                }
            }

            return EmissaoBoletoRetorno;
        }

        #endregion


        #region -- Emissao boleto Atendimento segunda via

        public static EmissaoBoletoRetornoModel EmitirBoleto2Via(int id)
        {
            var path = string.Empty;
            var msg = string.Empty;
            var dataLog = DateTime.Now.ToString("dd-MM-yyyy");

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WebAtendimento; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/EmissaoBoleto"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "prcBoleto2via.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<EmissaoBoleto xmlns='https://example.com/'>" +
                       "<ID_Identificador>" + id + "</ID_Identificador>" +
                       "</EmissaoBoleto>";


            #region ===== LOG 1 =====

            path = @"content/[" + dataLog + "]-WSboleto2via_LOG_1.txt";
            msg = "=========== [XML] ===========\r\n";
            msg += "[XML]: " + _content;

            Logs.Save(path, msg);

            #endregion

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var EmissaoBoletoRetorno = new EmissaoBoletoRetornoModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("EmissaoBoletoResult");

                #region ===== LOG 2 =====

                path = @"content/[" + dataLog + "]-WSboleto2via_LOG_2.txt";
                msg = "=========== [XML_RETORNO] ===========\r\n";
                msg += "[XML_RETORNO]: " + ResultadoSoap;

                Logs.Save(path, msg);

                #endregion

                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["ErrMsg"] != null) EmissaoBoletoRetorno.ErrMsg = item["ErrMsg"].InnerText;

                    EmissaoBoletoRetorno.NM_Local_Pagto = item["NM_Local_Pagto"].InnerText;
                    EmissaoBoletoRetorno.NM_Cedente = item["NM_Cedente"].InnerText;
                    EmissaoBoletoRetorno.DT_Documento = item["DT_Documento"].InnerText;
                    EmissaoBoletoRetorno.NO_Documento = item["NO_Documento"].InnerText;
                    EmissaoBoletoRetorno.Especie_Documento = item["Especie_Documento"].InnerText;
                    EmissaoBoletoRetorno.SN_Aceite = item["SN_Aceite"].InnerText;
                    EmissaoBoletoRetorno.DT_Processamento = item["DT_Processamento"].InnerText;
                    EmissaoBoletoRetorno.NO_Carteira_Impressa_Boleto = item["NO_Carteira_Impressa_Boleto"].InnerText;
                    EmissaoBoletoRetorno.Especie_Moeda = item["Especie_Moeda"].InnerText;
                    EmissaoBoletoRetorno.QT_Moeda = item["QT_Moeda"].InnerText;
                    EmissaoBoletoRetorno.VL_Moeda = item["VL_Moeda"].InnerText;
                    EmissaoBoletoRetorno.DT_Vencimento = item["DT_Vencimento"].InnerText;
                    EmissaoBoletoRetorno.Agencia_Cedente = item["Agencia_Cedente"].InnerText;
                    EmissaoBoletoRetorno.Nosso_Numero = item["Nosso_Numero"].InnerText;
                    EmissaoBoletoRetorno.VL_Documento = item["VL_Documento"].InnerText;
                    EmissaoBoletoRetorno.VL_Desconto = item["VL_Desconto"].InnerText;
                    EmissaoBoletoRetorno.VL_Outras_Deducoes = item["VL_Outras_Deducoes"].InnerText;
                    EmissaoBoletoRetorno.VL_Multa = item["VL_Multa"].InnerText;
                    EmissaoBoletoRetorno.VL_Outros_Acrescimos = item["VL_Outros_Acrescimos"].InnerText;
                    EmissaoBoletoRetorno.VL_Cobrado = item["VL_Cobrado"].InnerText;
                    EmissaoBoletoRetorno.Sacado = item["Sacado"].InnerText;
                    EmissaoBoletoRetorno.Linha_Digitavel = item["Linha_Digitavel"].InnerText;
                    EmissaoBoletoRetorno.CD_Barra = item["CD_Barra"].InnerText;

                    EmissaoBoletoRetorno.Mensagem_Compensacao = item["Mensagem_Compensacao"].InnerText;
                    EmissaoBoletoRetorno.Mensagem_Recibo = item["Mensagem_Recibo"].InnerText;
                    EmissaoBoletoRetorno.NM_Banco_Reduzido = item["NM_Banco_Reduzido"].InnerText;
                    EmissaoBoletoRetorno.Uso_Banco = item["Uso_Banco"].InnerText;
                    EmissaoBoletoRetorno.CD_Baixa = item["CD_Baixa"].InnerText;


                    if (item["Endereco_Completo"] != null)
                        EmissaoBoletoRetorno.Endereco_Completo = item["Endereco_Completo"].InnerText;
                    if (item["NM_Sacado"] != null) EmissaoBoletoRetorno.NM_Sacado = item["NM_Sacado"].InnerText;
                    if (item["CD_Banco"] != null) EmissaoBoletoRetorno.CD_Banco = item["CD_Banco"].InnerText;
                    if (item["NM_Banco_Reduzido"] != null)
                    {
                        var _BancoCodigo = "399";
                        var _BancoCodigoDV = "9";

                        if (item["NM_Banco_Reduzido"].InnerText.ToUpper().Contains("BANESE"))
                        {
                            _BancoCodigo = "047";
                            _BancoCodigoDV = "7";
                        }
                        else if (item["NM_Banco_Reduzido"].InnerText.ToUpper().Contains("CAIXA"))
                        {
                            _BancoCodigo = "104";
                            _BancoCodigoDV = "0";
                        }
                        else if (item["NM_Banco_Reduzido"].InnerText.ToUpper().Contains("BRADESCO"))
                        {
                            _BancoCodigo = "237";
                            _BancoCodigoDV = "2";
                        }

                        EmissaoBoletoRetorno.CD_Banco = _BancoCodigo + "-" + _BancoCodigoDV;
                    }


                    if (item["CD_Inscricao_Nacional"] != null)
                        EmissaoBoletoRetorno.CD_Inscricao_Nacional = item["CD_Inscricao_Nacional"].InnerText;
                    else
                        EmissaoBoletoRetorno.CD_Inscricao_Nacional = "CNPJ: 14.723.388/0001-63";
                    //EmissaoBoletoRetorno.CD_Banco = item["CD_Banco"].InnerText;
                    // EmissaoBoletoRetorno.Endereco_Completo = item["Endereco_Completo"].InnerText;
                    //EmissaoBoletoRetorno.CD_Inscricao_Nacional = item["CD_Inscricao_Nacional"].InnerText;
                    // EmissaoBoletoRetorno.NM_Sacado = item["NM_Sacado"].InnerText;
                    EmissaoBoletoRetorno.NO_Identificador = item["NO_Identificador"].InnerText;

                    if (item["CEP_ECTPOSTNET"] != null)
                        EmissaoBoletoRetorno.CEP_ECTPOSTNET = item["CEP_ECTPOSTNET"].InnerText;
                    if (item["CIF"] != null) EmissaoBoletoRetorno.CIF = item["CIF"].InnerText;
                }
            }

            return EmissaoBoletoRetorno;
        }

        #endregion


        #region -- Busca Profissoes --

        public static List<BuscaProfissoesModel> BuscaProfissoes(string busca)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/BuscaProfissao"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "BuscaProfissao.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<BuscaProfissao xmlns='https://example.com/'>" +
                       "<NM_Profissao>" + busca + "</NM_Profissao>" +
                       "</BuscaProfissao>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var BuscaProfissoes = new List<BuscaProfissoesModel>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcProfissao");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsg = string.Empty;
                    var Return_Code = string.Empty;

                    if (item["Return_Code"].InnerText != "0")
                    {
                        ErrMsg = item["ErrMsg"].InnerText;
                        Return_Code = item["Return_Code"].InnerText;
                    }


                    BuscaProfissoes.Add(new BuscaProfissoesModel
                    {
                        ErrMsg = ErrMsg,
                        Return_Code = Return_Code,
                        ID_Profissao = item["ID_Profissao"].InnerText,
                        NM_Profissao = (item["NM_Profissao"].InnerText + "").PrimeiraMaiusculaPalavras()
                    });
                }
            }

            return BuscaProfissoes;
        }

        #endregion


        #region --  Busca Cidades --

        public static List<BuscaCidadesModel> BuscaCidades(string cidade, string uf)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/BuscaCidade"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "BuscaCidade.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<BuscaCidade xmlns='https://example.com/'>" +
                       "<NM_Cidade>" + cidade + "</NM_Cidade>" +
                       "<UF>" + uf + "</UF>" +
                       "</BuscaCidade>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var BuscaCidades = new List<BuscaCidadesModel>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcCidadeBusca");


                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsg = string.Empty;
                    var Return_Code = string.Empty;

                    if (item["Return_Code"].InnerText != "0")
                    {
                        ErrMsg = item["ErrMsg"].InnerText;
                        Return_Code = item["Return_Code"].InnerText;
                    }


                    BuscaCidades.Add(new BuscaCidadesModel
                    {
                        ErrMsg = ErrMsg,
                        Return_Code = Return_Code,
                        ID_Cidade = item["ID_Cidade"].InnerText,
                        NM_Cidade = (item["NM_Cidade"].InnerText + "").PrimeiraMaiusculaPalavras(),
                        ID_UF = item["ID_UF"].InnerText
                    });
                }
            }

            return BuscaCidades;
        }

        #endregion


        #region --  Consulta CEP --

        public static BuscaCepModel BuscaCep(string cep)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/ConsultaCEP"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "BuscaCidade.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<ConsultaCEP xmlns='https://example.com/'>" +
                       "<CEP>" + cep + "</CEP>" +
                       "</ConsultaCEP>";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var BuscaCep = new BuscaCepModel();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("ConsultaCEPResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsg = string.Empty;
                    if (item["ErrMsg"] != null) ErrMsg = item["ErrMsg"].InnerText;

                    //BuscaCep.Add(new BuscaCepModel()
                    //{
                    BuscaCep.ErrMsg = ErrMsg;
                    BuscaCep.Endereco = item["Endereco"].InnerText;
                    BuscaCep.Bairro = item["Bairro"].InnerText;
                    BuscaCep.NM_Cidade = item["NM_Cidade"].InnerText.PrimeiraMaiusculaPalavras();
                    BuscaCep.DDD = item["DDD"].InnerText;
                    BuscaCep.ID_UF = item["ID_UF"].InnerText;
                    BuscaCep.ID_Cidade = item["ID_Cidade"].InnerText;

                    //});
                    if (BuscaCep != null) break;
                }
            }

            return BuscaCep;
        }

        #endregion


        #region --  Estado sCivis --

        public static List<EstadosCivisModel> EstadosCivis()
        {
            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/EstadoCivil"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "EstadoCivil.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @" <EstadoCivil xmlns='https://example.com/' />";

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var EstadosCivis = new List<EstadosCivisModel>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcEstadoCivil");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsg = string.Empty;
                    var Return_Code = string.Empty;

                    if (item["Return_Code"].InnerText != "0")
                    {
                        ErrMsg = item["ErrMsg"].InnerText;
                        Return_Code = item["Return_Code"].InnerText;
                    }


                    EstadosCivis.Add(new EstadosCivisModel
                    {
                        ErrMsg = ErrMsg,
                        Return_Code = Return_Code,
                        ID_Estado_Civil = item["ID_Estado_Civil"].InnerText,
                        CD_Estado_Civil = item["CD_Estado_Civil"].InnerText,
                        NM_Estado_Civil = item["NM_Estado_Civil"].InnerText,
                        SN_Obriga_Conjuge = item["SN_Obriga_Conjuge"].InnerText,
                        SN_Permite_Dados_Conjuge = item["SN_Permite_Dados_Conjuge"].InnerText
                    });
                }
            }

            return EstadosCivis;
        }

        #endregion


        public static List<BoletoModel> GeraBoletosEmAtraso(string grupo, string cota)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento; // URL do webservice
            var _action = "https://example.com/GerarBAAtraso"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false);

            _content = @"<GerarBAAtraso xmlns='https://example.com/'>" +
                       "<CD_Grupo>" + grupo + "</CD_Grupo>" +
                       "<CD_Cota>" + cota + "</CD_Cota>" +
                       "<Versao>0</Versao>" +
                       "<QT_Dias_Contemplado>999</QT_Dias_Contemplado>" +
                       "<QT_Dias_NContemplado>999</QT_Dias_NContemplado>" +
                       "</GerarBAAtraso>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var BoletoModelResult = new List<BoletoModel>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcGeraBAAtraso");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsgn = string.Empty;
                    var Return_Code = string.Empty;

                    //if (item["Return_Code"].InnerText != "0")
                    //{
                    //    Return_Code = item["Return_Code"].InnerText;
                    //}

                    if (item["ErrMsg"] != null) ErrMsgn = item["ErrMsg"].InnerText;


                    BoletoModelResult.Add(new BoletoModel
                    {
                        //Return_Code = Return_Code,
                        ErrMsg = ErrMsgn,
                        ID_Identificador = item["ID_Identificador"].InnerText,
                        NO_Parcela = item["NO_Parcela"].InnerText,
                        DT_Vencimento = item["DT_Vencimento"].InnerText,
                        VL_Parcela = item["VL_Parcela"].InnerText,
                        VL_MJ = item["VL_MJ"].InnerText,
                        VL_Atraso = item["VL_Atraso"].InnerText
                    });
                }
            }

            return BoletoModelResult;
        }


        public static List<Boleto2ViaMensal> GerarBoletoDoMes(string grupo, string cota)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento; // URL do webservice
            var _action = "https://example.com/GerarBA2Via"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false);

            _content = @"<GerarBA2Via xmlns='https://example.com/'>" +
                       "<CD_Grupo>" + grupo + "</CD_Grupo>" +
                       "<CD_Cota>" + cota + "</CD_Cota>" +
                       "<Versao>0</Versao>" +
                       "</GerarBA2Via>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var BoletoModelResult = new List<Boleto2ViaMensal>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("GerarBA2ViaResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsgn = string.Empty;
                    var Return_Code = string.Empty;

                    //if (item["Return_Code"].InnerText != "0")
                    //{
                    //    Return_Code = item["Return_Code"].InnerText;
                    //}

                    if (item["ErrMsg"] != null) ErrMsgn = item["ErrMsg"].InnerText;


                    BoletoModelResult.Add(new Boleto2ViaMensal
                    {
                        //Return_Code = Return_Code,
                        ErrMsg = ErrMsgn,
                        ID_Identificador = item["ID_Identificador"].InnerText,
                        NO_Parcela = item["NO_Parcela"].InnerText,
                        DT_Vencimento = item["DT_Vencimento"].InnerText,
                        ID_Assembleia = item["ID_Assembleia"].InnerText,
                        VL_Parcela = item["VL_Parcela"].InnerText,
                        VL_MJ = item["VL_MJ"].InnerText,
                        VL_Total = item["VL_Total"].InnerText
                    });
                }
            }

            return BoletoModelResult;
        }


        public static void ReemissaoBoleto(string id_documento)
        {
            var path = string.Empty;
            var msg = string.Empty;
            var dataLog = DateTime.Now.ToString("dd-MM-yyyy");

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Configurações

            var folder = ServerMap.Path("~/" + SiteSettings.LocalXml); // Pasta onde queremos salvar os XMLs
            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice
            var _action = "";
            var _outputPath = "";
            var _content = "";

            _action = "https://example.com/ReemitirBoleto"; // Acão do WebService que queremos consultar
            _outputPath = @"" + folder + "ReemitirBoleto.xml"; //Path onde irá ser salvo o XML da ultima consulta
            _content = @"<ReemitirBoleto xmlns='https://example.com/'>" +
                       "<ID_Documento>" + id_documento + "</ID_Documento>" +
                       "</ReemitirBoleto>";

            #region ===== LOG 1 =====

            path = @"content/[" + dataLog + "]-REEMISSAO_BOLETO_LOG_1.txt";
            msg = "=========== [XML] ===========\r\n";
            msg += "[XML]: " + _content;

            Logs.Save(path, msg);

            #endregion

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            #region Envelope

            var envelope = Envelope(true);

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var EmissaoBoletoRetorno = new EmissaoBoletoRetornoModel();

            #region ===== LOG 2 =====

            path = @"content/[" + dataLog + "]-RETORNO-REEMISSAO_BOLETO_LOG_2.txt";
            msg = "=========== [XML] ===========\r\n";
            msg += "[XML]: " + ResultadoSoap;

            Logs.Save(path, msg);

            #endregion

            if (ResultadoSoap != "")
            {
            }
        }


        public static prcGeraBAParcelasResult IdenticarGrupoCotaBoleto(string grupo, string cota, string Versao)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento;
            var _action = "https://example.com/prcGeraBAParcelas"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(true);

            _content = "<prcGeraBAParcelas xmlns='https://example.com/'>" +
                       "<CD_Grupo>" + grupo + "</CD_Grupo>" +
                       "<CD_Cota>" + cota + "</CD_Cota>" +
                       "<Versao>" + Versao + "</Versao>" +
                       "</prcGeraBAParcelas>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var BoletoModelResult = new prcGeraBAParcelasResult();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcGeraBAParcelasResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsgn = string.Empty;
                    var Return_Code = string.Empty;

                    if (item["ErrMsg"] != null) ErrMsgn = item["ErrMsg"].InnerText;
                    BoletoModelResult.ErrMsg = ErrMsgn;
                    BoletoModelResult.ID_Identificador = item["ID_Identificador"].InnerText;
                }
            }

            return BoletoModelResult;
        }


        public static List<resultadoParcelas> ParcelasComTaxasBoleto(string ID_Identificador)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento;
            var _action = "https://example.com/ParcelasBA"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false);

            //10 RECBTO. PARCELA
            //330 RECBTO. MULTAS/JUROS
            //356 PAGT. DE NOTIFICAÇÃO
            //360 RECBTO. DESPESA DE CART. 
            //370 RECBTO. TAXA TRANSF CONTR. 
            //374 PAGTO TX.DESALIENAÇÃO 
            //388 REC. REG CONTRATO 
            //390 RECBTO DE GRAVAMES 
            //406 TAXA SUBSTITUICAO GARANTIA 
            //2250 TAXA DE SERVIÇOS

            _content = @"<ParcelasBA xmlns='https://example.com/'>" +
                       "<ID_Identificador>" + ID_Identificador + "</ID_Identificador>" +
                       "<ID_CD_Movto_Fin_Filtro>" +
                       "<int>90</int>" +
                       "<int>130</int>" +
                       "<int>10</int>" +
                       "<int>270</int>" +
                       "<int>330</int>" +
                       "<int>356</int>" +
                       "<int>360</int>" +
                       "<int>370</int>" +
                       "<int>374</int>" +
                       "<int>388</int>" +
                       "<int>390</int>" +
                       "<int>406</int>" +
                       "<int>2250</int>" +
                       "</ID_CD_Movto_Fin_Filtro>" +
                       "</ParcelasBA>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            
            var BoletoModelResult = new List<resultadoParcelas>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcBAParcelas");

                foreach (XmlNode item in xmlNodeList)
                {
                    //Quando da erro retorna XML diferente
                    //<stcBAParcelas>
                    //<ErrMsg>Nenhum registro encontrado.</ErrMsg>
                    //<ID_Cobranca>0</ID_Cobranca>
                    //<DT_Vencimento>0001-01-01T00:00:00</DT_Vencimento>
                    //<ID_Assembleia>0</ID_Assembleia>
                    //<VL_Paga>0</VL_Paga>
                    //<VL_MJ>0</VL_MJ>
                    //<VL_Pendencia>0</VL_Pendencia>
                    //<ID_CD_Movto_Fin>0</ID_CD_Movto_Fin>
                    //</stcBAParcelas>

                    var ErrMsg = string.Empty;

                    if (item["ErrMsg"] != null)
                        ErrMsg = item["ErrMsg"].InnerText;
                    //BoletoModelResult.Add(new ParcelasBAResult()
                    //{
                    //    //ErrMsg = ErrMsg,
                    //    //ID_Identificador = ID_Identificador,
                    //    ID_Cobranca = item["ID_Cobranca"].InnerText,
                    //    //NO_Parcela = item["NO_Parcela"].InnerText,
                    //    DT_Vencimento = Convert.ToDateTime(item["DT_Vencimento"].InnerText),
                    //    ID_Assembleia = item["ID_Assembleia"].InnerText,
                    //    VL_Paga = Convert.ToDecimal(item["VL_Paga"].InnerText.Replace(",", "").Replace(".", ",")),
                    //    VL_MJ = Convert.ToDecimal(item["VL_MJ"].InnerText.Replace(",", "").Replace(".", ",")),
                    //    VL_Pendencia = Convert.ToDecimal(item["VL_Pendencia"].InnerText.Replace(",", "").Replace(".", ",")),
                    //    //SN_Emite_Boleto = item["SN_Emite_Boleto"].InnerText,
                    //    ID_CD_Movto_Fin = item["ID_CD_Movto_Fin"].InnerText,
                    //    //NM_CD_Movto_Fin = item["NM_CD_Movto_Fin"].InnerText
                    //});
                    else
                        BoletoModelResult.Add(new resultadoParcelas
                        {
                            ID_Identificador = ID_Identificador,
                            ID_Cobranca = item["ID_Cobranca"].InnerText,
                            NO_Parcela = item["NO_Parcela"].InnerText,
                            DT_Vencimento = Convert.ToDateTime(item["DT_Vencimento"].InnerText),
                            ID_Assembleia = item["ID_Assembleia"].InnerText,
                            VL_Paga = Convert.ToDecimal(item["VL_Paga"].InnerText.Replace(",", "").Replace(".", ",")),
                            VL_MJ = Convert.ToDecimal(item["VL_MJ"].InnerText.Replace(",", "").Replace(".", ",")),
                            VL_Pendencia =
                                Convert.ToDecimal(item["VL_Pendencia"].InnerText.Replace(",", "").Replace(".", ",")),
                            SN_Emite_Boleto = item["SN_Emite_Boleto"].InnerText,
                            ID_CD_Movto_Fin = item["ID_CD_Movto_Fin"].InnerText,
                            NM_CD_Movto_Fin = item["NM_CD_Movto_Fin"].InnerText
                            // Referência de objeto não definida para uma instância de um objeto.
                            //ID_Cobranca>24</ID_Cobranca>
                            //NO_Parcela>015</NO_Parcela>
                            //DT_Vencimento>2015-08-08T00:00:00</DT_Vencimento>
                            //ID_Assembleia>46739</ID_Assembleia>
                            //VL_Paga>49.47</VL_Paga>
                            //VL_MJ>0</VL_MJ>
                            //VL_Pendencia>49.47</VL_Pendencia>
                            //SN_Emite_Boleto>N</SN_Emite_Boleto>
                            //ID_CD_Movto_Fin>390</ID_CD_Movto_Fin>
                            //NM_CD_Movto_Fin>RECBTO DE GRAVAMES</NM_CD_Movto_Fin>
                        });
                }
            }

            return BoletoModelResult;
        }


        public static List<prcMarcaBAParcelaResult> SelecionandoParcalaParaPagamentoBolerto(string ID_Identificador,
            string ID_Cobranca)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento;
            var _action = "https://example.com/prcMarcaBAParcela"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false);

            //10 RECBTO. PARCELA
            //330 RECBTO. MULTAS/JUROS 
            //356 PAGT. DE NOTIFICAÇÃO
            //360 RECBTO. DESPESA DE CART. 
            //370 RECBTO. TAXA TRANSF CONTR. 
            //374 PAGTO TX.DESALIENAÇÃO 
            //388 REC. REG CONTRATO 
            //390 RECBTO DE GRAVAMES 
            //406 TAXA SUBSTITUICAO GARANTIA 
            //2250 TAXA DE SERVIÇOS


            _content = @"<prcMarcaBAParcela xmlns='https://example.com/'>" +
                       "<ID_Identificador>" + ID_Identificador + "</ID_Identificador>" +
                       "<ID_Cobranca>" + ID_Cobranca + "</ID_Cobranca>" +
                       "<ID_CD_Movto_Fin_Filtro>" +
                       "<int>90</int>" +
                       "<int>130</int>" +
                       "<int>10</int>" +
                       "<int>270</int>" +
                       "<int>330</int>" +
                       "<int>356</int>" +
                       "<int>360</int>" +
                       "<int>370</int>" +
                       "<int>374</int>" +
                       "<int>388</int>" +
                       "<int>390</int>" +
                       "<int>406</int>" +
                       "<int>2250</int>" +
                       "</ID_CD_Movto_Fin_Filtro>" +
                       "</prcMarcaBAParcela>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var BoletoModelResult = new List<prcMarcaBAParcelaResult>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcBAParcelas");

                foreach (XmlNode item in xmlNodeList)
                {
                    var ErrMsgn = string.Empty;

                    if (item["ErrMsg"] != null) ErrMsgn = item["ErrMsg"].InnerText;

                    // ErrMsg = ErrMsgn,

                    BoletoModelResult.Add(new prcMarcaBAParcelaResult
                    {
                        ID_Identificador = ID_Identificador,
                        ID_Cobranca = item["ID_Cobranca"].InnerText,
                        NO_Parcela = item["NO_Parcela"].InnerText,
                        DT_Vencimento = Convert.ToDateTime(item["DT_Vencimento"].InnerText),
                        ID_Assembleia = item["ID_Assembleia"].InnerText,
                        VL_Paga = Convert.ToDecimal(item["VL_Paga"].InnerText.Replace(",", "").Replace(".", ",")),
                        VL_MJ = Convert.ToDecimal(item["VL_MJ"].InnerText.Replace(",", "").Replace(".", ",")),
                        VL_Pendencia =
                            Convert.ToDecimal(item["VL_Pendencia"].InnerText.Replace(",", "").Replace(".", ",")),
                        SN_Emite_Boleto = item["SN_Emite_Boleto"].InnerText,
                        ID_CD_Movto_Fin = item["ID_CD_Movto_Fin"].InnerText,
                        NM_CD_Movto_Fin = item["NM_CD_Movto_Fin"].InnerText
                    });
                }
            }

            return BoletoModelResult;
        }

        public static prcConfirmaBAParcelasResult ComfirmarParcaleaSelecionadaBoleto(string cd_grupo, string cd_cota,
            string id_identificador)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento; // URL do webservice "";
            var _action = "https://example.com/prcConfirmaBAParcelas"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(false);


            _content = @"<prcConfirmaBAParcelas xmlns='https://example.com/'>" +
                       "<ID_Identificador>" + id_identificador + "</ID_Identificador>" +
                       "<CD_Grupo>" + cd_grupo + "</CD_Grupo>" +
                       "<CD_Cota>" + cd_cota + "</CD_Cota>" +
                       "<Versao>0</Versao>" +
                       "</prcConfirmaBAParcelas>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            //DEU CERTO RETORNA ZERO
            //<?xml version="1.0" encoding="utf-8"?>
            //<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            //  <soap:Body>
            //    <prcConfirmaBAParcelasResponse xmlns="https://example.com/">
            //      <prcConfirmaBAParcelasResult>
            //        <Return_Code>0</Return_Code>
            //        <Err_Msg />
            //      </prcConfirmaBAParcelasResult>
            //    </prcConfirmaBAParcelasResponse>
            //  </soap:Body>
            //</soap:Envelope>

            var BoletoModelResult = new prcConfirmaBAParcelasResult();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcConfirmaBAParcelasResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    var Err_Msg = string.Empty;
                    var Return_Code = string.Empty;

                    if (item["Return_Code"].InnerText == "0") Return_Code = item["Return_Code"].InnerText;

                    if (item["Err_Msg"] != null) Err_Msg = item["Err_Msg"].InnerText;

                    BoletoModelResult.Return_Code = Return_Code;
                    BoletoModelResult.Err_Msg = Err_Msg;
                    BoletoModelResult.ID_Identificador = id_identificador;
                }
            }

            return BoletoModelResult;
        }

        public static List<PrazosDisponiveisConsulta> RetornarPrazosDisponiveis(string ID_Identificador,
            string ST_Negociacao)
        {
            #region -- Configurações --

            var _url = SiteSettings.WsUrlVendaExternaProposta; // URL do webservice

            var _action =
                "https://example.com/PrazosGrupos"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(true);

            var path = "";

            if (HttpContext.Current == null)
                path = AppDomain.CurrentDomain.BaseDirectory + SiteSettings.LocalXmlConsultar.Replace("/", "\\");
            else
                path = HttpContext.Current.Server.MapPath("~/" + SiteSettings.LocalXmlConsultar);

            _content = @"<PrazosGrupos xmlns='https://example.com/'>" +
                       "<ID_Identificador>" + ID_Identificador + "</ID_Identificador>" +
                       "<ID_Unidade_Negocio>2</ID_Unidade_Negocio>" +
                       "</PrazosGrupos>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);
            var lista = new List<PrazosDisponiveisConsulta>();

            try
            {
                if (ResultadoSoap != "")
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(ResultadoSoap);
                    var xmlNodeList = xmlDocument.GetElementsByTagName("stcPrazoDisponivel");

                    foreach (XmlNode item in xmlNodeList)
                    {
                        var prazo = new PrazosDisponiveisConsulta();

                        if (item["Return_Code"].InnerText != "0")
                        {
                            prazo.ErrMsg = item["ErrMsg"].InnerText;
                            prazo.Return_Code = item["Return_Code"].InnerText;
                        }

                        prazo.CD_Bem = item["CD_Bem"].InnerText;
                        prazo.NM_Bem = item["NM_Bem"].InnerText;
                        prazo.VL_Bem = item["VL_Bem"].InnerText;
                        prazo.ID_Bem = item["ID_Bem"].InnerText;
                        prazo.ID_Grupo = item["ID_Grupo"].InnerText;
                        prazo.CD_Grupo = item["CD_Grupo"].InnerText;
                        prazo.ST_Situacao = item["ST_Situacao"].InnerText;
                        prazo.PZ_Plano = item["PZ_Plano"].InnerText;
                        prazo.PZ_Restante = item["PZ_Restante"].InnerText;
                        prazo.PE_Taxa_Adm_Plano = item["PE_Taxa_Adm_Plano"].InnerText;
                        prazo.PE_Fundo_Reserva_Plano = item["PE_Fundo_Reserva_Plano"].InnerText;
                        prazo.PE_Adesao_Plano = item["PE_Adesao_Plano"].InnerText;
                        prazo.SN_Permite_Reserva = item["SN_Permite_Reserva"].InnerText;
                        prazo.VL_Juridica = item["VL_Juridica"].InnerText;
                        prazo.VL_Fisica = item["VL_Fisica"].InnerText;
                        prazo.ID_Taxa_Plano = item["ID_Taxa_Plano"].InnerText;
                        prazo.ID_Plano_Venda = item["ID_Plano_Venda"].InnerText;
                        prazo.ID_Tipo_Venda_Grupo = item["ID_Tipo_Venda_Grupo"].InnerText;
                        prazo.ID_Assembleia = item["ID_Assembleia"].InnerText;
                        prazo.QT_Participante = item["QT_Participante"].InnerText;
                        prazo.PE_SG_F = item["PE_SG_F"].InnerText;
                        prazo.PE_SG_J = item["PE_SG_J"].InnerText;
                        prazo.VL_SG_F = item["VL_SG_F"].InnerText;
                        prazo.VL_SG_J = item["VL_SG_J"].InnerText;
                        prazo.ST_Negociacao = ST_Negociacao;

                        //prazo.ListaDetalhe.AddRange(RetornarPrazosDisponiveisDetalhe(ID_Identificador, "2", prazo.ID_Plano_Venda, prazo.ID_Taxa_Plano, prazo.ID_Bem, prazo.ID_Grupo));

                        lista.Add(prazo);
                    }

                    return lista;
                }

                //Mandar e-mail notificação com a mensagem "WebServices de Produtos Eetornou Nulo"
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region BoletoPorParcela Antigo não será mais utilizado

        //public static bool BoletoPorParcela(string id, string parcela)
        //{
        //    #region -- Configurações --

        //    string _url = SiteSettings.expWSboletoAtraso; // URL do webservice
        //    string _action = "http://www.brconsorcios.com/GerarBoletoPorParcela/GerarBoletoPorParcela"; // Acão do WebService que queremos consultar
        //    string _content = ""; // Colocando conteúdo no envelope formato XML

        //    #endregion

        //    #region -- Envelope --

        //    string envelope = Envelope(false);


        //    _content = @"    <GerarBoletoPorParcela xmlns='http://www.brconsorcios.com/GerarBoletoPorParcela'>" +
        //                  "<parcela>" + parcela + "</parcela>" +
        //                  "<identificador>" + id + "</identificador>" +
        //                "</GerarBoletoPorParcela>";


        //    #endregion

        //    WebServicesSoap _WebServicesSoap;
        //    _WebServicesSoap = new WebServicesSoap();
        //    string ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

        //    bool retorno = false;

        //    if (ResultadoSoap != "")
        //    {
        //        XmlDocument xmlDocument = new XmlDocument();
        //        xmlDocument.LoadXml(ResultadoSoap);
        //        XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("TableErro");

        //        foreach (XmlNode item in xmlNodeList)
        //        {
        //            string ErrMsgn = string.Empty;
        //            string Return_Code = string.Empty;


        //            if (item["cod"] != null)
        //            {
        //                if (item["cod"].InnerText == "100")
        //                {
        //                    retorno = true;
        //                }
        //            }


        //        }
        //    }
        //    return retorno;

        //}

        #endregion

        #region NOVOS METODOS

        public static string GeraPrazosDisponiveisGrupos(string emp, string prod, string tipo_pessoa)
        {
            #region -- Configurações --

            var _url = SiteSettings.WsUrlVendaExternaProposta;
            var _action =
                "https://example.com/prcGeraPrazosDisponiveisGrupos"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML
            var Err_Msg = string.Empty;
            var Return_Code = string.Empty;
            var ID_Identificador = string.Empty;

            #endregion

            #region -- Envelope --

            var envelope = Envelope(true);

            _content = "<prcGeraPrazosDisponiveisGrupos xmlns='https://example.com/'>" +
                       "<ID_Empresa>108</ID_Empresa>" +
                       "<ID_Ponto_Venda>8667</ID_Ponto_Venda>" +
                       "<ST_Tipo_Pessoa>" + tipo_pessoa + "</ST_Tipo_Pessoa>" +
                       "<ID_Produto>" + prod + "</ID_Produto>" +
                       "<ID_Bem>0</ID_Bem>" +
                       "<VL_PC_Inicial>0</VL_PC_Inicial>" +
                       "<VL_PC_Final>999999</VL_PC_Final>" +
                       "<VL_Bem_Inicial>0</VL_Bem_Inicial>" +
                       "<VL_Bem_Final>999999</VL_Bem_Final>" +
                       "<SN_Andamento>S</SN_Andamento>" +
                       "<SN_Formacao>S</SN_Formacao>" +
                       "<CD_Plano_Venda_Inicial>0</CD_Plano_Venda_Inicial>" +
                       "<CD_Plano_Venda_Final>999999</CD_Plano_Venda_Final>" +
                       "<CD_Tipo_Venda_Grupo_Inicial>001</CD_Tipo_Venda_Grupo_Inicial>" +
                       "<CD_Tipo_Venda_Grupo_Final>999</CD_Tipo_Venda_Grupo_Final>" +
                       "<PZ_Inicial>0</PZ_Inicial>" +
                       "<PZ_Final>999</PZ_Final>" +
                       "<ST_Negociacao>RT</ST_Negociacao>" +
                       "<ID_Regiao_Fiscal>301</ID_Regiao_Fiscal>" +
                       "</prcGeraPrazosDisponiveisGrupos>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("prcGeraPrazosDisponiveisGruposResult");

                foreach (XmlNode item in xmlNodeList)
                {
                    if (item["Return_Code"].InnerText == "0") Return_Code = item["Return_Code"].InnerText;

                    if (item["Err_Msg"] != null) Err_Msg = item["Err_Msg"].InnerText;

                    ID_Identificador = item["ID_Identificador"].InnerText;
                }
            }

            return ID_Identificador;
        }


        public static string PrazosDisponiveisGrupos(string id, string unidade)
        {
            #region -- Configurações --

            var _url = SiteSettings.WsUrlVendaExternaProposta;
            var _action =
                "https://example.com/PrazosGrupos"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(true);

            _content = " <PrazosGrupos xmlns='https://example.com/'>" +
                       "<ID_Identificador>" + id + "</ID_Identificador>" +
                       "<ID_Unidade_Negocio>" + unidade + "</ID_Unidade_Negocio>" +
                       "</PrazosGrupos>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);


            if (ResultadoSoap != "")
            {
            }

            return ResultadoSoap;
        }

        public static string DetalhePrazosDisponiveisGrupos(string id, string unidade)
        {
            #region -- Configurações --

            var _url = SiteSettings.WsUrlVendaExternaProposta;
            var _action =
                "https://example.com/PrazosDisponiveisGrupos"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(true);

            _content = "<PrazosDisponiveisGrupos xmlns='https://example.com/'>" +
                       "<ID_Identificador>28736987</ID_Identificador>" +
                       "<ID_Unidade_Negocio>1</ID_Unidade_Negocio>" +
                       "<ID_Plano_Venda>1052</ID_Plano_Venda>" +
                       "<ID_Taxa_Plano>272</ID_Taxa_Plano>" +
                       "<ID_Bem>9499</ID_Bem>" +
                       "<ID_Grupo>10064</ID_Grupo>" +
                       "</PrazosDisponiveisGrupos>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            if (ResultadoSoap != "")
            {
            }

            return ResultadoSoap;
        }

        public static List<ClienteCotasModel> CotasCliente(string id)
        {
            #region -- Configurações --

            var _url = SiteSettings.WebAtendimento;
            var _action = "https://example.com/Cotas"; // Acão do WebService que queremos consultar
            var _content = ""; // Colocando conteúdo no envelope formato XML

            #endregion

            #region -- Envelope --

            var envelope = Envelope(true);

            _content = "<Cotas  xmlns='https://example.com/'>" +
                       "<ID_Pessoa>" + id + "</ID_Pessoa>" +
                       "</Cotas>";

            #endregion

            WebServicesSoap _WebServicesSoap;
            _WebServicesSoap = new WebServicesSoap();
            var ResultadoSoap = _WebServicesSoap.WebServicesSoapAcao(envelope, _url, _action, _content);

            var cotas = new List<ClienteCotasModel>();

            if (ResultadoSoap != "")
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(ResultadoSoap);
                var xmlNodeList = xmlDocument.GetElementsByTagName("stcCotasCliente");


                foreach (XmlNode item in xmlNodeList)
                    cotas.Add(new ClienteCotasModel
                    {
                        Versao = Convert.ToInt32(item["Versao"].InnerText),
                        ID_Cota = Convert.ToInt32(item["ID_Cota"].InnerText),
                        CD_Cota = Convert.ToInt32(item["CD_Cota"].InnerText),
                        CD_Grupo = item["CD_Grupo"].InnerText
                    });
            }

            return cotas;
        }

        #endregion
    }
}