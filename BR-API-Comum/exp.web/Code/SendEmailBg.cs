using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading;
using exp.core.Utilitarios;

namespace exp.web.Code
{
    public class SendEmailBg
    {
        private SmtpClient Smtp = new SmtpClient();

        // constructor
        public SendEmailBg()
        {
            To = new List<string>();
            CC = new List<string>();
            BCC = new List<string>();
            File = new List<string>();
            ReplyTo = new List<string>();
            setupSMTPClients();
        }

        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public List<string> File { get; set; }
        public List<string> ReplyTo { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailReadReceiptTo { get; set; }
        public string EmailDispositionNotificationTo { get; set; }
        public string EmailMessageId { get; set; }
        public string EmailInReplyTo { get; set; }
        public bool OnFailure { get; set; }
        public bool OnSuccess { get; set; }

        private void setupSMTPClients()
        {
            var mailSettings = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

            var smtpClient = new SmtpClient();

            if (mailSettings.DeliveryMethod == SmtpDeliveryMethod.Network)
            {
                smtpClient.Host = mailSettings.Network.Host;
                smtpClient.Port = mailSettings.Network.Port;
                smtpClient.EnableSsl = mailSettings.Network.EnableSsl;
                smtpClient.UseDefaultCredentials = mailSettings.Network.DefaultCredentials;
                var netCredit =
                    new NetworkCredential(mailSettings.Network.UserName,
                        mailSettings.Network.Password); //, "DOMAIN_NAME");
                smtpClient.Credentials = netCredit;
            }

            From = mailSettings.From;

            //SmtpClient smtpcliente = new SmtpClient();
            //smtpcliente.Host = "email-ssl.com.br";
            //smtpcliente.Port = 587;
            //smtpcliente.UseDefaultCredentials = false;
            //System.Net.NetworkCredential netCredit = new System.Net.NetworkCredential("notificacoes@brconsorcios.com.br", "S3rV3r010816");//, "DOMAIN_NAME");
            //smtpcliente.Credentials = netCredit;
            //smtpcliente.EnableSsl = true;

            Smtp = smtpClient;
        }

        private void disposeSMTPClients()
        {
            try
            {
                Smtp.Dispose();
            }
            catch (Exception ex)
            {
                //Log Exception
            }
        }

        private MailMessage Message()
        {
            var message = new MailMessage();

            message.From = new MailAddress(From);

            foreach (var x in ReplyTo) message.ReplyToList.Add(x);

            foreach (var x in To) message.To.Add(x);
            if (CC != null)
                foreach (var x in CC)
                    message.CC.Add(x);

            if (BCC != null)
                foreach (var x in BCC)
                    message.Bcc.Add(x);

            if (File != null)
                foreach (var x in File)
                    message.Attachments.Add(new Attachment(x));

            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;
            if (OnFailure && !OnSuccess)
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            if (!OnFailure && OnSuccess)
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            if (OnFailure && OnSuccess)
                message.DeliveryNotificationOptions =
                    DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.OnSuccess;
            if (!string.IsNullOrWhiteSpace(EmailReadReceiptTo))
                message.Headers.Add("Read-Receipt-To",
                    EmailReadReceiptTo); //("Read-Receipt-To", "suporte02@brconsorcios.com.br");
            if (!string.IsNullOrWhiteSpace(EmailDispositionNotificationTo))
                message.Headers.Add("Disposition-Notification-To",
                    EmailDispositionNotificationTo); //("Disposition-Notification-To", "suporte02@expertu.com.br");
            if (!string.IsNullOrWhiteSpace(EmailMessageId))
                message.Headers.Add("Message-Id",
                    "<" + EmailMessageId + ">"); //("Message-Id", "<telecomfaturas_" + email.id + "@expertu.com.br>");
            if (!string.IsNullOrWhiteSpace(EmailInReplyTo))
                message.Headers.Add("in-reply-to",
                    "<" + EmailInReplyTo + ""); //("in-reply-to", "<telecomfaturas_" + email.id + "@expertu.com.br>");


            if (!EnvironmentHelpers.IsProduction())
            {
                Subject = "***TESTE*** " + Subject;
                Body = Body.Replace("<body>", "<body><h1 style=\"color: red; \">*** TESTE ***</h1>");
            }

            message.Subject = Subject;
            message.Body = Body;
            message.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            message.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            return message;
        }

        public void StartEmailRun()
        {
            try
            {
                var msg = Message();

                //Thread email = new Thread(delegate()
                //{
                //    Smtp.Send(msg);
                //    Thread.Sleep(1);
                //    Smtp.Dispose();
                //});
                //email.IsBackground = true;
                //email.Start();


                if (Monitor.TryEnter(Smtp))
                {
                    try
                    {
                        Smtp.Send(msg);
                    }
                    finally
                    {
                        Monitor.Exit(Smtp);
                    }

                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                //Log error
            }
            finally
            {
                disposeSMTPClients();
            }
        }
    }
}