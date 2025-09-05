using System;

namespace exp.dados
{
    public class planovendasite
    {
        public int id_plano_venda_site { get; set; }

        //public int id_site { get; set; }
        public int id_unidade_negocio { get; set; }
        public string cd_unidade_negocio { get; set; }
        public int id_plano_venda { get; set; }
        public DateTime dt_inicio_vigencia { get; set; }
        public DateTime dt_final_vigencia { get; set; }
    }
}