using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class PropostaModel
    {
        public int IdUsuario { get; set; }
                                           //  public string IdIdentificador { get; set; }//>int</ID_Identificador>
        public int IdPessoa { get; set; }//>int</ID_Pessoa>
        public int IdEndereco { get; set; }//>int</ID_Endereco>
        public int IdTelefone { get; set; }//>int</ID_Telefone>
    //    public string IdFax { get; set; }//>int</ID_Fax>
        public int IdEMail { get; set; }//>int</ID_E_Mail>
        //public string IdContaBancaria { get; set; }//>int</ID_Conta_Bancaria>
        //public string DiaDebito { get; set; }//>int</Dia_Debito>
        //public string SnDiaUtilDebito { get; set; }//>string</SN_Dia_Util_Debito>
        public string StGrupo { get; set; }//>string</ST_Grupo>
        public int IdProduto { get; set; }//>int</ID_Produto>
        public int IdPontoVenda { get; set; }//>int</ID_Ponto_Venda>
        public int IdPlanoVenda { get; set; }//>int</ID_Plano_Venda>
        public int IdTaxaPlano { get; set; }//>int</ID_Taxa_Plano>
        public int PzComercializacao { get; set; }//>int</PZ_Comercializacao>
        public int IdTipoVendaGrupo { get; set; }//>int</ID_Tipo_Venda_Grupo>
        public int IdBem { get; set; }//>int</ID_Bem>
        public int IdGrupo { get; set; }//>int</ID_Grupo>
        public string StTipoVenda { get; set; }//>string</ST_Tipo_Venda>
        //public string IdCondicaoPagto { get; set; }//>string</ID_Condicao_Pagto>
        //public string SnAprovada { get; set; }//>string</SN_Aprovada>
        public int IdComissionado { get; set; }//>int</ID_Comissionado>
        public int IdPontoEntrega { get; set; }//>int</ID_Ponto_Entrega>
        //public string StTipoCliente { get; set; }//>string</ST_Tipo_Cliente>
        //public string StTipoAgencia { get; set; }//>string</ST_Tipo_Agencia>
        //public string CdAgenciaLogin { get; set; }//>string</CD_Agencia_Login>
        //public string IdReserva { get; set; }//>int</ID_Reserva>
        //public string IdCONPV007 { get; set; }//>int</ID_CONPV007>
        public int QtParticipante { get; set; }//>int</QT_Participante>
        public string IdFormaRecebimento { get; set; }//>string</ID_Forma_Recebimento>
        public int IdRegiaoFiscal { get; set; }//>int</ID_Regiao_Fiscal>
        public int IdEmpresa { get; set; }//>int</ID_Empresa>
        public string CdUnidadeNegocioParceiro { get; set; }//>string</ID_Empresa>


    }
}
