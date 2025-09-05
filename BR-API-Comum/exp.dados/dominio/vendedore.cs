using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class vendedore : entidade
    {
        public vendedore()
        {
            dt = DateTime.Now;
            atendimentos = new List<atendimento>();
            indicacoes = new List<indicaco>();
        }

        //public int id { get; set; }// int(1) NOT NULL DEFAULT '0',
        public int filiais_id { get; set; } // int(1) DEFAULT NULL,
        public int tipo_id { get; set; } // int(1) DEFAULT NULL,
        public string nome { get; set; } // varchar(80) DEFAULT NULL,
        public string email { get; set; } // varchar(70) DEFAULT NULL,
        public string telefone { get; set; } // varchar(35) DEFAULT NULL,
        public string celular { get; set; } // varchar(35) DEFAULT NULL,
        public string Login { get; set; } // varchar(10) DEFAULT NULL,
        public string Senha { get; set; } // varchar(32) DEFAULT NULL,
        public bool disponivel { get; set; } // tinyint(1) DEFAULT NULL,
        public DateTime? dataacesso { get; set; } // datetime DEFAULT NULL,
        public int numacesso { get; set; } // int(11) DEFAULT NULL,
        public bool deletado { get; set; } // tinyint(1) DEFAULT NULL,
        public string cd_usuario { get; set; } // char(10) DEFAULT NULL,
        public string cd_usuario_externo { get; set; } // varchar(30) DEFAULT NULL,
        public int? id_usuario { get; set; } // int(11) DEFAULT NULL,
        public int? id_ponto_venda { get; set; } // int(11) DEFAULT NULL,
        public int? id_comissionado { get; set; } // int(11) DEFAULT NULL,
        public DateTime? dt { get; set; } // datetime DEFAULT NULL,

        #region Relacionamento

        public filiai filiai { get; set; }
        public List<atendimento> atendimentos { get; set; }
        public List<indicaco> indicacoes { get; set; }


        //Cargos:  1 = Gerente 2 = Supervisor de Venda 3 = Administrativa 4 = Vendedor
        public string TipoVendedor()
        {
            switch (tipo_id)
            {
                case 1:
                    return "Gerente";
                case 2:
                    return "Supervisor de Venda";
                case 3:
                    return "Administrativa";
                //ve todas da filial
                case 4:
                    return "Vendedor";
                // so ve as indicações reacionadas a ele
                default:
                    return "Não identificado";
            }
        }

        #endregion
    }
}