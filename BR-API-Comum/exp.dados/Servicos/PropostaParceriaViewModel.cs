using System;
using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class PropostaParceriaViewModel
    {
        [Display(Name = "Site")]
        [Required(ErrorMessage = "A Administradora Associada não foi selecionada.")]
        public virtual int? id_site { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")] //,MinimumLength=3)]
        public virtual string pes_nome { get; set; } //ok

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [StringLength(14, ErrorMessage = "Número de Telefone é inválido.")]
        public virtual string pes_telefone { get; set; }

        [Display(Name = "Telefone 2")]
        // [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [StringLength(14, ErrorMessage = "Número de Telefone 2 é inválido.")]
        public virtual string pes_telefone2 { get; set; }

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string pes_email { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "A Cidade está vazia ou contém caracteres inválidos.")]
        public string cidade { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "O campo UF está vazio ou contém caracteres inválidos.")]
        public virtual string pes_uf { get; set; }

        public string emp_nomefantasia { get; set; } // varchar(150) DEFAULT NULL,
        public string emp_razaosocial { get; set; } // varchar(150) DEFAULT NULL,
        public string emp_cidade { get; set; } // varchar(100) DEFAULT NULL,
        public string emp_uf { get; set; } // varchar(2) DEFAULT NULL,
        public string emp_telefone { get; set; } // varchar(20) DEFAULT NULL,
        public string emp_telefone2 { get; set; } // varchar(20) DEFAULT NULL,

        public DateTime datacadastro { get; set; } // datetime DEFAULT NULL,
    }
}