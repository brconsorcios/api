using System.ComponentModel.DataAnnotations;
using exp.core.Utilitarios;

namespace exp.dados
{
    public class indicacaoLigacaoModel : IndicacaoBemEscolhidoModel
    {
        public indicacaoLigacaoModel()
        {
            //Quero Receber uma ligação
            tipo_indicacao = 3;
        }

        #region Propriedades

        //Quero Receber uma ligação
        public int? tipo_indicacao { get; set; }

        /// <summary>
        ///     Os campos comuns estão no modelo bem escolhido
        /// </summary>
        /// <summary>
        ///     O Bem Escolhido está herdando de outro modelo
        /// </summary>


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")] //,MinimumLength=3)]
        public virtual string nome { get; set; } //ok


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF está vazio ou contém caracteres inválidos.")]
        [ValidarCpf(ErrorMessage = "CPF inválido.")]
        public string cpfcnpj { get; set; }


        /// <summary>
        ///     ENDEREÇO ====================================================================================
        /// </summary>


        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Selecione novamente o Estado, e digite o nome da cidade.")]
        public virtual string cidade { get; set; }

        public virtual string ds_cidade { get; set; }

        [Display(Name = "cd_cidade")] public int? cd_cidade { get; set; }

        [Display(Name = "UF")]
        //[Required(ErrorMessage = "O campo Estado está vazio ou contém caracteres inválidos.")]
        public virtual string uf { get; set; }

        // ENDEREÇO ====================================================================================

        [Display(Name = "Site")]
        [Required(ErrorMessage = "A Administradora Associada não foi selecionada.")]
        public virtual int? id_site { get; set; }

        /// <summary>
        ///     TELEFONES ====================================================================================
        /// </summary>

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone 1 está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone 1 é inválido.")]
        public virtual string telefone { get; set; }


        [Display(Name = "Celular")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone 2 é inválido.")]
        public virtual string celular { get; set; }

        /// TELEFONES ====================================================================================


        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string email { get; set; }


        [StringLength(2000, ErrorMessage = "Limite de 2000 caracteres.")]
        public string comentario { get; set; }

        #endregion
    }
}