using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Util
{
    public class Push
    {
     
        public static async Task<bool> EnviarNotificacao(string filtroSCPHub, string tag, string titulo, string mensagem)
        {
            bool retorno = true;
            try
            {
                #region Envio HubPush
                var Hub = SetHUB(filtroSCPHub);
                var notificationFiltro = new Dictionary<string, string> { { "message", mensagem }, { "title", titulo } };
                var outcomeFiltro = await Hub.SendTemplateNotificationAsync(notificationFiltro, tag);
                if (outcomeFiltro != null)
                {
                    if (!((outcomeFiltro.State == NotificationOutcomeState.Abandoned) || (outcomeFiltro.State == NotificationOutcomeState.Unknown)))
                    {
                        Console.WriteLine($"Aviso {titulo} enviado para os usuarios do SCP {tag}");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message + "-" + filtroSCPHub + "-" + tag);
                //retorno = false;
            }
            return retorno;
        }
        
        public static NotificationHubClient SetHUB(string SCP)
        {
            var configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                  "SCP1ConsorcioPush");

            if (SCP.ToUpper() == "SCP2")
            {
                configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                                  "SCP2ConsorcioPush");

            }
            else if (SCP.ToUpper() == "SCP3")
            {
                configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                                 "SCP3ConsorcioPush");

            }
            else if (SCP.ToUpper() == "SCP4")
            {
                configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                               "SCP4ConsorcioPush");

            }
            else if (SCP.ToUpper() == "SCP5")
            {
                configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                         "SCP5ConsorcioPush");

            }
            else if (SCP.ToUpper() == "SCP6")
            {
                configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                         "SCP6ConsorcioPush");

            }
            else if (SCP.ToUpper() == "SCP7")
            {
                configHub = NotificationHubClient.CreateClientFromConnectionString("stringconn",
                                                                         "SCP7ConsorcioPush");

            }

            return configHub;
        }
    }
}
