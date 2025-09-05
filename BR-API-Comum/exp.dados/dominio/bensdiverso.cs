using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class bensdiverso
    {
        public bensdiverso()
        {
            dtcriado = DateTime.Now;
            sites = new List<site>();
        }

        #region Properties

        public virtual int id { get; set; }
        public virtual int produtos_id { get; set; }
        public virtual string img { get; set; }
        public virtual string cd_bem { get; set; }
        public virtual string nm_bem { get; set; }
        public virtual decimal? vl_bem { get; set; }
        public virtual short? pz_comercializacao { get; set; }
        public virtual decimal? vl_parcela { get; set; }
        public virtual string nm_fabricante { get; set; }
        public virtual DateTime? dtatualizado { get; set; }
        public virtual DateTime? dtcriado { get; set; }
        public virtual string tx_adm { get; set; }
        public virtual string fd_reserva { get; set; }
        public virtual string seguro { get; set; }
        public virtual string st_situacao { get; set; }
        public virtual bool disponivel { get; set; }

        #endregion

        #region Relacionamentos

        public produto produto { get; set; }
        public List<site> sites { get; set; }

        #endregion
    }
}