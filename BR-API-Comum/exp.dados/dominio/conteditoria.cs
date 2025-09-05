using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class conteditoria : entidade
    {
        /// <summary>
        ///     Construtor da classe (inicializa o objeto)
        /// </summary>
        public conteditoria()
        {
            //Atribui a data atual
            data_criado = DateTime.Now;

            //Inicializa as listas
            conteudos = new List<conteudo>();
        }

        #region Relacionamentos

        public List<conteudo> conteudos { get; set; }

        #endregion

        #region Primitive Properties

        public virtual string editoria { get; set; }

        public bool disponivel { get; set; }

        public virtual int? usuario_criador { get; set; }

        public virtual DateTime? data_criado { get; set; }

        public virtual int? usuario_modificou { get; set; }

        public virtual DateTime? data_modificado { get; set; }

        #endregion
    }
}