using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class CurriculoModel
    {

        [Required(ErrorMessage = "Nome Completo é obrigatório.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string Estado { get; set; }

        public string Local { get; set; }

        public string quallocal { get; set; }


        public byte[] CurriculoAnexo { get; set; }

        public long IdOportunidades { get; set; }
    }
}
