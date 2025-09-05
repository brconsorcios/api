using System;

namespace BrConsorcio.Api.Models
{
    public class EnviarEmailModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone1 { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CelularEmpresa { get; set; }

        public int id_site { get; set; }
    }
}
