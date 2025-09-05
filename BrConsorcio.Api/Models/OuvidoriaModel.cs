using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class OuvidoriaModel
    {
         public string Titulo { get; set; }
        public byte[] imagem { get; set; }
        public string Texto { get; set; }
        public int Ordem { get; set; }
        public Boolean Ativo { get; set; }
        public string ScpsCodigo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
