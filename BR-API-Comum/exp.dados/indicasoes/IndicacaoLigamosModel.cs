using System;
using System.ComponentModel.DataAnnotations;
using exp.core.Utilitarios;

namespace exp.dados.indicasoes
{
    public class IndicacaoLigamosModel
    {
        public IndicacaoLigamosModel()
        {
            //LIGAMOS PARA VOCÊ
            tipo_indicacao = 6;
        }

        #region Propriedades

        public virtual int? id_site { get; set; }
        public int? tipo_indicacao { get; set; }
        public int? status { get; set; }
        public int? codigo_parceiro { get; set; }
        public int? codigo_campanha { get; set; }

        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        [ValidarCpfCnpj(ErrorMessage = "CPF/CNPJ inválido.")]
        public string cpfcnpj { get; set; }

        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone é inválido.")]
        public string telefone { get; set; }

        public DateTime? Datacadastro { get; set; }

        #endregion
    }
}