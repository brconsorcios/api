using MimeKit;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services.Interfaces
{
    public interface IEmailService
    {
        Task Enviar(string assunto, string msg, MailboxAddress destinatario, string copia, byte[] anexo);
        Task Enviar(string assunto, string msg, MailboxAddress destinatario, string copia, byte[] anexo, string nomeAnexo);
        Task Enviar(string assunto, string msg, string remetente, MailboxAddress destinatario, string copia, byte[] anexo);
        Task EnviarFaleConosco(string assunto, string msg, MailboxAddress remetente, MailboxAddress destinatario, string copia, byte[] anexo);
    }
}
