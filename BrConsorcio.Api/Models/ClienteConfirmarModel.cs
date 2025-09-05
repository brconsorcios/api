using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
        public class ClienteConfirmarModel
        {
            public bool login { get; set; }
            public bool cadastrado { get; set; }
            public bool confirmado { get; set; }
        }
}
