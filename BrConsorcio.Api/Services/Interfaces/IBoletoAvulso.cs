using BoletoAvulsoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services.Interfaces
{
    public interface IBoletoAvulso
    {
        Task<RetornoConsultarParcelas> ConsultarParcelas(string grupo, int cota, string cpfCnpj);
        void Close();
        
    }

}
