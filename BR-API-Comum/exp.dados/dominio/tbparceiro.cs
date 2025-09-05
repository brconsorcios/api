using System;
using System.Collections.Generic;
using exp.core;

namespace exp.dados
{
    public class tbparceiro
    {
        private string _cd_inscricao_nacional;

        public tbparceiro()
        {
            tbparceiros_pf = new tbparceiros_pf();
            tbparceiros_end = new tbparceiros_end();
            tbparceiros_pj = new tbparceiros_pj();
            tbparceiros_socios = new List<tbparceiros_socios>();
            datacadastro = DateTime.Now;
        }

        public int id { get; set; }
        public int id_site { get; set; }

        public string
            st_tipo_pessoa { get; set; } // char(1) NOT NULL COMMENT 'tipo de pessoa (f – física, j – jurídica) s',

        public string cd_inscricao_nacional
        {
            get => _cd_inscricao_nacional;
            set => _cd_inscricao_nacional = value.RetirarAlfabeto();
        } //'cpf e cnpj',

        public string nome { get; set; } //'NM_Pessoa ou NM_Razao_Social',
        public DateTime? dt_nascfund { get; set; } // 'data de nascimento ou data constituição',
        public string telefone { get; set; }
        public string celular { get; set; }

        public string site { get; set; }

        public string email1 { get; set; }
        public string email2 { get; set; }

        public DateTime? datacadastro { get; set; }

        public string unidade_regional { get; set; }
        public string unidade_negocios { get; set; }
        public string gerente { get; set; }

        public string email_gerente { get; set; }

        #region Relacionamentos

        public tbparceiros_pf tbparceiros_pf { get; set; }
        public tbparceiros_pj tbparceiros_pj { get; set; }
        public tbparceiros_end tbparceiros_end { get; set; }
        public List<tbparceiros_socios> tbparceiros_socios { get; set; }

        #endregion
    }
}