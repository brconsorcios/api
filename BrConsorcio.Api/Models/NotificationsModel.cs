using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrConsorcio.Api.Models
{
    public class NotificationsModel
    {
        public static NotificationsModel Instance = new NotificationsModel();

        public NotificationHubClient HubScp1 { get; set; }
        public NotificationHubClient HubScp2 { get; set; }
        public NotificationHubClient HupScp3 { get; set; }
        public NotificationHubClient HupScp4 { get; set; }
        public NotificationHubClient HupScp5 { get; set; }
        public NotificationHubClient HupScp6 { get; set; }
        public NotificationHubClient HupScp7 { get; set; }


        private NotificationsModel()
        {
            HubScp1 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                              "Scp1ConsorcioPush");
            HubScp2 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                                  "Scp2ConsorcioPush");

            HupScp3 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                                 "Scp3ConsorcioPush");

            HupScp4 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                               "Scp4ConsorcioPush");

            HupScp5 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                         "Scp5ConsorcioPush");

            HupScp6 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                         "Scp6ConsorcioPush");

            HupScp7 = NotificationHubClient.CreateClientFromConnectionString("connstring",
                                                                         "Scp7ConsorcioPush");

        }
    }
}
