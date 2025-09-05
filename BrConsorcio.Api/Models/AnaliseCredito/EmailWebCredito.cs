using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class EmailWebCredito
    {
        public string subjectF1 { get; set; }
        public string subjectDoc { get; set; }
        public string to { get; set; }
        public string from { get; set; }
        public string smtp { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

    }
}
