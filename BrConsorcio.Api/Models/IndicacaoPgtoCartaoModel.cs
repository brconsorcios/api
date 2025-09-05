using BrConsorcio.Api.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class IndicacaoPgtoCartaoModel : IndicacaoPgtoDeposito
    {

        /// <summary>
        /// Campos para Pagamento com cartão de crédito
        /// </summary>
        #region PAGAMENTO CARTÃO DE CRÉDITO
        public virtual int id { get; set; } // id da indicacao

        [Display(Name = "Número do Cartão")]
        [Required(ErrorMessage = "O campo Número do Cartão está vazio ou contém caracteres inválidos.")]
        public string cred { get; set; }
        string _credcpf;
        [Display(Name = "CPF")]
        //[Required(ErrorMessage = "O campo CPF está vazio ou contém caracteres inválidos.")]
        [Required(ErrorMessage = "O campo CPF está vazio ou contém caracteres inválidos.")]
        public string credcpf { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        [Required(ErrorMessage = "O campo Data de vencimento do Cartão está vazio ou contém caracteres inválidos.")]
        public string credvendtmes { get; set; }

        [Display(Name = "Data de vencimento do Cartão")]
        [Required(ErrorMessage = "O campo Data de vencimento do Cartão está vazio ou contém caracteres inválidos.")]
        public string credvendtano { get; set; }

        [Display(Name = "Código de Segurança do Cartão")]
        [Required(ErrorMessage = "O campo Código de Segurança do Cartão está vazio ou contém caracteres inválidos.")]
        public string credSegu { get; set; }

        [Display(Name = "Bandeira do Cartão")]
        [Required(ErrorMessage = "O campo Bandeira do Cartão está vazio ou contém caracteres inválidos.")]
        public string credtipo { get; set; }

        [Display(Name = "Nome no Cartão")]
        [Required(ErrorMessage = "O campo Nome no Cartão está vazio ou contém caracteres inválidos.")]
        public string nome_resp { get; set; }

        #endregion

        public bool? check_dadosbancarios { get; set; }
        public bool? check_termo { get; set; }
        public bool? check_pgto { get; set; }

        public IndicacaoPgtoCartaoModel()
        {
            check_termo = false;
            check_pgto = false;
            check_dadosbancarios = false;

        }
    }

}
