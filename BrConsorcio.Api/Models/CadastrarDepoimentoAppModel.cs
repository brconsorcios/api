using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class CadastrarDepoimentoAppModel
    {

        [Required]
        public string UsuarioDepoimento { get; set; }

        [Required]
        public string Depoimento { get; set; }

        [Required]
        public int Ativo { get; set; } //1 - SIM ou 2 - NAO

        [Required]
        public DateTime DataInclusao { get; set; }

        [Required]
        public DateTime DataAprovacao { get; set; }

        public string UsuarioInclusao { get; set; }
        public string UsuarioAprovacao { get; set; }
        public string Observacao { get; set; } //Observacoes diversas para controle interno. Nao sera mostrado no APP.
        public byte[] FotoPerfil { get; set; } //Preparando para uma possivel melhoria de mostrar a foto do usuario que realizou o depoimento.
    }
}
