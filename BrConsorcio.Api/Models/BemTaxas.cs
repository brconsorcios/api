using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class BemTaxas
    {
        public Nullable<decimal> VL_Bem { get; set; }
        public Nullable<decimal> VL_TA_Inscricao { get; set; }
        public string Faixa_Valores { get; set; }
        public string PE_FC { get; set; }
        public string Faixa_PE_FC { get; set; }
        public string PE_TA_Inscricao { get; set; }
        public string Faixa_TA { get; set; }
        public string PE_TA_Plano { get; set; }
        public string PE_FR_Plano { get; set; }
        public string PE_SG { get; set; }
        public string PE_TA { get; set; }
        public Nullable<decimal> VL_Parcela_F { get; set; }
        public Nullable<decimal> VL_Parcela_J { get; set; }
        public string CD_Plano_Venda { get; set; }
        public string NM_Plano_Venda { get; set; }
        public string NO_Parcela_Inicial { get; set; }
        public string NO_Parcela_Final { get; set; }
        public string PZ_Comercializacao { get; set; }
        public string QT_Participante { get; set; }
        public string NM_Bem { get; set; }
        public string NM_Fabricante { get; set; }
        public string ErrMsg { get; set; }
    }
}
