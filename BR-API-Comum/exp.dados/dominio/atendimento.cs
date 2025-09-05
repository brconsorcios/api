using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class atendimento : entidade
    {
        public atendimento()
        {
            //indicaco = new indicaco();
            atendimentosanexos = new List<atendimentosanexo>();
            // vendedore = new vendedore();
        }

        //public int id { get; set; } // int(11) NOT NULL AUTO_INCREMENT,
        public int vendedores_id { get; set; } // int(11) DEFAULT NULL,
        public int indicacoes_id { get; set; } // int(11) DEFAULT NULL,
        public DateTime? dt { get; set; } // datetime DEFAULT NULL,
        public int status { get; set; } // int(11) DEFAULT NULL,
        public int lido { get; set; } // int(11) DEFAULT NULL,
        public DateTime? datalido { get; set; } // datetime DEFAULT NULL,
        public string conteudo { get; set; } // longtext,
        public string ip { get; set; } // varchar(40) DEFAULT NULL,
        public string anexo { get; set; } // varchar(50) DEFAULT NULL,
        public DateTime? dtprevisao { get; set; } // datetime DEFAULT NULL,
        public string satisfacao { get; set; } // varchar(20) DEFAULT NULL,
        public string tipodainteracao { get; set; } // varchar(20) DEFAULT NULL,


        public indicaco indicaco { get; set; }
        public vendedore vendedore { get; set; }
        public virtual List<atendimentosanexo> atendimentosanexos { get; set; }

        public string TipoDaInteracao()
        {
            switch (tipodainteracao)
            {
                case "resposta (interno)":
                    return "#0000";
                case "resposta (externa)":
                    return "#0000";
                case "sistema":
                    return "#0000";
                case "envio (interno)":
                    return "#0000";
                case "envio (externo)":
                    return "#0000";
                default:
                    return "#0000"; // resposta (interno)
            }
        }

        public string Status()
        {
            switch (status)
            {
                case 0:
                    return "Não finalizada";
                case 1:
                    return "Nova";
                case 2:
                    return "Em andamento";
                case 4:
                    return "Vendidas";
                case 5:
                    return "Canceladas";
                default:
                    return "Não finalizada";
            }
        }
    }
}