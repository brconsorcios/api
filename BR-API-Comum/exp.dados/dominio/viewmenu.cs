using System;

namespace exp.dados
{
    public class viewmenu
    {
        public virtual string produto { get; set; }
        public virtual int empresas_id { get; set; }
        public virtual int produtos_id { get; set; }
        public virtual int identificador { get; set; }


        public virtual string chave { get; set; }
        public virtual int ordem { get; set; }
        public virtual bool disponivel { get; set; }
        public virtual DateTime? dt_atualizacao { get; set; }
        public virtual string qtderegistro { get; set; }
        public virtual string qtdeprod { get; set; }
    }
}