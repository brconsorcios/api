using System;

namespace exp.dados
{
    public class propostaparceria
    {
        public propostaparceria()
        {
            datacadastro = DateTime.Now;
        }

        public int id { get; set; } // int(11) NOT NULL AUTO_INCREMENT,
        public string pes_nome { get; set; } // varchar(150) NOT NULL,
        public string pes_telefone { get; set; } // varchar(20) NOT NULL,
        public string pes_telefone2 { get; set; } // varchar(20) DEFAULT NULL,
        public string pes_email { get; set; } // varchar(150) NOT NULL,
        public string pes_cidade { get; set; } // varchar(100) NOT NULL,
        public string pes_uf { get; set; } // varchar(2) NOT NULL,
        public string emp_nomefantasia { get; set; } // varchar(150) DEFAULT NULL,
        public string emp_razaosocial { get; set; } // varchar(150) DEFAULT NULL,
        public string emp_cidade { get; set; } // varchar(100) DEFAULT NULL,
        public string emp_uf { get; set; } // varchar(2) DEFAULT NULL,
        public string emp_telefone { get; set; } // varchar(20) DEFAULT NULL,
        public string emp_telefone2 { get; set; } // varchar(20) DEFAULT NULL,
        public int site_id { get; set; } // int(11) NOT NULL DEFAULT '0',
        public DateTime datacadastro { get; set; } // datetime DEFAULT NULL,

        /// <summary>
        ///     Campos para atendimento dos chamados
        /// </summary>

        #region RELACIONAMENTO

        public site site { get; set; }

        #endregion
    }
}