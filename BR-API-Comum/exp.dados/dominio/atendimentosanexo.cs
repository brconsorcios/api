using System;

namespace exp.dados
{
    public class atendimentosanexo : entidade
    {
        /// <summary>
        ///     Construtor da classe (inicializa o objeto)
        /// </summary>
        public atendimentosanexo()
        {
            //Atribui a data atual
            //PostadoEm = DateTime.Now;

            data = DateTime.Now;

            //Inicializa as listas
            //conteudos = new List<conteudo>();
        }


        #region Relacionamentos

        public atendimento atendimento { get; set; }

        #endregion


        #region Foreign Key

        public int atendimentos_id { get; set; }

        #endregion

        #region Primitive Properties

        public virtual string datasize { get; set; }
        public virtual string contenttype { get; set; }
        public virtual string filename { get; set; }
        public virtual string path { get; set; }
        public virtual DateTime data { get; set; }
        public virtual int? ordem { get; set; }
        public virtual string exten { get; set; }

        #endregion
    }
}