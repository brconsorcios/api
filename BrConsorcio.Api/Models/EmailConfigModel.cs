using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class EmailConfigModel
    {
        public int Porta { get; set; }
        public string Remetente { get; set; }
        public string NomeRemetente { get; set; }

        public string Smtp { get; set; }
        public string User { get; set; }
        public string Passwd { get; set; }

    }
}
