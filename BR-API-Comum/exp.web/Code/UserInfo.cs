using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace exp.web.Code
{
    public static class UserInfo
    {
        public static string GetAddressesIP() //IEnumerable<string> GetAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return (from ip in host.AddressList
                where ip.AddressFamily == AddressFamily.InterNetwork
                select ip.ToString()).FirstOrDefault(); //.ToList();
        }
    }
}