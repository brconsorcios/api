using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class CurriculoApiModel : CurriculoBaseModel
    {
        [Display(Name = "Anexo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string anexo { get; set; }
    }
}