using BrConsorcio.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.NotificationHubs.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    public class NotificacaoController : Controller
    {
        public NotificationHubClient hub { get; set; }

        public NotificacaoController()
        {

        }

        public class DeviceRegistration
        {
            public string Platform { get; set; }
            public string Handle { get; set; }
            public string[] Tags { get; set; }
        }

        // POST api/register
        // This creates a registration id
        [HttpPost]
        [Route("RegistrarId")]
        public async Task<string> Post(string handle = null, string SCP = null)
        {
            hub = SetHUB(SCP);
            string newRegistrationId = null;

            // make sure there are no existing registrations for this push handle (used for iOS and Android)
            if (handle != null)
            {
                var registrations = await hub.GetRegistrationsByChannelAsync(handle, 100);

                foreach (RegistrationDescription registration in registrations)
                {

                    if (newRegistrationId == null)
                    {
                        newRegistrationId = registration.RegistrationId;
                    }
                    else
                    {
                        await hub.DeleteRegistrationAsync(registration);
                    }
                }
            }

            if (newRegistrationId == null)
                newRegistrationId = await hub.CreateRegistrationIdAsync();

            return newRegistrationId;
        }

        // PUT api/register/5
        // This creates or updates a registration (with provided channelURI) at the specified id
        [HttpPut]
        [Route("RegistrarTag")]
        public async Task<bool> Put(string id, [FromBody]DeviceRegistration deviceUpdate, string SCP = null)
        {
            bool ret = true;

            hub = SetHUB(SCP);

            RegistrationDescription registration = null;

            switch (deviceUpdate.Platform)
            {
                case "iOS":
                    var alertTemplate = "{\"aps\":{\"title\":\"$(title)\", \"alert\":\"$(message)\",\"pagina\":\"$(pagina)\"}}";

                    registration = new AppleTemplateRegistrationDescription(deviceUpdate.Handle, alertTemplate);
                    break;
                case "Android":
                    var messageTemplate = "{\"data\":{ \"title\":\"$(title)\", \"message\":\"$(message)\",\"pagina\":\"$(pagina)\"}}";
                    registration = new FcmTemplateRegistrationDescription(deviceUpdate.Handle, messageTemplate);
                    break;
                default:
                    throw new ArgumentNullException(nameof(HttpStatusCode.BadRequest));
                    //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            registration.RegistrationId = id;

            // add check if user is allowed to add these tags
            registration.Tags = new HashSet<string>(deviceUpdate.Tags);

            try
            {
                await hub.CreateOrUpdateRegistrationAsync(registration);
            }
            catch (MessagingException e)
            {
                ret = false;
                ReturnGoneIfHubResponseIsGone(e);
            }

            return ret;
        }

        [HttpDelete]
        [Route("RemoverId")]
        // DELETE api/register/5
        public async Task<bool> Delete(string id, string SCP = null)
        {
            bool ret = true;

            hub = SetHUB(SCP);

            try
            {
                await hub.DeleteRegistrationAsync(id);
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }

        private static void ReturnGoneIfHubResponseIsGone(MessagingException e)
        {
            var webex = e.InnerException as WebException;
            if (webex.Status == WebExceptionStatus.ProtocolError)
            {
                var response = (HttpWebResponse)webex.Response;
                if (response.StatusCode == HttpStatusCode.Gone)
                    throw new HttpRequestException(HttpStatusCode.Gone.ToString());
            }
        }

        private NotificationHubClient SetHUB(string SCP)
        {
            if (SCP.ToUpper() == "SCP1")
            {
                return NotificationsModel.Instance.HubScp1;
            }
            else if (SCP.ToUpper() == "SCP2")
            {
                return NotificationsModel.Instance.HubScp2;
            }
            else if (SCP.ToUpper() == "SCP3")
            {
                return NotificationsModel.Instance.HupScp3;
            }
            else if (SCP.ToUpper() == "SCP4")
            {
                return NotificationsModel.Instance.HupScp4;
            }
            else if (SCP.ToUpper() == "SCP5")
            {
                return NotificationsModel.Instance.HupScp5;
            }
            else if (SCP.ToUpper() == "SCP6")
            {
                return NotificationsModel.Instance.HupScp6;
            }
            else if (SCP.ToUpper() == "SCP7")
            {
                return NotificationsModel.Instance.HupScp7;
            }

            return null;
        }
    }
}