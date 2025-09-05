using System.ComponentModel.DataAnnotations;
using System.Web;
using exp.dados.Uteis;

namespace exp.dados
{
    public class CurriculoModel : CurriculoBaseModel
    {
        [Display(Name = "Anexo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [FileExtensions("doc|docx|pdf", ErrorMessage = "Selecione um arquivo com uma extensão válida.")]
        [FileSize(1 * 1024 * 1024, ErrorMessage = "Tamanho máximo permitido: 1MB.")]
        public HttpPostedFileBase anexo { get; set; }
    }
}