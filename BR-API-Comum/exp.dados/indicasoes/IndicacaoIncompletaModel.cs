using System.ComponentModel.DataAnnotations;

namespace exp.dados.indicasoes
{
    public class IndicacaoIncompletaModel
    {
        public string chave { get; set; }

        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone 1 está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone 1 é inválido.")]
        public string telefone { get; set; }

        public int? codigo_campanha { get; set; }

        //public decimal Credito { get; set; }
        //public int id_site { get; set; }
        //public int id_bem { get; set; }
    }
}