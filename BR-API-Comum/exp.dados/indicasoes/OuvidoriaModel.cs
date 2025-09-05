using System.ComponentModel.DataAnnotations;
using exp.core.Utilitarios;

namespace exp.dados
{
    public class OuvidoriaModel
    {
        [Required(ErrorMessage = "O campo Nº de protocolo está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string NumeroProtocolo { get; set; }

        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string NomeRazaoSocial { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "O campo CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        [ValidarCpfCnpj(ErrorMessage = "CPF/CNPJ inválido.")]
        [StringLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres.")]
        public string CPFCNPJ { get; set; }

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [StringLength(255, ErrorMessage = "Tamanho máximo de 255 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Grupo está vazio ou contém caracteres inválidos.")]
        [StringLength(10, ErrorMessage = "Tamanho máximo de 10 caracteres.")]
        public string Grupo { get; set; }

        [Required(ErrorMessage = "O campo Cota está vazio ou contém caracteres inválidos.")]
        [StringLength(10, ErrorMessage = "Tamanho máximo de 10 caracteres.")]
        public string Cota { get; set; }

        [Required(ErrorMessage = "O campo Assunto está vazio ou contém caracteres inválidos.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string Assunto { get; set; }

        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Tamanho máximo de 2000 caracteres.")]
        public string Mensagem { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string EnderecoIP { get; set; }
    }
}