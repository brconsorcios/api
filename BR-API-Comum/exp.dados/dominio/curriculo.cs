using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class curriculo
    {
        public curriculo()
        {
            vinculovagas = new List<vinculovaga>();
        }

        public int id { get; set; }

        public string nome { get; set; }

        public string telefone { get; set; }

        public string email { get; set; }

        public string cidade { get; set; }

        public string uf { get; set; }

        public string anexo { get; set; }

        public DateTime dt_cadastro { get; set; }


        public List<vinculovaga> vinculovagas { get; set; }
    }
}