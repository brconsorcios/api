
using System;


namespace BrConsorcio.Api.Models
{
    public class TokenProvider
    {
        public string CdUsuario { get; set; }
        public string InscricaoNacional { get; set; }
        public DateTime Data { get; set; }
        public string Token { get; set; }
        public int IdUsuario { get; set; }
    }
}
