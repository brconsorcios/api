using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class IndicacaoCompraInternetModel : IndicacaoBemEscolhidoModel
    {
        public IndicacaoCompraInternetModel()
        {
            //Quero Comprar pela Internet
            tipo_indicacao = 1;
        }

        #region Propriedades

        //Quero Comprar pela Internet
        public int? tipo_indicacao { get; set; }

        /// <summary>
        ///     Os campos comuns estão no modelo bem escolhido
        /// </summary>
        /// <summary>
        ///     O Bem Escolhido está herdando de outro modelo
        /// </summary>


        public string FormaPgto { get; set; }

        public string Contato { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")] //,MinimumLength=3)]
        public virtual string nome { get; set; } //ok

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "O CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        public string cpfcnpj { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O RG está vazio ou contém caracteres inválidos.")]
        public string rg { get; set; }

        //[Required(ErrorMessage = "A Data de nascimento está vazio ou contém caracteres inválidos.")]
        //public string DT_NASC { get; set; }

        /// <summary>
        ///     ENDEREÇO ====================================================================================
        /// </summary>


        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo Endereço está vazio ou contém caracteres inválidos.")]
        public virtual string endereco { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo Número está vazio ou contém caracteres inválidos.")]
        public virtual string numero { get; set; }

        [Display(Name = "Complemento")]
        //[Required(ErrorMessage = "O campo Complemento está vazio ou contém caracteres inválidos.")]
        public virtual string complemento { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo Bairro está vazio ou contém caracteres inválidos.")]
        public virtual string bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo Cidade está vazio ou contém caracteres inválidos.")]
        public virtual string cidade { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "O campo UF está vazio ou contém caracteres inválidos.")]
        public virtual string uf { get; set; }

        [Display(Name = "Cep")]
        [Required(ErrorMessage = "O campo Cep está vazio ou contém caracteres inválidos.")]
        public virtual string cep { get; set; }

        [Display(Name = "País")] public virtual string pais { get; set; }

        public virtual string codpais { get; set; }
        // ENDEREÇO ====================================================================================

        [Display(Name = "Site")]
        [Required(ErrorMessage = "A Administradora Associada não foi selecionada.")]
        public virtual int? id_site { get; set; }


        /// <summary>
        ///     TELEFONES ====================================================================================
        /// </summary>

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone é inválido.")]
        public virtual string telefone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O Celular está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Celular é inválido.")]
        public virtual string celular { get; set; }

        /// TELEFONES ====================================================================================


        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string email { get; set; }


        [Required(ErrorMessage = "Descreva a sua Mensagem.")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Limite de 2000 caracteres.")]
        public string comentario { get; set; }

        #endregion
    }
}