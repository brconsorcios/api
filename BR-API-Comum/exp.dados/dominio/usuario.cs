using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class usuario : entidade
    {
        /// <summary>
        ///     Construtor da classe (inicializa o objeto)
        /// </summary>
        public usuario()
        {
            //Atribui a data atual
            data_criado = DateTime.Now;

            //Inicializa as listas
            menuadms = new List<menuadm>();
        }


        #region Relacionamentos

        public List<menuadm> menuadms { get; set; }

        #endregion

        public void RemoverMenu(int menuadmId)
        {
            menuadms.RemoveAll(c => c.id == menuadmId);
        }

        #region Primitive Properties

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCad { get; protected set; }
        public DateTime DataAcesso { get; protected set; }
        public int? NumAcesso { get; set; }
        public bool Adm { get; set; }
        public bool Excluido { get; set; }
        public int? usuario_criador { get; set; }
        public DateTime? data_criado { get; protected set; }
        public int? usuario_modificou { get; set; }
        public DateTime? data_modificado { get; protected set; }

        #endregion
    }
}