using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class CadastrarCampanhaModel
    {
        [Required]
        public int TipoCampanha { get; set; }

        [Required]
        public String NomeCampanha { get; set; }

        [Required]
        public byte[] Imagem { get; set; }

        [Required]
        public String UrlPdf { get; set; }

        [Required]
        public DateTime DataInclusao { get; set; }

        [Required]
        public DateTime DataValidade { get; set; }
    }
}
