using System;

namespace exp.dados
{
    public class parceiro_vendas
    {
        public parceiro_vendas()
        {
            criadoem = DateTime.Now;
        }

        public int id_usuario { get; set; }
        public string sh { get; set; }
        public string cd_usuario { get; set; }
        public string objeto { get; set; }
        public int visitas { get; set; }
        public DateTime criadoem { get; set; }
        public DateTime atualizadoem { get; set; }
        public string ip { get; set; }
    }
}