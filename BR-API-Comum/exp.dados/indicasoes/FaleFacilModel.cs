using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class FaleFacilModel
    {
        public int? tipo_indicacao { get; set; }
        public int? status { get; set; }
        public int? codigo_parceiro { get; set; }
        public int? codigo_campanha { get; set; }

        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Celular é inválido.")]
        public string celular { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone é inválido.")]
        public string Telefone { get; set; }
    }
}