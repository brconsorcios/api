using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class DadosVeiculos
    {
        //ID_CORCC023FTMP
        public int ID_CORCC023FTMP { get; set; }
        //ID_CORCC023F
        public int ID_CORCC023F { get; set; }
        public string ST_Operacao { get; set; }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "Identificador deve ser preenchido")]
        public long Id { get; set; }

        [Display(Name = "* Marca/Modelo")]
        [Required(ErrorMessage = "Marca/Modelo deve ser preenchido")]
        public string marcaModelo { get; set; }

        [Display(Name = "* Valor")]
        [Required(ErrorMessage = "Valor deve ser preenchido")]
        public string valorFormatado { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido")]
        public decimal valor { get; set; }

        [Display(Name = "* Chassi")]
        [Required(ErrorMessage = "Chassi deve ser preenchido")]
        public string chassi { get; set; }
    }
}