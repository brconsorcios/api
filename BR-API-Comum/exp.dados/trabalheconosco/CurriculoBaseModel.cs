using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class CurriculoBaseModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "Tamanho máximo de {0} caracteres.")]
        public string nome { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone inválido.")]
        public string telefone { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "Tamanho máximo de {0} caracteres.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-mail inválido.")]
        public string email { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(70, ErrorMessage = "Tamanho máximo de {0} caracteres.")]
        public string cidade { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(40, ErrorMessage = "Tamanho máximo de {0} caracteres.")]
        public string uf { get; set; }
    }
}