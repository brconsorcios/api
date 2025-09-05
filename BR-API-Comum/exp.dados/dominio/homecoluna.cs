using System;

namespace exp.dados
{
    public class homecoluna : entidade
    {
        public homecoluna()
        {
            data_criado = DateTime.Now;
        }

        #region Relacionamentos

        public site site { get; set; }

        #endregion

        #region Primitive Properties

        public virtual int? coluna { get; set; }

        public virtual string titulo { get; set; }

        public virtual string palavra { get; set; }

        public virtual string texto { get; set; }

        public virtual string w { get; set; }

        public virtual string h { get; set; }

        public virtual string url { get; set; }

        public bool alvo { get; set; }

        public virtual int? ordem { get; set; }

        public bool disponivel { get; set; }


        public virtual string extencao { get; set; }

        public virtual int? tempo { get; set; }

        public virtual int? usuario_criador { get; set; }

        public virtual DateTime? data_criado { get; set; }

        public virtual int? usuario_modificou { get; set; }

        public virtual DateTime? data_modificado { get; set; }

        public virtual int? id_site { get; set; }

        #endregion
    }
}