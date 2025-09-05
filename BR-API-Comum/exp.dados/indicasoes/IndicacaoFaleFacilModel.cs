using System;
using System.ComponentModel.DataAnnotations;

namespace exp.dados.indicasoes
{
    public class IndicacaoFaleFacilModel
    {
        public IndicacaoFaleFacilModel()
        {
            //FALE FACIL / HOME
            tipo_indicacao = 9;
        }

        #region Propriedades

        public virtual int? id_site { get; set; }
        public int? tipo_indicacao { get; set; }
        public int? status { get; set; }
        public int? codigo_parceiro { get; set; }
        public int? codigo_campanha { get; set; }
        public string celular { get; set; }

        [Required(ErrorMessage = "Selecione uma opção.")]
        public string falef { get; set; }

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        public string cpfcnpj { get; set; }

        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone é inválido.")]
        public string telefone { get; set; }

        public DateTime? Datacadastro { get; set; }

        #endregion
    }
}