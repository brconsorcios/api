using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace BrConsorcio.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigModel _emailConfig;
       public EmailService(IOptions<EmailConfigModel> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        private async Task SendEmail(MailMessage mailMessage)
        {
            using (var smtpClient = new System.Net.Mail.SmtpClient(_emailConfig.Smtp, _emailConfig.Porta))
            {
                // Configurar o cliente SMTP
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfig.User, _emailConfig.Passwd);
                smtpClient.EnableSsl = false; // Se o seu servidor SMTP requer SSL
                                              // smtpClient.EnableSsl = false; // Se o seu servidor SMTP não requer SSL
                                              // Criar a mensagem
                mailMessage.IsBodyHtml = true; // Definir como true para que o corpo do e-mail seja tratado como HTML
                // Enviar e-mail
                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        private async Task EnviarEmail(string subject, string body, string to, string from = "", string cc = "", byte[] anexo = null, string nomeAnexo = "")
        {
            if (from == "")
                from = _emailConfig.Remetente;

            if (cc != "")
                to = $"{to},{cc}";

            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.IsBodyHtml = true;
            if (anexo != null)
            {
                MemoryStream memoryStream = new MemoryStream(anexo);
                Attachment attachment = new Attachment(memoryStream, nomeAnexo);
                mailMessage.Attachments.Add(attachment);

            }
            await this.SendEmail(mailMessage);
        }

        public async Task Enviar(string assunto, string msg, MailboxAddress destinatario, string copia, byte[] anexo)
        {
             await this.EnviarEmail(assunto, msg, destinatario.Address, "", copia, anexo);
        }
        public async Task Enviar(string assunto, string msg, MailboxAddress destinatario, string copia, byte[] anexo, string nomeAnexo  )
        {
            await this.EnviarEmail(assunto, msg, destinatario.Address, "", copia, anexo,nomeAnexo);
        }

        public async Task Enviar(string assunto, string msg, string remetente, MailboxAddress destinatario, string copia, byte[] anexo)
        {
            await this.EnviarEmail(assunto, msg, destinatario.Address, remetente, copia, anexo);
        }
        public async Task Enviar(string assunto, string msg, string remetente, string destinatario, string copia, byte[] anexo, string nomeAnexo)
        {
            await this.EnviarEmail(assunto, msg, destinatario, remetente, copia, anexo, nomeAnexo);
        }
        public async Task EnviarFaleConosco(string assunto, string msg, string remetente, string destinatario, string copia, byte[] anexo, string nomeAnexo)
        {
            await this.EnviarEmail(assunto, msg, destinatario, remetente, copia, anexo, nomeAnexo);
        }


        public async Task EnviarFaleConosco(string assunto, string msg, MailboxAddress remetente, MailboxAddress destinatario, string copia, byte[] anexo)
        {
            await this.EnviarEmail(assunto, msg, destinatario.Address, remetente.Address, copia, anexo);
        }



/*

        public async Task Enviar(string assunto, string msg, MailboxAddress destinatario, string copia, byte[] anexo)
        {
    



            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailConfig.NomeRemetente, _emailConfig.Remetente));
                mimeMessage.To.Add(destinatario);

                string[] adrs = copia.Split(',');

                foreach (string item in adrs)
                {
                    if (!string.IsNullOrEmpty(item)) { mimeMessage.Cc.Add(new MailboxAddress("", item)); ; }
                }


                mimeMessage.Subject = assunto;

                var builder = new BodyBuilder();

                builder.HtmlBody = string.Format(msg);

                if (anexo != null)
                    builder.Attachments.Add("Curriculo.pdf", anexo, new ContentType("application", "pdf"));


                mimeMessage.Body = builder.ToMessageBody();

                //mimeMessage.HtmlBody = string.Format(message.Content)
                //mimeMessage.Body = new TextPart("plain")
                //{
                //    Text = msg

                //};

                using (var client = new SmtpClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(_emailConfig.Smtp, _emailConfig.Porta, true);
                    client.Authenticate(_emailConfig.User, _emailConfig.Passwd);


                    await client.SendAsync(mimeMessage);

                    client.Disconnect(true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task Enviar(string assunto, string msg, string remetente,MailboxAddress destinatario, string copia, byte[] anexo)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(remetente, _emailConfig.Remetente));
                mimeMessage.To.Add(destinatario);

                string[] adrs = copia.Split(',');

                foreach (string item in adrs)
                {
                    if (!string.IsNullOrEmpty(item)) { mimeMessage.Cc.Add(new MailboxAddress("", item)); ; }
                }


                mimeMessage.Subject = assunto;

                var builder = new BodyBuilder();

                builder.HtmlBody = string.Format(msg);

                if (anexo != null)
                    builder.Attachments.Add("Curriculo.pdf", anexo, new ContentType("application", "pdf"));


                mimeMessage.Body = builder.ToMessageBody();

                //mimeMessage.HtmlBody = string.Format(message.Content)
                //mimeMessage.Body = new TextPart("plain")
                //{
                //    Text = msg

                //};

                using (var client = new SmtpClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(_emailConfig.Smtp, _emailConfig.Porta, true);
                    client.Authenticate(_emailConfig.User, _emailConfig.Passwd);


                    await client.SendAsync(mimeMessage);

                    client.Disconnect(true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EnviarFaleConosco(string assunto, string msg, MailboxAddress remetente, MailboxAddress destinatario, string copia, byte[] anexo)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(remetente);
                mimeMessage.To.Add(destinatario);

                string[] adrs = copia.Split(',');

                foreach (string item in adrs)
                {
                    if (!string.IsNullOrEmpty(item)) { mimeMessage.Cc.Add(new MailboxAddress("", item)); ; }
                }

                mimeMessage.Subject = assunto;

                var builder = new BodyBuilder();

                builder.HtmlBody = string.Format(msg);

                if (anexo != null)
                    builder.Attachments.Add("Curriculo.pdf", anexo, new ContentType("application", "pdf"));


                mimeMessage.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(_emailConfig.Smtp, _emailConfig.Porta, true);
                    client.Authenticate(_emailConfig.User, _emailConfig.Passwd);


                    await client.SendAsync(mimeMessage);

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
*/
    }

}
