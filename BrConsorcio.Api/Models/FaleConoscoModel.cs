using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models
{
    public class FaleConoscoModel
    {
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public virtual string Nome { get; set; }

        public int? TipoIndicacao { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string Email { get; set; }

        [Display(Name = "Telefone1")]
        [Required(ErrorMessage = "O Telefone2 está vazio ou contém caracteres inválidos.")]
        [StringLength(16, ErrorMessage = "Número de Celular é inválido.")]
        public virtual string Telefone1 { get; set; }

        [Display(Name = "Telefone2")]
        [Required(ErrorMessage = "O Telefone2 está vazio ou contém caracteres inválidos.")]
        [StringLength(16, ErrorMessage = "Número de Celular é inválido.")]
        public virtual string Telefone2 { get; set; }

        public virtual string Uf { get; set; }

        public virtual string Cidade { get; set; }

        public string Comentario { get; set; }

        public string FormaContato { get; set; }

        public int IdSite { get; set; }
        public string cf_dcontact { get; set; }
        public string cf_informacoes_novidades { get; set; }




    }
}
