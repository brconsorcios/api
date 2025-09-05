using BrConsorcio.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services.Interfaces
{
    public interface IRDStation
    {
        Task<Token> Token(RDScp rDScp);
        Task<string> Event(Lead lead);
       
    }
}
