using BrConsorcio.Api.Models;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services.Interfaces
{
    public interface ICompApiService
    {
        Task<string> Salvar(LeadPartner leadPartner, string produto);
        string getPortal(string produto);
    }
}
