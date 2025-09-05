using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class BenDetalheModel
    {

        public Bem bem { get; set; }
        public BemTaxas viewtaxas { get; set; }



        public decimal petaplano()
        {
            return bem.pe_ta;
        }
        public decimal pzcom()
        {
            return !bem.pz_comercializacao.HasValue ? (decimal)0 : Convert.ToDecimal(bem.pz_comercializacao);
        }
        public decimal TxAdmMes()
        {
            return (Convert.ToDecimal(bem.pe_ta) / Convert.ToDecimal(bem.meses_restantes));
        }
        public decimal TxFndReservaMes()
        {
            return (Convert.ToDecimal(bem.pe_fr) / Convert.ToDecimal(bem.meses_restantes));
        }
        public decimal AnoPlano()
        {
            return decimal.Divide(bem.meses_restantes, 12M);
        }


        //public decimal petaplano()
        //{
        //    return String.IsNullOrEmpty(viewtaxas.PE_TA_Plano) ? (decimal)0 : Convert.ToDecimal(viewtaxas.PE_TA_Plano);
        //}
        //public decimal pzcom()
        //{
        //    return !ben.pz_comercializacao.HasValue ? (decimal)0 : Convert.ToDecimal(ben.pz_comercializacao);
        //}
        //public decimal TxAdmMes()
        //{
        //    return (Convert.ToDecimal(viewtaxas.PE_TA_Plano) / Convert.ToDecimal(ben.meses_restantes));
        //}
        //public decimal TxFndReservaMes()
        //{
        //    return (Convert.ToDecimal(viewtaxas.PE_FR_Plano) / Convert.ToDecimal(ben.meses_restantes));
        //}
        //public decimal AnoPlano()
        //{
        //    return decimal.Divide(ben.meses_restantes, 12M);
        //}



    }

    //public class BenDetalheModelAnt
    //{

    //    public viewbemantigo ben { get; set; }
    //    public viewtaxas viewtaxas { get; set; }

    //}
    public class BenIndicacaoModel
    {
        //Continua sendo urilizado por calsa das views
        //mas pode ser eliminado na primeira oportunidade
        //public viewben ben { get; set; }
        public Indicaco indicacao { get; set; }
        //public viewtaxas viewtaxas { get; set; }
    }
}
