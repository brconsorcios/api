using System;

namespace exp.dados
{
    public class vinculovaga
    {
        public int id { get; set; }

        public int id_curriculo { get; set; }

        public int id_vaga { get; set; }

        public int id_site { get; set; }

        public DateTime dt_cadastro { get; set; }


        public curriculo curriculo { get; set; }

        public vaga vaga { get; set; }

        public site site { get; set; }
    }
}