using System.ComponentModel.DataAnnotations;
using exp.core.Utilitarios;

namespace exp.dados
{
    public class IndicacaoPgtoCartaoModel : IndicacaoPgtoDeposito
    {
        public IndicacaoPgtoCartaoModel()
        {
            check_termo = false;
            check_pgto = false;
            check_dadosbancarios = false;
        }

        public bool? check_dadosbancarios { get; set; }
        public bool? check_termo { get; set; }
        public bool? check_pgto { get; set; }

        /// <summary>
        ///     Campos para Pagamento com cartão de crédito
        /// </summary>

        #region PAGAMENTO CARTÃO DE CRÉDITO

        public virtual int id { get; set; } // id da indicacao

        [Display(Name = "Número do Cartão")]
        [Required(ErrorMessage = "O campo Número do Cartão está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$", ErrorMessage = "O campo Número do Cartão está inválido.")]
        public string cred { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF está vazio ou contém caracteres inválidos.")]
        [ValidarCpf(ErrorMessage = "CPF inválido.")]
        public string credcpf { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        [Required(ErrorMessage = "O campo Data de vencimento do Cartão está vazio ou contém caracteres inválidos.")]
        public string credvendtmes { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        [Required(ErrorMessage = "O campo Data de vencimento do Cartão está vazio ou contém caracteres inválidos.")]
        public string credvendtano { get; set; }

        [Display(Name = "Código de Segurança do Cartão")]
        [Required(ErrorMessage = "O campo Código de Segurança do Cartão está vazio ou contém caracteres inválidos.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O Código de Segurança deve possuir 3 dígitos.")]
        public string credSegu { get; set; }

        [Display(Name = "Bandeira do Cartão")]
        [Required(ErrorMessage = "O campo Bandeira do Cartão está vazio ou contém caracteres inválidos.")]
        public string credtipo { get; set; }

        [Display(Name = "Nome no Titular")]
        [Required(ErrorMessage = "O campo Nome do Titular está vazio ou contém caracteres inválidos.")]
        public string nome_resp { get; set; }

        #endregion
    }

    public class IndicacaoPgtoCartaoAntModel : IndicacaoPgtoDeposito
    {
        public IndicacaoPgtoCartaoAntModel()
        {
            check_termo = false;
            check_pgto = false;
            check_dadosbancarios = false;
        }

        public bool? check_dadosbancarios { get; set; }
        public bool? check_termo { get; set; }
        public bool? check_pgto { get; set; }

        /// <summary>
        ///     Campos para Pagamento com cartão de crédito
        /// </summary>

        #region PAGAMENTO CARTÃO DE CRÉDITO

        public virtual int id { get; set; } // id da indicacao

        [Display(Name = "Número do Cartão")]
        [Required(ErrorMessage = "O campo Número do Cartão está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$", ErrorMessage = "O campo Número do Cartão está inválido.")]
        public string cred { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        [Required(ErrorMessage = "O campo Data de vencimento do Cartão está vazio ou contém caracteres inválidos.")]
        public string credvendtmes { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        [Required(ErrorMessage = "O campo Data de vencimento do Cartão está vazio ou contém caracteres inválidos.")]
        public string credvendtano { get; set; }

        [Display(Name = "Código de Segurança do Cartão")]
        [Required(ErrorMessage = "O campo Código de Segurança do Cartão está vazio ou contém caracteres inválidos.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O Código de Segurança deve possuir 3 dígitos.")]
        public string credSegu { get; set; }

        [Display(Name = "Bandeira do Cartão")]
        [Required(ErrorMessage = "O campo Bandeira do Cartão está vazio ou contém caracteres inválidos.")]
        public string credtipo { get; set; }

        [Display(Name = "Nome no Titular")]
        [Required(ErrorMessage = "O campo Nome do Titular está vazio ou contém caracteres inválidos.")]
        public string nome_resp { get; set; }

        #endregion
    }


    public class IndicacaoPgtoBoletoModel : IndicacaoPgtoDeposito
    {
        public IndicacaoPgtoBoletoModel()
        {
            check_termo = false;
            check_dadosbancarios = false;
        }

        public virtual int id { get; set; } // id da indicacao
        public bool? check_dadosbancarios { get; set; }
        public bool? check_termo { get; set; }
    }

    public class IndicacaoPgtoDeposito
    {
        public virtual int id { get; set; } // id pessoa
        public string tipo_conta { get; set; }
        public int? id_banco { get; set; }
        public string codigo_banco { get; set; }
        public string nome_banco { get; set; }
        public string agencia { get; set; }
        public string numero_conta { get; set; }
        public int id_site { get; set; }
        public bool exibirconta { get; set; }
    }
}