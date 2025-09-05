using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class conteudo : entidade
    {
        /// <summary>
        ///     s
        ///     Construtor da classe (inicializa o objeto)
        /// </summary>
        public conteudo()
        {
            //Atribui a data atual
            //PostadoEm = DateTime.Now;

            dtcriado = DateTime.Now;

            //Inicializa as listas
            conttopicos = new List<conttopico>();
            conteudosanexos = new List<conteudosanexo>();
            //conteditorias = new conteditoria();
            sites = new List<site>();
        }

        public void RemoverTopicos(int Id)
        {
            conttopicos.RemoveAll(c => c.id == Id);
        }

        #region Primitive Properties

        //public string editoria { get; set; }
        public int tipo_id { get; set; }
        public string titulo { get; set; }
        public string secao { get; set; }
        public string sinopse { get; set; }
        public string tags { get; set; }
        public string conteudotexto { get; set; }
        public DateTime dtpublicacao { get; set; }
        public string path { get; set; }
        public bool manchete { get; set; }
        public bool capa { get; set; }
        public int? ordem { get; set; }
        public bool disponivel { get; set; }
        public int? usuario_criador { get; set; }
        public DateTime? dtcriado { get; set; }
        public int? usuario_modificou { get; set; }
        public DateTime? dtmodificado { get; set; }
        public string urlslug { get; set; }

        #endregion

        #region Relacionamentos

        //public List<conttopico> conttopicos { get; set; }
        //public conteditoria conteditorias { get; set; }
        //public List<conteudosanexo> conteudosanexos { get; set; }


        public virtual List<conttopico> conttopicos { get; set; }
        public virtual conteditoria conteditorias { get; set; }
        public virtual List<conteudosanexo> conteudosanexos { get; set; }

        #endregion

        #region Foreign Key

        public int contautores_id { get; set; }
        public int conteditorias_id { get; set; }

        public List<site> sites { get; set; }

        #endregion
    }
}