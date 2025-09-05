using System;
using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models
{
    public class Indicaco
    {
        public Indicaco()
        {
            if (string.IsNullOrEmpty(id_forma_recebimento))
            {
                id_forma_recebimento = "BB"; //Definindo BB Emissao Bancário como padrão
            }

            //atendimentos = new List<atendimento>();
            // parceiro = new parceiro();
            // site = new site();
            // vendedore = new vendedore();
            vendedores_id = 1; //vendedor defalut
            pgto_parceiro = true; //define se o pagamento será feito pelo parceiro ou pelo cliente.
            datacadastro = DateTime.Now;
        }

        public int id { get; set; }
        public int? id_regiao_fiscal { get; set; }
        public DateTime? datavisita { get; set; }
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Display(Name = "Celular")]
        public string celular { get; set; }
        [Display(Name = "Fax")]
        public string fax { get; set; }
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
        [Display(Name = "DDD")]
        public string ddd { get; set; }
        public string codpais { get; set; }
        [Display(Name = "País")]
        public string pais { get; set; }
        [Display(Name = "Cep")]
        public string cep { get; set; }
        [Display(Name = "UF")]
        public string uf { get; set; }
        [Display(Name = "Cidade")]
        public string cidade { get; set; }
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        [Display(Name = "Número")]
        public string numero { get; set; }
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
        [Display(Name = "Profissão")]
        public string profissao { get; set; }
        [Display(Name = "RG")]
        public string rg { get; set; }
        [Display(Name = "Contato")]
        public string contato { get; set; }
        public string nome { get; set; }
        public DateTime? datacompra { get; set; }
        public int? id_pessoa { get; set; }
        public int? id_documento { get; set; }
        public int? id_tipo_documento { get; set; }
        //public parceiro parceiro { get; set; }
        //public site site { get; set; }
        public int? id_site { get; set; }
        [Display(Name = "Assunto")]
        public string assunto { get; set; }
        public sbyte? ger_recebido { get; set; }
        public sbyte? ven_recebido { get; set; }
        public DateTime? ven_dtenvio { get; set; }
        public DateTime? previsao { get; set; }
        public bool pgto_parceiro { get; set; }
        [Display(Name = "Nome no Cartão")]
        public string nome_resp { get; set; }
        [Display(Name = "Bandeira do Cartão")]
        public string credtipo { get; set; }
        [Display(Name = "Código de Segurança do Cartão")]
        public string credSegu { get; set; }
        [Display(Name = "CPF do Titular do Cartão")]
        public string credcpf { get; set; }
        [Display(Name = "Data de vencimento do Cartão")]
        public string credvenc { get; set; }
        public string retornopgtojson { get; set; }
        [Display(Name = "Status do pagamento")]
        public int statuspgto { get; set; }
        public string credid { get; set; }
        [Display(Name = "Número do Cartão")]
        public string cred { get; set; }
        public string id_forma_recebimento { get; set; }
        public string cpfcnpj { get; set; }
        public int id_grupo { get; set; }
        //  public List<atendimento> atendimentos { get; set; }
        public int? id_tipo_venda_grupo { get; set; }
        public decimal? vl_ta_inscricao { get; set; }
        public decimal? vl_parcela { get; set; }
        public decimal? vl_bem { get; set; }
        public string pz_comercializacao { get; set; }
        public string nm_bem { get; set; }
        public int? id_bem { get; set; }
        public int id_comissionado { get; set; }
        public int id_ponto_venda { get; set; }
        // public vendedore vendedore { get; set; }
        public int id_adm { get; set; }
        public int? codigo_campanha { get; set; }
        public int? parceiros_id { get; set; }
        public string comentario { get; set; }
        public string formaContato { get; set; }
        public DateTime? datacadastro { get; set; }
        public string vendedor { get; set; }
        public int? status { get; set; }
        public int? vendedores_id { get; set; }
        public int? tipo_indicacao { get; set; }
        public int id_usuario { get; set; }
        public string faixa_pe_fc { get; set; }
        public string faixa_valores { get; set; }
        public decimal? pe_fc { get; set; }
        public int? id_taxa_plano { get; set; }
        public int? id_plano_venda { get; set; }
        public int? id_produto { get; set; }
        public string cd_grupo { get; set; }
        public string st_grupo { get; set; }
        public string indice_reajuste { get; set; }
        public int meses_restante { get; set; }
        public string faixa_ta { get; set; }
        public int? qt_participante { get; set; }
        public string nm_fabricante { get; set; }
        public int? no_parcela_inicial { get; set; }
        public string nm_plano_venda { get; set; }
        public string cd_plano_venda { get; set; }
        public decimal? pe_ta { get; set; }
        public decimal? pe_sg { get; set; }
        public decimal? pe_fr_plano { get; set; }
        public decimal? pe_ta_plano { get; set; }
        public decimal? pe_ta_inscricao { get; set; }
        public int? no_parcela_final { get; set; }

        public string StatusPagamento()
        {
            switch (statuspgto)
            {
                case 1:
                    return "Autorizado e Confirmado"; //A transação está paga. Final
                case 2:
                    return "Autorizado";//A transação ainda será capturada na operadora. Transitório
                case 3:
                    return "Não Autorizado";//A transação foi negada pela operadora.Final
                case 5:
                    return "Transação em Andamento";//A transação está em andamento.Transitório
                case 6:
                    return "Boleto em Compensação";//A transação ainda não está paga, boleto está em processo de compensação / baixa.Transitório
                case 8:
                    return "Aguardando Pagamento";//A transação está no SuperPay, aguardando o pagamento ou pedidos em processo de retentativa.Transitório
                case 9:
                    return "Falha na Operadora";//A transação não foi autorizada pela operadora. Houve um problema em seu processamento. Final
                case 13:
                    return "Cancelado";//A transação foi cancelada na adquirente. Final
                case 14:
                    return "Estornada";//A venda foi cancelada totalmente na adquirente. Final
                case 15:
                    return "Em Análise de Risco";//A transação foi enviada para o sistema de análise de riscos / fraudes. Resposta ainda não foi enviada pelo analisador. Transitório
                case 17:
                    return "Recusado Análise de Risco";//A transação foi negada pelo sistema análise de Risco / Fraude. Final
                case 18:
                    return "Falha no envio para Análise de Risco";//Falha. Não foi possível enviar pedido para a análise de Risco / Fraude, porém será reenviada. Transitório
                case 21:
                    return "Boleto Pago a menor";//O boleto está pago com valor divergente do emitido. Final
                case 22:
                    return "Boleto Pago a maior";//O boleto está pago com valor divergente do emitido. Final
                case 23:
                    return "Estorno Parcial";//A venda foi cancelada na adquirente parcialmente. Final
                case 30:
                    return "Operação em andamento";//Transação em curso de pagamento. Transitório
                case 31:
                    return "Transação já efetuada";//Transação já efetuada e efetivada com status final. Final
                default:
                    return "";
            }
        }
    }
}
