using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class NotificacaoModel
    {
        public NotificacaoModel()
        {

        }

        public string CpfCnpj { get; set; }

        public string Mensagem { get; set; }
    }
}
