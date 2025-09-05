using System;

namespace exp.dados
{
    public class bensvenda : entidade
    {
        public bensvenda()
        {
            dt = DateTime.Now;
        }
        //public int id { get; set; }// int(11) NOT NULL AUTO_INCREMENT,

        public int id_grupo { get; set; } // int(11) NOT NULL,
        public string st_situacao { get; set; } // char(1) NOT NULL,
        public int id_plano_venda { get; set; } // int(11) NOT NULL,
        public int id_taxa_plano { get; set; } // int(11) NOT NULL,
        public int no_assembleia_atual { get; set; } // int(11) NOT NULL,
        public int meses_restantes { get; set; } // int(11) NOT NULL,
        public DateTime? dt_assembleia_atual { get; set; } // datetime NOT NULL,
        public int pz_comercializacao { get; set; } // int(11) NOT NULL,
        public DateTime? dt { get; set; } // datetime NOT NULL,
        public bool disponivel { get; set; }
        public long identificador { get; set; }
        public decimal pe_ta { get; set; }
        public decimal pe_fr { get; set; }
        public decimal pe_sg { get; set; }
        public int indice_reajuste { get; set; }
        public int empresa { get; set; }
        public string nm_caracteristica { get; set; }
        public string sn_produto_principal { get; set; }
        public DateTime? dt_formacao { get; set; }


        #region Relacionamentos

        public bensgrupovenda bensgrupovenda { get; set; }

        #endregion


        #region Foreign Key

        public string cd_grupo { get; set; } // char(6) NOT NULL,

        #endregion
    }
}