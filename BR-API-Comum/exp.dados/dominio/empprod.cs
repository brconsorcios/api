using System;

namespace exp.dados
{
    public class empprod
    {
        #region Primitive Properties

        public virtual int produtos_id { get; set; }
        public virtual int empresas_id { get; set; }
        public int identificador { get; set; }
        public string chave { get; set; }
        public string status { get; set; }
        public int ordem { get; set; }
        public bool disponivel { get; set; }
        public virtual DateTime? dt_atualizacao { get; set; }
        public virtual string st_negociacao { get; set; }

        #endregion


        #region Relacionamentos

        public produto produto { get; set; }
        public empresa empresa { get; set; }

        #endregion
    }
}