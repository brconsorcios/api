using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class ParceirosPessoaFisicaModel
    {
        /// <summary>
        ///     Dados Comuns
        /// </summary>
        [Required]
        [Display(Name = "Tipo Pessoa")]
        public string
            st_tipo_pessoa { get; set; } // char(1) NOT NULL COMMENT 'tipo de pessoa (f – física, j – jurídica) s',

        [Display(Name = "NOME")]
        [Required(ErrorMessage = "O campo NOME é obrigatório.")]
        public string nome { get; set; } //'NM_Pessoa ou NM_Razao_Social',

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF está vazio ou contém caracteres inválidos.")]
        [StringLength(14, ErrorMessage = "Tamanho máximo de 14 caracteres.")] //,MinimumLength=3)]
        public string cd_inscricao_nacional { get; set; }

        [Display(Name = "DATA DE NASCIMENTO")]
        [Required(ErrorMessage = "O campo DATA DE NASCIMENTO está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.DateTime)]
        public DateTime? dt_nascfund { get; set; } // 'data de nascimento ou data constituição',

        [Display(Name = "TELEFONE")]
        [Required(ErrorMessage = "O campo TELEFONE está vazio ou contém caracteres inválidos.")]
        public string telefone { get; set; }

        [Display(Name = "CELULAR")]
        [Required(ErrorMessage = "O campo CELULAR está vazio ou contém caracteres inválidos.")]
        public string celular { get; set; }

        public string site { get; set; }

        [Display(Name = "E-MAIL")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O campo E-MAIL está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public string email1 { get; set; }

        [Display(Name = "E-MAIL 2")] public string email2 { get; set; }

        [Display(Name = "UNIDADE REGIONAL")]
        [Required(ErrorMessage = "O campo UNIDADE REGIONAL está vazio ou contém caracteres inválidos.")]
        public string unidade_regional { get; set; }

        [Display(Name = "UNIDADE DE NEGÓCIOS")]
        [Required(ErrorMessage = "O campo UNIDADE DE NEGÓCIOS está vazio ou contém caracteres inválidos.")]
        public string unidade_negocios { get; set; }

        [Display(Name = "GERENTE BR CONSÓRCIOS")]
        [Required(ErrorMessage = "O campo GERENTE BR CONSÓRCIOS está vazio ou contém caracteres inválidos.")]
        public string gerente { get; set; }

        /// <summary>
        ///     Somente de pessoa fisica
        /// </summary>
        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo RG está vazio ou contém caracteres inválidos.")]
        public string rg { get; set; } //'documento (registro nacional) s',

        [Display(Name = "DATA EXPEDIÇÃO")]
        [Required(ErrorMessage = "O campo DATA EXPEDIÇÃO está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.DateTime)]
        public DateTime? dt_expedicao { get; set; } //

        [Display(Name = "ÓRGÃO EMISSOR")]
        [Required(ErrorMessage = "O campo ÓRGÃO EMISSOR está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.DateTime)]
        public string nm_orgao_emissor { get; set; } // 'Emissor do documento ',

        [Display(Name = "NOME PAI")]
        [Required(ErrorMessage = "O campo NOME PAI está vazio ou contém caracteres inválidos.")]
        public string nome_pai { get; set; } // 'pai',

        [Display(Name = "NOME MÃE")]
        [Required(ErrorMessage = "O campo NOME MÃE está vazio ou contém caracteres inválidos.")]
        public string nome_mae { get; set; } // 'mae',

        public string sexo { get; set; } // 'sexo (m – masculino, f – feminino) s',

        public string nm_nacionalidade { get; set; } // 'nacionalidae',

        [Display(Name = "NATURALIDADE")]
        [Required(ErrorMessage = "O campo NATURALIDADE está vazio ou contém caracteres inválidos.")]
        public string naturalidade { get; set; } //

        public string profissao { get; set; } //

        /// <summary>
        ///     Endereço
        /// </summary>
        [Display(Name = "ENDEREÇO")]
        [Required(ErrorMessage = "O campo ENDEREÇO está vazio ou contém caracteres inválidos.")]
        public string endereco { get; set; } //'endereço s',

        [Display(Name = "NÚMERO")]
        [Required(ErrorMessage = "O campo NÚMERO está vazio ou contém caracteres inválidos.")]
        public string numero { get; set; } //'número do endereço s',

        public string complemento { get; set; } //'complemento n',

        [Display(Name = "BAIRRO")]
        [Required(ErrorMessage = "O campo BAIRRO está vazio ou contém caracteres inválidos.")]
        public string bairro { get; set; } //'bairro n',

        [Display(Name = "CIDADE")]
        [Required(ErrorMessage = "O campo CIDADE está vazio ou contém caracteres inválidos.")]
        public string cidade { get; set; } //'nome da cidade s',

        [Display(Name = "UF")]
        [Required(ErrorMessage = "O campo UF está vazio ou contém caracteres inválidos.")]
        public string uf { get; set; } //

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo CEP está vazio ou contém caracteres inválidos.")]
        public string cep { get; set; } //

        [Display(Name = "TIPO ENDEREÇO")]
        [Required(ErrorMessage = "O campo TIPO ENDEREÇO está vazio ou contém caracteres inválidos.")]
        public string tipo_endereco { get; set; } //

        public string emailgerente { get; set; }
    }


    public class ParceirosPessoaJuridicaModel
    {
        public ParceirosPessoaJuridicaModel()
        {
            socios = new List<tbparceiros_socios>();
        }

        /// <summary>
        ///     Dados Comuns
        /// </summary>
        [Required]
        [Display(Name = "Tipo Pessoa")]
        public string
            st_tipo_pessoa { get; set; } // char(1) NOT NULL COMMENT 'tipo de pessoa (f – física, j – jurídica) s',

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        [StringLength(18, ErrorMessage = "Tamanho máximo de 18 caracteres.")] //,MinimumLength=3)]
        public string cd_inscricao_nacional { get; set; }

        [Display(Name = "NOME FANTASIA")]
        [Required(ErrorMessage = "O campo NOME FANTASIA está vazio ou contém caracteres inválidos.")]
        public string nome { get; set; } //'NM_Pessoa ou NM_Razao_Social',

        [Display(Name = "DATA DE CONSTITUIÇÃO")]
        [Required(ErrorMessage = "O campo DATA DE CONSTITUIÇÃO está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.DateTime)]
        public DateTime? dt_nascfund { get; set; } // 'data de nascimento ou data constituição',

        [Display(Name = "SITE")] public string site { get; set; }

        [Display(Name = "E-MAIL")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O campo E-MAIL está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public string email1 { get; set; }

        [Display(Name = "E-MAIL 2")] public string email2 { get; set; }

        [Display(Name = "TELEFONE")]
        [Required(ErrorMessage = "O campo TELEFONE está vazio ou contém caracteres inválidos.")]
        public string telefone { get; set; }

        [Display(Name = "CELULAR")]
        [Required(ErrorMessage = "O campo CELULAR está vazio ou contém caracteres inválidos.")]
        public string celular { get; set; }

        [Display(Name = "UNIDADE REGIONAL")]
        [Required(ErrorMessage = "O campo UNIDADE REGIONAL está vazio ou contém caracteres inválidos.")]
        public string unidade_regional { get; set; }

        [Display(Name = "UNIDADE DE NEGÓCIOS")]
        [Required(ErrorMessage = "O campo UNIDADE DE NEGÓCIOS está vazio ou contém caracteres inválidos.")]
        public string unidade_negocios { get; set; }

        [Display(Name = "GERENTE BR CONSÓRCIOS")]
        [Required(ErrorMessage = "O campo GERENTE BR CONSÓRCIOS está vazio ou contém caracteres inválidos.")]
        public string gerente { get; set; }

        /// <summary>
        ///     Somente de pessoa juridica
        /// </summary>
        [Display(Name = "RAZÃO SOCIAL")]
        [Required(ErrorMessage = "O campo RAZÃO SOCIAL está vazio ou contém caracteres inválidos.")]
        public string razaosocial { get; set; } //

        [Display(Name = "DATA DE ABERTURA")]
        [Required(ErrorMessage = "O campo DATA DE ABERTURA está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.DateTime)]
        public DateTime? dt_abertura { get; set; } //

        [Display(Name = "INSC. MUNICIPAL")]
        [Required(ErrorMessage = "O campo INSC. MUNICIPAL está vazio ou contém caracteres inválidos.")]
        public string insc_municipal { get; set; } //

        [Display(Name = "INSC.ESTADUAL ")]
        [Required(ErrorMessage = "O campo INSC.ESTADUAL  está vazio ou contém caracteres inválidos.")]
        public string insc_estadual { get; set; } //

        /// <summary>
        ///     Endereço
        /// </summary>
        [Display(Name = "ENDEREÇO")]
        [Required(ErrorMessage = "O campo ENDEREÇO está vazio ou contém caracteres inválidos.")]
        public string endereco { get; set; } //'endereço s',

        [Display(Name = "NÚMERO")]
        [Required(ErrorMessage = "O campo NÚMERO está vazio ou contém caracteres inválidos.")]
        public string numero { get; set; } //'número do endereço s',

        public string complemento { get; set; } //'complemento n',

        [Display(Name = "BAIRRO")]
        [Required(ErrorMessage = "O campo BAIRRO está vazio ou contém caracteres inválidos.")]
        public string bairro { get; set; } //'bairro n',

        [Display(Name = "CIDADE")]
        [Required(ErrorMessage = "O campo CIDADE está vazio ou contém caracteres inválidos.")]
        public string cidade { get; set; } //'nome da cidade s',

        [Display(Name = "UF")]
        [Required(ErrorMessage = "O campo UF está vazio ou contém caracteres inválidos.")]
        public string uf { get; set; } //

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo CEP está vazio ou contém caracteres inválidos.")]
        public string cep { get; set; } //

        [Display(Name = "TIPO ENDEREÇO")]
        [Required(ErrorMessage = "O campo TIPO ENDEREÇO está vazio ou contém caracteres inválidos.")]
        public string tipo_endereco { get; set; } //

        public string emailgerente { get; set; }

        ///
        public List<tbparceiros_socios> socios { get; set; }
    }
}