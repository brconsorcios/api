using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class IndicacaoBlackFriday2017Model
    {
        #region Propriedades

        public int TipoIndicacao { get; } = 22;


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")] //,MinimumLength=3)]
        public virtual string Nome { get; set; }

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone 1 está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone inválido.")]
        public virtual string Telefone { get; set; }


        //[Display(Name = "CPF")]
        //[Required(ErrorMessage = "O CPF está vazio ou contém caracteres inválidos.")]
        //[ValidarCpf(ErrorMessage = "CPF inválido.")]
        //public string CPFCNPJ { get; set; }

        ///// <summary>
        ///// ENDEREÇO ====================================================================================
        ///// </summary>

        //[Display(Name = "Cidade")]
        ////[Required(ErrorMessage = "O campo Cidade está vazio ou contém caracteres inválidos.")]
        //public virtual string Cidade { get; set; }

        //[Display(Name = "UF")]
        ////[Required(ErrorMessage = "O campo Estado está vazio ou contém caracteres inválidos.")]
        //public virtual string UF { get; set; }

        //// ENDEREÇO ====================================================================================

        //[Display(Name = "Site")]
        //[Required(ErrorMessage = "A Administradora Associada não foi selecionada.")]
        //public virtual Nullable<int> id_site { get; set; }

        ///// <summary>
        ///// TELEFONES ====================================================================================
        ///// </summary>


        //[Display(Name = "Celular")]
        //[RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone 2 é inválido.")]
        //public virtual string Celular { get; set; }
        ///// TELEFONES ====================================================================================


        //[StringLength(2000, ErrorMessage = "Limite de 2000 caracteres.")]
        //public string Comentario { get; set; }

        #endregion
    }
}