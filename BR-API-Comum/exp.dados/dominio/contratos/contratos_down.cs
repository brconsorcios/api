using System;

namespace exp.dados
{
    public class contratos_down
    {
        public contratos_down()
        {
            dt = DateTime.Now;
        }

        public int id { get; set; }
        public string grupo { get; set; }
        public int empresa_id { get; set; }
        public string ip { get; set; }
        public DateTime dt { get; set; }
        public string empresa { get; set; }
    }
}