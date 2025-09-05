using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class vaga
    {
        public vaga()
        {
            sites = new List<site>();
        }

        public int id { get; set; }

        public string nome { get; set; }

        public int quantidade { get; set; }

        public string requisitos { get; set; }

        public DateTime inicio_publicacao { get; set; }

        public DateTime? fim_publicacao { get; set; }

        public bool disponivel { get; set; }

        public DateTime dt_cadastro { get; set; }


        public List<site> sites { get; set; }

        public List<vinculovaga> vinculovagas { get; set; }
    }
}