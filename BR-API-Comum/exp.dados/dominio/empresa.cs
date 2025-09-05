using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class empresa
    {
        public empresa()
        {
            dt_cadastro = DateTime.Now;

            bens = new List<ben>();
            sites = new List<site>();
            empprods = new List<empprod>();
        }

        #region Primitive Properties

        public virtual int id { get; set; }
        public virtual string nome { get; set; }
        public virtual string imagem { get; set; }
        public virtual int ordem { get; set; }
        public virtual bool disponivel { get; set; }
        public virtual DateTime? dt_atualizacao { get; set; }
        public virtual DateTime? dt_cadastro { get; set; }
        public virtual string site { get; set; }
        public virtual string pw { get; set; } //senha de acesso

        public virtual int id_ponto_venda { get; set; }
        public virtual int id_comissionado { get; set; }

        #endregion

        #region Relacionamentos

        public List<ben> bens { get; set; }
        public List<empprod> empprods { get; set; }
        public List<site> sites { get; set; }

        #endregion
    }
}