using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class filiai : entidade
    {
        public filiai()
        {
            data = DateTime.Now;
            vendedores = new List<vendedore>();
        }

        public int site_id { get; set; } // int(1) DEFAULT NULL,
        public string filial { get; set; } // varchar(70) DEFAULT NULL,
        public string email { get; set; } // varchar(70) DEFAULT NULL,
        public string endereco { get; set; } // varchar(50) DEFAULT NULL,
        public string complemento { get; set; } // varchar(50) DEFAULT NULL,
        public string cidade { get; set; } // varchar(50) DEFAULT NULL,
        public string estado { get; set; } // varchar(35) DEFAULT NULL,
        public string cep { get; set; } // varchar(10) DEFAULT NULL,
        public string telefone { get; set; } // varchar(35) DEFAULT NULL,
        public DateTime? data { get; set; } // datetime DEFAULT NULL,
        public bool disponivel { get; set; } // tinyint(1) DEFAULT NULL,
        public bool deletado { get; set; } // tinyint(4) DEFAULT NULL,
        public string descricao { get; set; } // varchar(255) DEFAULT NULL,
        public string tags { get; set; } // varchar(255) DEFAULT NULL,

        #region Relacionamento

        public site site { get; set; }
        public List<vendedore> vendedores { get; set; }

        #endregion
    }
}