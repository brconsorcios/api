using System;
using System.Text;
using System.Web;
using exp.core;
using exp.core.Utilitarios;
using exp.dados;
using exp.dados.Servicos;
using exp.web.Code;

namespace exp.web.CodePagCosorcio
{
    public class PagConsorcio
    {
        public static int ConverteStatusParaIndicacao(int status)
        {
            //1 = Transações Criadas
            //2 = Transações Em Processamento
            //3 = Transações Autorizadas
            //4 = Transações Negadas
            //5 = Transações Canceladas
            //6 = Transações Com Erro de TimeOut
            //7 = Transações Com Erro

            //Retorna o status utilizado na indicação

            var voltar = 0;
            switch (status)
            {
                case 1: //Transações Criadas
                    voltar = 8; // Aguardando Pagamento
                    break;
                case 2: //Transações Em Processamento
                    voltar = 5; // "Transação em Andamento";//A transação está em andamento.Transitório
                    break;
                case 3: //Transações Autorizadas
                    voltar = 2; //"Autorizado";//A transação ainda será capturada na operadora. Transitório
                    break;
                case 4: //Transações Negadas
                    voltar = 9; //"Falha na Operadora";//A transação não foi autorizada pela operadora. Houve um problema em seu processamento. Final
                    break;
                case 5: //Transações Canceladas
                    voltar = 13; //Cancelado A transação foi cancelada na adquirente Final
                    break;
                case 6: //Transações Com Erro de TimeOut
                    voltar = 3; //Não Autorizado A transação foi negada pela operadora.Final
                    break;
                case 7: //Transações Com Erro
                    voltar = 3; //Não Autorizado A transação foi negada pela operadora.Final
                    break;
            }

            return voltar;
        }

