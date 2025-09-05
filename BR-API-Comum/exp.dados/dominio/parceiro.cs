using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class parceiro : entidade
    {
        public parceiro()
        {
            indicacoes = new List<indicaco>();
        }

        //public string id { get; set; } // int(11) NOT NULL DEFAULT '0',
        public string nmempresa { get; set; } // varchar(70) DEFAULT NULL,
        public string urlsite { get; set; } // varchar(100) DEFAULT NULL,
        public string contato { get; set; } // varchar(50) DEFAULT NULL,
        public string emailcontato { get; set; } // varchar(70) DEFAULT NULL,
        public string login { get; set; } // varchar(20) DEFAULT NULL,
        public string telefone { get; set; } // varchar(15) DEFAULT NULL,
        public string endereco { get; set; } // varchar(50) DEFAULT NULL,
        public string numero { get; set; } // varchar(5) DEFAULT NULL,
        public string complemento { get; set; } // varchar(50) DEFAULT NULL,
        public string bairro { get; set; } // varchar(50) DEFAULT NULL,
        public string cidade { get; set; } // varchar(50) DEFAULT NULL,
        public string uf { get; set; } // varchar(2) DEFAULT NULL,
        public decimal? valorfixomensal { get; set; } // decimal(18,2) DEFAULT NULL,
        public string termonegociacao { get; set; } // longtext,
        public string percentualcomissao { get; set; } // varchar(6) DEFAULT NULL,
        public DateTime? dt { get; set; } // datetime DEFAULT NULL,
        public DateTime? dataacesso { get; set; } // datetime DEFAULT NULL,
        public int? numacesso { get; set; } // int(11) DEFAULT NULL,
        public bool disponivel { get; set; } // tinyint(1) DEFAULT NULL,
        public string senha { get; set; } // varchar(20) DEFAULT NULL,


        public List<indicaco> indicacoes { get; set; }
    }
}