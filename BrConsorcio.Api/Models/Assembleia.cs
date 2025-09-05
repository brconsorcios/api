using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class Assembleia
    {
        public int id { get; set; }
        public bool disponivel { get; set; }
        public DateTime? dataass { get; set; }
        public string pasta { get; set; }
    }
}