        public static PagConsorcioRetornoTransacao Executar(indicaco compra, string NomeSCP, string apikey)
        {
            // preencher transacao que vai como parâmetro junto com usuario e senha
            var transacao = new PagConsorcioEnviarTransacao();

            #region CONTRATO

            var descricao = string.Format("INDICAÇÃO: {0} - SCP: {1}.", compra.id, NomeSCP);


            transacao.ContratoNumero = compra.id_documento.ToString(); // string
            transacao.ContratoGrupo = ""; // string
            transacao.ContratoCota = ""; //string

            transacao.ContratoCredito = compra.vl_bem.Value; // decimal  Valor do Bem
            transacao.ContratoValor = compra.vl_parcela.Value; // decimal Valor da Parcela a Pagar

            var url = HttpContext.Current.Request.Url.AbsoluteUri;

            if (url.Contains("dev.") || url.Contains("dev2.") || url.Contains("localhost"))
            {
                transacao.ContratoCredito = 30000.00M; // decimal  Valor do Bem
                transacao.ContratoValor = 350.00M; // decimal Valor da Parcela a Pagar
            }
            //transacao.ContratoValor = 350.01M;// decimal Valor da Parcela a Pagar


            transacao.ContratoDescricao = descricao; // string

            #endregion

            #region DADOS CLIENTE

            var TipoPessoa = "0";
            if (compra.cpfcnpj.Length > 11) TipoPessoa = "1";
            transacao.TipoPessoa = TipoPessoa;
            transacao.Nome = compra.nome.RetirarAcentos();
            ; // string
            //Não altere e-mail abaixo!
            transacao.Email = "gustavo@brconsorcios.com"; //compra.email // string
            transacao.CpfCnpj = compra.cpfcnpj; // string
            transacao.Telefone = compra.telefone; // string
            transacao.Celular = compra.celular; // string
            transacao.Cep = compra.cep; // string
            transacao.Logradouro = compra.endereco.RetirarAcentos();
            ; // string
            transacao.Bairro = compra.bairro; // string
            transacao.Complemento = compra.complemento; // string
            transacao.Cidade = compra.cidade; // string
            transacao.Estado = compra.uf; // string

            #endregion

            #region DADOS VENDEDOR

            transacao.VendedorCodigo = compra.id_comissionado.ToString(); // string
            transacao.VendedorNome = ""; // string
            transacao.VendedorEmail = ""; // string
            transacao.VendedorCelular = ""; // string

            #endregion

            #region DADOS CARTÃO DE CRÉDITO

            var tipo = compra.credtipo.Split('-');
            var validade = compra.credvenc.Split('/');

            transacao.CartaoTitular = compra.nome_resp;
            ; // string
            transacao.CartaoTitularCPF = compra.credcpf;
            ; // string
            transacao.CartaoNumero = compra.cred.toDencod64().RetirarAlfabeto(); // string
            transacao.CartaoID = Convert.ToInt32(tipo[0]); // int
            transacao.CartaoValidadeMes = Convert.ToInt32(validade[0]); // int
            transacao.CartaoValidadeAno = Convert.ToInt32(validade[1]); // int
            //Não é obrigatório segundo o Filipe Wakoo <filipe.wakoo@kogut.com.br>
            transacao.CartaoLogradouro = compra.endereco; // string
            transacao.CartaoLogradouroNumero = compra.numero; // string
            transacao.CartaoCidade = compra.cidade; // string
            transacao.CartaoEstado = compra.uf; // string
            transacao.CartaoCep = compra.cep; // string
            transacao.CartaoParcelas = 1; // int

            #endregion

            //if (!string.IsNullOrEmpty(compra.credid))
            //{
            //    transacao.TransacaoID = Convert.ToInt32(compra.credid);// int
            //}
            //else
            //{
            //    transacao.TransacaoID = 0;// int
            //}
            transacao.TransacaoID = 0; // int

            var json = transacao.ToJson();

            // iniciando objeto de resultado do pagamento
            var resultado = new PagConsorcioRetornoTransacao();

            try
            {
                var UrlApi = string.Format("/api/payment/create-transaction?APIKey={0}&CartaoCSC={1}", apikey,
                    compra.credSegu.toDencod64().RetirarAlfabeto());

                var http = new HttpHelpers(SiteSettings.PAGCONSORCIOSurl, "", "");
                resultado = http.Post<PagConsorcioEnviarTransacao, PagConsorcioRetornoTransacao>(UrlApi, transacao);


                try
                {
                    var HTML = new StringBuilder();
                    HTML.Append("<br />");
                    HTML.Append("TransacaoID: " + resultado.TransacaoID + "<br />");
                    HTML.Append("Codigo: " + resultado.Codigo + "<br />");
                    HTML.Append("Descricao: " + resultado.Descricao + "<br />");
                    HTML.Append("Autorizacao: " + resultado.Autorizacao + "<br />");
                    HTML.Append("Status: " + resultado.Status + "<br />");
                    HTML.Append("TransacaoStatusId: " + resultado.TransacaoStatusId + "<br />");
                    HTML.Append("URL: " + UrlApi + "<br />");


                    var SendSimple = new SendEmailBg();
                    SendSimple.To.Add(SiteSettings.EmailSuporte);
                    SendSimple.CC.Add(SiteSettings.EmailNotificacoes);
                    SendSimple.Subject = "*** Notificação: Pagamento com cartão de crédito - Indicação " + compra.id +
                                         " - Contrato " + compra.id_documento;
                    SendSimple.Body = "<html><body><font color=\"#ff0000\" size=\"3\"><h1>Notificação:</h1>" +
                                      HTML +
                                      "Mais informação no sistema administrativo<br><p>. " +
                                      DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "</p></font></body></html>";
                    SendSimple.StartEmailRun();


                    var interacao = new atendimento();

                    interacao.dt = DateTime.Now;
                    interacao.ip = UserInfo.GetAddressesIP();
                    interacao.indicacoes_id = compra.id;
                    interacao.vendedores_id = 0;
                    interacao.lido = 0;

                    var statusatual = 0; //"Não finalizada"
                    switch (resultado.Status)
                    {
                        case "1": //Transações Criadas
                            statusatual = 0; //  "Não finalizada"
                            break;
                        case "2": //Transações Em Processamento
                            statusatual = 0; //  "Não finalizada"
                            break;
                        case "3": //Transações Autorizadas
                            statusatual = 4; // "Vendidas"
                            break;
                        case "4": //Transações Negadas
                            statusatual =
                                9; //"Falha na Operadora";//A transação não foi autorizada pela operadora. Houve um problema em seu processamento. Final
                            break;
                        case "5": //Transações Canceladas
                            statusatual = 5; //"Canceladas"
                            break;
                        case "6": //Transações Com Erro de TimeOut
                            statusatual = 0; //"Não finalizada"
                            break;
                        case "7": //Transações Com Erro
                            statusatual = 0; //"Não finalizada"
                            break;
                    }

                    interacao.status = statusatual;
                    interacao.dtprevisao = DateTime.Now;
                    interacao.conteudo = HTML + "JSON Enviado: " + json + "<br />";
                    interacao.tipodainteracao = "envio (sistema)"; //envio (externo)

                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
                // return ex.Message;
            }

            return resultado;
        }
    }
}