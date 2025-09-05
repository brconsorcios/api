using System.Configuration;

namespace exp.web.Code
{
    public static class SiteSettings
    {
        public static string NomeDoSiteAdm => ConfigurationManager.AppSettings["NomeDoSiteAdm"] ?? string.Empty;

        public static string LocalImagens => ConfigurationManager.AppSettings["Upload.Imagens"] ?? string.Empty;

        public static string LocalHomepage => ConfigurationManager.AppSettings["Upload.Homepage"] ?? string.Empty;

        public static string LocalBancoimagem =>
            ConfigurationManager.AppSettings["Upload.bancoimagens"] ?? string.Empty;

        public static string WsUrlVendaExterna => ConfigurationManager.AppSettings["SOAP.UrlVendaExterna"] ??
                                                  "http://localhost:90/Integracao.asmx";

        public static string WsUrlVendaExternaProposta =>
            ConfigurationManager.AppSettings["SOAP.UrlVendaExternaProposta"] ?? "http://localhost:90/Integracao.asmx";

        public static string WebAtendimento => ConfigurationManager.AppSettings["SOAP.WebAtendimento"] ?? string.Empty;

        public static string expWSboletoAtraso =>
            ConfigurationManager.AppSettings["SOAP.expWSboletoAtraso"] ?? string.Empty;


        public static string WsTokenUser => ConfigurationManager.AppSettings["Token.User"] ?? "000";

        public static string WsTokenPws => ConfigurationManager.AppSettings["Token.Pws"] ?? "000";

        public static string LocalXmlImportacao => ConfigurationManager.AppSettings["Importacao.Xml"] ?? string.Empty;


        public static string PastaLocal => ConfigurationManager.AppSettings["PastaLocal"] ?? string.Empty;


        public static string LocalXmlConsultar => ConfigurationManager.AppSettings["Consultar.Xml"] ?? string.Empty;


        public static string Localempresas => ConfigurationManager.AppSettings["Upload.empresas"] ?? string.Empty;


        public static string LocalBens => ConfigurationManager.AppSettings["Upload.bens"] ?? string.Empty;


        public static string Localconteudo => ConfigurationManager.AppSettings["Upload.conteudo"] ?? string.Empty;

        public static string LocalArquivos => ConfigurationManager.AppSettings["Upload.Arquivos"] ?? string.Empty;

        public static string Localvideo => ConfigurationManager.AppSettings["Upload.video"] ?? string.Empty;

        public static string LocalFotos => ConfigurationManager.AppSettings["Upload.Fotos"] ?? string.Empty;

        public static string LocalXml => ConfigurationManager.AppSettings["Upload.Xml"] ?? string.Empty;

        public static string ItemPorPg => ConfigurationManager.AppSettings["adm.itemporpg"] ?? string.Empty;

        public static string ItemPorPgsite => ConfigurationManager.AppSettings["site.itemporpg"] ?? string.Empty;

        public static string LocalPontosdevenda =>
            ConfigurationManager.AppSettings["Upload.Pontosdevenda"] ?? string.Empty;

        public static string LocalVideoConvert => ConfigurationManager.AppSettings["Video.Convert"] ?? string.Empty;

        public static string SoapConsulta => ConfigurationManager.AppSettings["Soap.Consulta"] ?? string.Empty;


        public static string ID_Ponto_Venda => ConfigurationManager.AppSettings["ID_Ponto_Venda"] ?? string.Empty;


        public static string ID_Usuario => ConfigurationManager.AppSettings["ID_Usuario"] ?? string.Empty;

        public static string ID_Empresa => ConfigurationManager.AppSettings["ID_Empresa"] ?? string.Empty;

        public static string ID_Comissionado => ConfigurationManager.AppSettings["ID_Comissionado"] ?? string.Empty;


        public static string path_boleto => ConfigurationManager.AppSettings["path.boleto"] ?? string.Empty;

        public static string imgs_boleto => ConfigurationManager.AppSettings["imgs.boleto"] ?? string.Empty;

        public static string path_contrato => ConfigurationManager.AppSettings["path.contrato"] ?? string.Empty;

        public static string path_propostas => ConfigurationManager.AppSettings["path.propostas"] ?? string.Empty;


        public static string ExpAPIlogin => ConfigurationManager.AppSettings["API.login"] ?? string.Empty;

        public static string ExpAPIsenha => ConfigurationManager.AppSettings["API.senha"] ?? string.Empty;

        public static string ExpAPIpasta => ConfigurationManager.AppSettings["API.pasta"] ?? string.Empty;

        public static string ExpAPIurl => ConfigurationManager.AppSettings["API.Url"] ?? string.Empty;

        public static string NomeCookieVendeAut =>
            ConfigurationManager.AppSettings["NomeCookieVendeAut"] ?? string.Empty;

        public static string RedirectVendeAut => ConfigurationManager.AppSettings["RedirectVendeAut"] ?? string.Empty;

