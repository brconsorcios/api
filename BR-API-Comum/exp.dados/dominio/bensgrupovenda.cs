using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class bensgrupovenda
    {
        public bensgrupovenda()
        {
            dt = DateTime.Now;
            bensvendas = new List<bensvenda>();
            sites = new List<site>();
        }

        public string cd_grupo { get; set; } // char(6) NOT NULL,
        public DateTime? dt { get; set; } // datetime NOT NULL,
        public bool disponivel { get; set; } // tinyint(1) NOT NULL DEFAULT '0',
        public bool tcv { get; set; }
        public bool upgrade { get; set; }
        public bool lancefixo { get; set; }
        public bool lanceintegrado { get; set; }

        public bool sorteiomeupatrimonio { get; set; }
        //public string status { get; set; }// varchar(50) DEFAULT NULL,
        //public Nullable<DateTime> dt_atualizacao { get; set; }// datetime DEFAULT NULL,
        //public string chave { get; set; }// varchar(255) DEFAULT NULL,
        //public long identificador { get; set; }// varchar(50) DEFAULT NULL,


        public List<bensvenda> bensvendas { get; set; }

        public int Total => sites.Count;

        public int exibir { get; set; }

        #region Relacionamentos

        public List<site> sites { get; set; }

        #endregion

        public int TotalItens => bensvendas.Count;
    }
}