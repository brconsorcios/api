using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class produto
    {
        public produto()
        {
            // dtcriado = DateTime.Now;

            bens = new List<ben>();
            empprods = new List<empprod>();
            bensdiversos = new List<bensdiverso>();
        }

        #region Primitive Properties

        public virtual int id { get; set; }
        public virtual string nome { get; set; }
        public virtual DateTime? dt { get; set; }

        #endregion

        #region Relacionamentos

        public List<ben> bens { get; set; }
        public List<empprod> empprods { get; set; }
        public List<bensdiverso> bensdiversos { get; set; }

        #endregion
    }
}