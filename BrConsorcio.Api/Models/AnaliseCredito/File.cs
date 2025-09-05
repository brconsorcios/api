using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class File
    {
        public string filename { get; set; }
        public byte[] arquivo { get; set; }

        public string idDocumentoWebCredito { get; set; }
    }
}
