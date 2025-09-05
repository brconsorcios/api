using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace exp.dados
{
    public class VagaModel
    {
        public VagaModel()
        {
            sites = new List<int>();
        }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "Tamanho máximo de {0} caracteres.")]
        public string nome { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? quantidade { get; set; }

        [AllowHtml]
        [Display(Name = "Requisitos")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string requisitos { get; set; }

        [Display(Name = "Início da publicação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime? inicio_publicacao { get; set; }

        [Display(Name = "Fim da publicação")] public DateTime? fim_publicacao { get; set; }

        [Display(Name = "Disponível")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool disponivel { get; set; }

        public List<int> sites { get; set; }
    }
}