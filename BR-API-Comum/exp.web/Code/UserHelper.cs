using System;
using System.Web;

namespace exp.web.Code
{
    public static class UserHelper
    {
        public static bool IsAutenticado => HttpContext.Current.User.Identity.IsAuthenticated;

        public static int Id => Convert.ToInt32(GetValue()[0]);

        public static string Nome => GetValue()[1];

        public static string Email => GetValue()[2];

        private static string[] GetValue()
        {
            return HttpContext.Current.User.Identity.Name.Split(';');
        }
    }
}