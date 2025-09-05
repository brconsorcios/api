using System.Linq;
using System.Security.Principal;

namespace exp.web.Code
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string Username, string[] roles)
        {
            Identity = new GenericIdentity(Username);
            this.roles = roles;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] roles { get; set; }
        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            if (roles.Any(r => role.Contains(r))) return true;

            return false;
        }
    }
}