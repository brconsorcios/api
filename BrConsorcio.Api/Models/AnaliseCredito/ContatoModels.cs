using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class ContatoModels
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string ContatoNome { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-Mail deve ser preenchido")]
        public string ContatoEMail { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone deve ser preenchido")]
        public string ContatoTelefone { get; set; }

        [Display(Name = "Descrição")]
        public string ContatoDescricao { get; set; }

        [Display(Name = "Dados Formulário - Pessoal")]
        public string ContatoFormPessoal { get; set; }

        [Display(Name = "Dados Formulário - Profissional")]
        public string ContatoFormProfisisonal { get; set; }

        [Display(Name = "Dados Formulário - Conjuge")]
        public string ContatoFormConjuge { get; set; }

        [Display(Name = "Dados Formulário - Avalista")]
        public string ContatoFormAvalista { get; set; }

        [Display(Name = "Dados Formulário - Socio")]
        public string ContatoFormSocio { get; set; }

        [Display(Name = "Dados Formulário - Referencias Bancarias")]
        public string ContatoFormReferencias { get; set; }

        [Display(Name = "Dados Formulário - Dados Patrimoniais")]
        public string ContatoFormPatrimoniais { get; set; }

        [Display(Name = "Dados Formulário - Veiculos")]
        public string ContatoFormVeiculos { get; set; }

        [Display(Name = "Status Integração")]
        public string Status { get; set; }
    }
}
