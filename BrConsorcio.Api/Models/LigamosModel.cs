using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class LigamosModel
    {
     
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        public string cpfcnpj { get; set; }
        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [StringLength(16, ErrorMessage = "Número de Celular é inválido.")]
        public string telefone { get; set; }
        public DateTime? Datacadastro { get; set; }
        public int IdSite { get; set; }
    }
}
