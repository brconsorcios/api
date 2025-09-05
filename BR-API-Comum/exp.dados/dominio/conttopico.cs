using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class conttopico : entidade
    {
        /// <summary>
        ///     Construtor da classe (inicializa o objeto)
        /// </summary>
        public conttopico()
        {
            //Inicializa as listas
            conteudos = new List<conteudo>();
        }

        #region Relacionamentos

        public List<conteudo> conteudos { get; set; }

        #endregion

        #region Primitive Properties

        public string topico { get; set; }
        public bool disponivel { get; set; }
        public int? usuario_criador { get; set; }
        public DateTime? data_criado { get; set; }
        public int? usuario_modificou { get; set; }
        public DateTime? data_modificado { get; set; }

        #endregion
    }
}