        public static string SUPERPAYcodigoEstabelecimento =>
            ConfigurationManager.AppSettings["SUPERPAY.codigoEstabelecimento"] ?? string.Empty;
        //public static string SUPERPAYServicosPagamentoCompletoWSService
        //{
        //    get { return ConfigurationManager.AppSettings["SUPERPAY.ServicosPagamentoCompletoWSService"] ?? String.Empty; }
        //}

        public static string PAGCONSORCIOSkey => ConfigurationManager.AppSettings["PAGCONSORCIOS.key"] ?? string.Empty;

        public static string PAGCONSORCIOSurl => ConfigurationManager.AppSettings["PAGCONSORCIOS.url"] ?? string.Empty;

        public static string URLAtualizaBoleto => ConfigurationManager.AppSettings["URLAtualizaBoleto"] ?? string.Empty;

        public static string Descricao_data_content =>
            ConfigurationManager.AppSettings["Descricao_data_content"] ?? string.Empty;

        public static string DescTelevendas => ConfigurationManager.AppSettings["DescTelevendas"] ?? string.Empty;

        public static string DescCentralRelacionamento =>
            ConfigurationManager.AppSettings["DescCentralRelacionamento"] ?? string.Empty;

        public static string GeraDataLog_RelatorioVendasIndicadas =>
            ConfigurationManager.AppSettings["GeraDataLog_RelatorioVendasIndicadas"] ?? string.Empty;

        public static string tipo_indicacao_InibidasSites =>
            ConfigurationManager.AppSettings["tipo_indicacao_InibidasSites"] ?? string.Empty;

        public static string idSite_InibeIndicacaoes =>
            ConfigurationManager.AppSettings["idSite_InibeIndicacaoes"] ?? string.Empty;


        #region Envio de Emails das indicacoes

        public static string EmailAdministrador
        {
            get
            {
                var retorno = string.Empty;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Email.Administrador"]))
                    retorno = ConfigurationManager.AppSettings["Email.Administrador"].Replace("{", "<")
                        .Replace("}", ">");
                return retorno;
            }
        }

        public static string EmailSuporte
        {
            get
            {
                var retorno = string.Empty;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Email.Suporte"]))
                    retorno = ConfigurationManager.AppSettings["Email.Suporte"].Replace("{", "<").Replace("}", ">");
                return retorno;
            }
        }

        public static string EmailReplayTo
        {
            get
            {
                var retorno = string.Empty;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Email.ReplayTo"]))
                    retorno = ConfigurationManager.AppSettings["Email.ReplayTo"].Replace("{", "<").Replace("}", ">");
                return retorno;
            }
        }

        public static string EmailFrom
        {
            get
            {
                var retorno = string.Empty;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Email.From"]))
                    retorno = ConfigurationManager.AppSettings["Email.From"].Replace("{", "<").Replace("}", ">");
                return retorno;
            }
        }

        public static string EmailNotificacoes
        {
            get
            {
                var retorno = string.Empty;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Email.Notificacoes"]))
                    retorno = ConfigurationManager.AppSettings["Email.Notificacoes"].Replace("{", "<")
                        .Replace("}", ">");
                return retorno;
            }
        }

        #endregion

        #region Envio de Emails das vendas indicadas

        public static string EmailSubjectVendasIndicadas =>
            ConfigurationManager.AppSettings["Email.subject.vendasindicadas"] ?? string.Empty;

        public static string EmailToVendasIndicadas =>
            ConfigurationManager.AppSettings["Email.to.vendasindicadas"]?.Replace("{", "<")?.Replace("}", ">") ??
            string.Empty;

        public static string EmailCcVendasIndicadas =>
            ConfigurationManager.AppSettings["Email.cc.vendasindicadas"]?.Replace("{", "<")?.Replace("}", ">") ??
            string.Empty;

        public static string EmailCcoVendasIndicadas => ConfigurationManager.AppSettings["Email.cco.vendasindicadas"]
            ?.Replace("{", "<")?.Replace("}", ">") ?? string.Empty;

        public static string EmailFromVendasIndicadas => ConfigurationManager.AppSettings["Email.from.vendasindicadas"]
            ?.Replace("{", "<")?.Replace("}", ">") ?? string.Empty;

        public static string EmailReplyVendasIndicadas =>
            ConfigurationManager.AppSettings["Email.reply.vendasindicadas"]?.Replace("{", "<")?.Replace("}", ">") ??
            string.Empty;

        #endregion


        #region Atendimentos

        public static string LocalChamadosAnexos =>
            ConfigurationManager.AppSettings["Upload.ChamadosAnexos"] ?? string.Empty;

        public static string BR_PATH => ConfigurationManager.AppSettings["br_path"] ?? string.Empty;

        public static string BR_HTTP => ConfigurationManager.AppSettings["br_http"] ?? string.Empty;

        #endregion
    }
}