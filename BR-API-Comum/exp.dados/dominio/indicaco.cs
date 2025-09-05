using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class indicaco : entidade
    {
        public indicaco()
        {
            if (string.IsNullOrEmpty(id_forma_recebimento))
                id_forma_recebimento = "BB"; //Definindo BB Emissao Bancário como padrão

            atendimentos = new List<atendimento>();
            // parceiro = new parceiro();
            // site = new site();
            // vendedore = new vendedore();
            vendedores_id = 1; //vendedor defalut
            pgto_parceiro = true; //define se o pagamento será feito pelo parceiro ou pelo cliente.
            datacadastro = DateTime.Now;
        }

        public int? id_site { get; set; } // empresa
        public string cd_unidade_negocio_parceiro { get; set; }
        public string contadeposito { get; set; }


        public bool? sou_cliente { get; set; }
        public int? cod_assunto { get; set; }

        public string endereco_ip { get; set; }

        public bool ignorar_verificacao_venda_indicada { get; set; }

        public string StatusPagamento()
        {
            switch (statuspgto)
            {
                case 1:
                    return "Autorizado e Confirmado"; //A transação está paga. Final
                case 2:
                    return "Autorizado"; //A transação ainda será capturada na operadora. Transitório
                case 3:
                    return "Não Autorizado"; //A transação foi negada pela operadora.Final
                case 5:
                    return "Transação em Andamento"; //A transação está em andamento.Transitório
                case 6:
                    return
                        "Boleto em Compensação"; //A transação ainda não está paga, boleto está em processo de compensação / baixa.Transitório
                case 8:
                    return
                        "Aguardando Pagamento"; //A transação está no SuperPay, aguardando o pagamento ou pedidos em processo de retentativa.Transitório
                case 9:
                    return
                        "Falha na Operadora"; //A transação não foi autorizada pela operadora. Houve um problema em seu processamento. Final
                case 13:
                    return "Cancelado"; //A transação foi cancelada na adquirente. Final
                case 14:
                    return "Estornada"; //A venda foi cancelada totalmente na adquirente. Final
                case 15:
                    return
                        "Em Análise de Risco"; //A transação foi enviada para o sistema de análise de riscos / fraudes. Resposta ainda não foi enviada pelo analisador. Transitório
                case 17:
                    return
                        "Recusado Análise de Risco"; //A transação foi negada pelo sistema análise de Risco / Fraude. Final
                case 18:
                    return
                        "Falha no envio para Análise de Risco"; //Falha. Não foi possível enviar pedido para a análise de Risco / Fraude, porém será reenviada. Transitório
                case 21:
                    return "Boleto Pago a menor"; //O boleto está pago com valor divergente do emitido. Final
                case 22:
                    return "Boleto Pago a maior"; //O boleto está pago com valor divergente do emitido. Final
                case 23:
                    return "Estorno Parcial"; //A venda foi cancelada na adquirente parcialmente. Final
                case 30:
                    return "Operação em andamento"; //Transação em curso de pagamento. Transitório
                case 31:
                    return "Transação já efetuada"; //Transação já efetuada e efetivada com status final. Final
                default:
                    return "";
            }
        }


        public string StatusAtendimentos()
        {
            switch (status)
            {
                case 0:
                    return "NÃO FINALIZADAS";
                case 1:
                    return "NOVAS";
                case 2:
                    return "NEGOCIAÇÃO";
                case 3:
                    return "AGENDADAS";
                case 4:
                    return "VENDIDAS";
                case 5:
                    return "CANCELADAS";
                default:
                    return "NÃO FINALIZADAS";
            }
        }


        public string DescricaoTipoIndicacao()
        {
            switch (tipo_indicacao)
            {
                case 0:
                    return "Cliente não finalizou";
                case 1:
                    return "Quero Comprar pela Internet";
                case 2:
                    return "Quero Receber uma visita";
                case 3:
                    return "Quero Receber uma ligação";
                case 4:
                    return "Quero Receber um E-mail";
                case 5:
                    return "Fale Conosco";
                case 6:
                    return "Ligamos para você";
                case 7:
                    return "Email ou Telefone - Meu Patrimônio";
                case 8:
                    return "Agenda - Meu Patrimônio";
                case 9:
                    return "Fale Fácil";
                case 10:
                    return "Compra Rápida";
                case 20:
                    return "Simulação - Hotsite Sinnapse";
                case 21:
                    return "Fale Conosco - Hotsite Sinnapse";
                case 22:
                    return "Black Friday 2017";
                case 23:
                    return "Simulação - Hotsite Giacometti";
                case 24:
                    return "Ligamos para você - Hotsite Giacometti";
                case 25:
                    return "Mande sua duvida - Hotsite Giacometti";
                case 26:
                    return "Preciso de ajuda - Hotsite Giacometti";
                case 27:
                    return "Venda Online da Desencana";
                default:
                    return string.Empty;
            }
        }

        public string DescricaoFormadePgto()
        {
            switch (id_forma_recebimento)
            {
                case "BB":
                    return "Boleto Bancário";
                case "DB":
                    return "Débito Automático";
                case "CC":
                    return "Cartão de Crédito";
                default:
                    return "Boleto Bancário";
            }
        }

        /// <summary>
        ///     Campos comuns de todos os tipos de contatos e indicações
        /// </summary>

        #region CAMPOS COMUNS

        //public int id { get; set; }
        public int? tipo_indicacao { get; set; } //ok 

        public int? vendedores_id { get; set; } //ok
        public int? status { get; set; } //ok
        public string vendedor { get; set; } //Cliente preenche o nome do vendedor
        public DateTime? datacadastro { get; set; }
        public string comentario { get; set; }

        #endregion

        /// <summary>
        ///     Campos para parceiros e campanhas
        /// </summary>

        #region PARCEIROS E CAMPANHAS

        public int? parceiros_id { get; set; } //estudar para remover

        public int? codigo_campanha { get; set; } //ok

        #endregion

        /// <summary>
        ///     Integração com venda parceiro
        /// </summary>

        #region Venda Parceiro e vendedor CNP

        public int id_usuario { get; set; }

        public int id_adm { get; set; }
        public int id_ponto_venda { get; set; }
        public int id_comissionado { get; set; }

        #endregion


        /// <summary>
        ///     Campos para descricao do bem escolhido
        /// </summary>

        #region BEM ESCOLHIDO

        public int? id_bem { get; set; }

        public string nm_bem { get; set; } //ok BemEscolhido
        public string pz_comercializacao { get; set; } //ok plano
        public decimal? vl_bem { get; set; } //ok credito
        public decimal? vl_parcela { get; set; } //ok parcelamensal

        public decimal? vl_ta_inscricao { get; set; }
        public string faixa_valores { get; set; }
        public string faixa_pe_fc { get; set; }
        public string faixa_ta { get; set; }

        public decimal? pe_fc { get; set; }
        public decimal? pe_ta_inscricao { get; set; }

        public decimal? pe_ta_plano { get; set; }
        public decimal? pe_fr_plano { get; set; }
        public decimal? pe_sg { get; set; }
        public decimal? pe_ta { get; set; }


        public string cd_plano_venda { get; set; }
        public string nm_plano_venda { get; set; }
        public int? no_parcela_inicial { get; set; }
        public int? no_parcela_final { get; set; }
        public int? qt_participante { get; set; }
        public string nm_fabricante { get; set; }

        public int meses_restante { get; set; }
        public string indice_reajuste { get; set; }
        public string st_grupo { get; set; }
        public string cd_grupo { get; set; }


        public int? id_produto { get; set; }
        public int? id_plano_venda { get; set; }
        public int? id_taxa_plano { get; set; }
        public int? id_tipo_venda_grupo { get; set; }
        public int? id_regiao_fiscal { get; set; }

        public int id_grupo { get; set; }

        #endregion

        /// <summary>
        ///     Campos para cadastro da pessoa do cliente
        ///     quando o tipo não for compra pela internet
        ///     ou simplesmente através do fale conosco
        /// </summary>

        #region CADASTRO PESSOA DO CLIENTE

        public string cpfcnpj { get; set; }

        //[Display(Name = "Nome")]
        public string nome { get; set; } //ok

        [Display(Name = "Contato")] public string contato { get; set; } //ok

        [Display(Name = "RG")] public string rg { get; set; } //ok

        [Display(Name = "Profissão")] public string profissao { get; set; }

        [Display(Name = "Endereço")] public string endereco { get; set; }

        [Display(Name = "Número")] public string numero { get; set; }

        [Display(Name = "Complemento")] public string complemento { get; set; }

        [Display(Name = "Bairro")] public string bairro { get; set; }

        [Display(Name = "Cidade")] public string cidade { get; set; }

        [Display(Name = "cd_cidade")] public int? cd_cidade { get; set; }

        [Display(Name = "UF")] public string uf { get; set; }

        [Display(Name = "Cep")] public string cep { get; set; }

        [Display(Name = "País")] public string pais { get; set; }

        public string codpais { get; set; }

        [Display(Name = "DDD")] public string ddd { get; set; }

        [Display(Name = "Telefone")] public string telefone { get; set; }

        [Display(Name = "Fax")] public string fax { get; set; }

        [Display(Name = "Celular")] public string celular { get; set; }

        [Display(Name = "E-mail")] public string email { get; set; }

        #endregion


        /// <summary>
        ///     Campos para tipos de indicações diferente
        /// </summary>

        #region INDICACOES DIFERENTE

        public DateTime? datavisita { get; set; }

        public DateTime? datacompra { get; set; }

        public int? id_pessoa { get; set; }
        //public Nullable<int> id_identificador { get; set; }

        #endregion


        /// <summary>
        ///     Dados para emissão do contrato
        /// </summary>

        #region CONTRATO

        public int? id_documento { get; set; }

        public int? id_tipo_documento { get; set; }
        public string id_forma_recebimento { get; set; }

        #endregion

        /// <summary>
        ///     Campos para Pagamento com cartão de crédito
        /// </summary>

        #region PAGAMENTO CARTÃO DE CRÉDITO

        [Display(Name = "Número do Cartão")]
        public string cred { get; set; }

        public string credid { get; set; }

        [Display(Name = "Status do pagamento")]
        public int statuspgto { get; set; }

        public string retornopgtojson { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        public string credvenc { get; set; }

        [Display(Name = "CPF do Titular do Cartão")]
        public string credcpf { get; set; }

        [Display(Name = "Código de Segurança do Cartão")]
        public string credSegu { get; set; }

        [Display(Name = "Bandeira do Cartão")] public string credtipo { get; set; }

        [Display(Name = "Nome no Cartão")] public string nome_resp { get; set; }

        public bool pgto_parceiro { get; set; }

        #endregion


        /// <summary>
        ///     Campos para atendimento dos chamados
        /// </summary>

        #region ATENDIMENTO AO CLIENTE

        public DateTime? previsao { get; set; }

        public DateTime? ven_dtenvio { get; set; }
        public sbyte? ven_recebido { get; set; }
        public sbyte? ger_recebido { get; set; }

        [Display(Name = "Assunto")] public string assunto { get; set; }

        #endregion

        /// <summary>
        ///     Campos para atendimento dos chamados
        /// </summary>

        #region RELACIONAMENTO

        public site site { get; set; }

        public parceiro parceiro { get; set; }
        public vendedore vendedore { get; set; }
        public List<atendimento> atendimentos { get; set; }

        #endregion
    }
}