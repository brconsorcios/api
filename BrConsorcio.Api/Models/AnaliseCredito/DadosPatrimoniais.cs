using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class DadosPatrimoniais
    {
        public int ID_CORCC023ETMP { get; set; }
        //ID_CORCC023E
        public int ID_CORCC023E { get; set; }
        //ST_Operacao
        public string ST_Operacao { get; set; }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "Identificador deve ser preenchido")]
        public long Id { get; set; }

        [Display(Name = "* Tipo do Imóvel")]
        [Required(ErrorMessage = "Tipo do imóvel deve ser preenchido")]
        public string tipo { get; set; }

        [Display(Name = "* Nome/Descrição")]
        [Required(ErrorMessage = "Nome/Descriçao deve ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "* Valor")]
        [Required(ErrorMessage = "Valor deve ser preenchido")]
        public string valorFormatado { get; set; }

        [Display(Name = "* Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido")]
        public decimal valor { get; set; }

        [Display(Name = "* Tipo Estrutura")]
        [Required(ErrorMessage = "Tipo estrutura deve ser preenchido")]
        public string tipoEscritura { get; set; }

        [Display(Name = "* Comprovado")]
        [Required(ErrorMessage = "Comprovado deve ser preenchido")]
        public string comprovado { get; set; }

        [Display(Name = "* Tipo Comprovação")]
        [Required(ErrorMessage = "Tipo comprovação deve ser preenchido")]
        public string tipoComprovacao { get; set; }
    }
}