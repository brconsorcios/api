using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Models;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using BrConsorcio.Api.Services.Interfaces;

namespace BrConsorcio.Api.Services
{
   
    public class CompApiService: ICompApiService
    {
        private HttpHelpers http;
        private CompApi _compApi;

        public CompApiService(IOptions<CompApi> compApi)
        {
            _compApi = compApi.Value;
            http = new HttpHelpers(_compApi.Url, "", "");
        }

        
        public async Task<string> Salvar(LeadPartner leadPartner,string produto)
        {
           try
            {
                leadPartner.nome = $"{_compApi.HML}{leadPartner.nome}";
                leadPartner.portal = this.getPortal(produto);

                return await http.Post<LeadPartner, string>($"{ _compApi.ApiPasta}salvar/", leadPartner, _compApi.Authorization);
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }
        public string getPortal(string produto)
        {
            if (produto.Contains("Carros")) return "0000000";
            if (produto.Contains("Imóveis")) return "0000000";
            if (produto.Contains("Motos")) return "0000000";
            if (produto.Contains("Serviços")) return "0000000";
            if (produto.Contains("Equipamentos")) return "0000000";
            return "";
        }
    }
}
