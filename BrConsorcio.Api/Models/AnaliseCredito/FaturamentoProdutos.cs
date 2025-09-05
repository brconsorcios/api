using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class FaturamentoProdutos
    {
        public long ID_CORCC023M { get; set; }
        public int ID_CORCC023MTMP { get; set; }

        [Display(Name = "ID")]
        //[Required(ErrorMessage = "Identificador deve ser preenchido")]
        public long ID { get; set; }

        [Display(Name = "Principais Produtos")]
        //[Required(ErrorMessage = "Produtos devem ser preenchido")]
        public string produtos { get; set; }

        [Display(Name = "% sobre o faturamento")]
        //[Required(ErrorMessage = "% Faturamento deve ser preenchido")]
        public string percFaturamentoFormatado { get; set; }

        public decimal percFaturamento { get; set; }
    }
}