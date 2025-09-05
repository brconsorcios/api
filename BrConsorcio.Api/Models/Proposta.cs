using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class Proposta
    {
        public int ID_Identificador { get; set; }
        public int ID_Pessoa { get; set; }
        public int ID_Endereco { get; set; }
        public int ID_Telefone { get; set; }
        public int ID_E_Mail { get; set; }
        public string ST_Grupo { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Ponto_Venda { get; set; }
        public int ID_Plano_Venda { get; set; }
        public int ID_Taxa_Plano { get; set; }
        public int PZ_Comercializacao { get; set; }
        public int ID_Tipo_Venda_Grupo { get; set; }
        public int ID_Bem { get; set; }
        public int ID_Grupo { get; set; }
        public string ST_Tipo_Venda { get; set; }
        public string ID_Condicao_Pagto { get; set; }
        public int ID_Comissionado { get; set; }
        public int ID_Reserva { get; set; }
        public int QT_Participante { get; set; }
        public string ID_Forma_Recebimento { get; set; }
        public int ID_Regiao_Fiscal { get; set; }
        public int ID_Empresa { get; set; }
        public string ST_Modalidade { get; set; }
        public string ST_Oferta { get; set; }
        public string SN_Intencao_Lance { get; set; }
        public double PE_Lance_Oferta { get; set; }
        public double VL_Lance_Oferta { get; set; }
        public string SN_Lance_Diluido { get; set; }
        public string CD_Cartao_Credito { get; set; }
        public string CD_Adm_Cartao { get; set; }
        public string NO_Cartao_Credito { get; set; }
        public string ST_Operacao_Cartao { get; set; }
        public int ID_Transacao_Cartao { get; set; }
        public int QT_Parcelamento { get; set; }
        public int ID_Empresa_Recibo { get; set; }
        public int ID_Documento_Recibo { get; set; }
        public int ID_Tipo_Documento_Recibo { get; set; }
        public string Marca_Mobile { get; set; }
        public string Modelo_Mobile { get; set; }
        public string IMEI_Mobile { get; set; }
        public string Versao_SO_Mobile { get; set; }
        public int ID_Conta_Bancaria_Enc { get; set; }
        public int ID_Conta_Bancaria_Debito { get; set; }
        public string SN_Cobranca_Mensal_E_Mail { get; set; }
        public int ID_Documento { get; set; }
        public int ID_Tipo_Documento { get; set; }
    }
}
