using System.Collections.Generic;

namespace exp.dados
{
    public class menuadm : entidade
    {
        /// <summary>
        ///     Construtor da classe (inicializa o objeto)
        /// </summary>
        public menuadm()
        {
            //Inicializa as listas
            usuarios = new List<usuario>();
        }


        #region Relacionamentos

        public List<usuario> usuarios { get; set; }

        #endregion

        #region Primitive Properties

        public int? cod_menu_sub { get; set; }

        public string Descricao { get; set; }

        public string Url { get; set; }

        public int? ordem { get; set; }

        public string css { get; set; }

        public int TotalDePosts => usuarios.Count;

        #endregion
    }
}