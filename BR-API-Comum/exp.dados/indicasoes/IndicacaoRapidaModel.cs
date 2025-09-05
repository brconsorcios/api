using System.ComponentModel.DataAnnotations;
using exp.core.Utilitarios;

namespace exp.dados.indicasoes
{
    public class IndicacaoRapidaModel : IndicacaoBemEscolhidoModel
    {
        public IndicacaoRapidaModel()
        {
            //Compra Rápida / Solicitar Contato
            tipo_indicacao = 10;
        }

        #region Propriedades

        public virtual int? id_site { get; set; }
        public int? tipo_indicacao { get; set; }

        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone é inválido.")]
        public string telefone { get; set; }

        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Celular é inválido.")]
        public string celular { get; set; }

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string email { get; set; }

        [Required(ErrorMessage = "O campo Cidade está vazio ou contém caracteres inválidos.")]
        public virtual string cidade { get; set; }

        public virtual string ds_cidade { get; set; }

        public int? cd_cidade { get; set; }

        [Required(ErrorMessage = "Selecione um Estado.")]
        public virtual string uf { get; set; }

        [Required(ErrorMessage = "O CPF está vazio ou contém caracteres inválidos.")]
        [ValidarCpf(ErrorMessage = "CPF inválido.")]
        public string cpfcnpj { get; set; }

        [StringLength(2000, ErrorMessage = "Limite de 2000 caracteres.")]
        public string comentario { get; set; }

        #endregion
    }
}