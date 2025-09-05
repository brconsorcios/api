using System;
using System.Configuration;
using System.Linq;
using System.Web;
using exp.core.Extensions;
using exp.dados;

namespace exp.web.Code
{
    using conf = ConfigurationManager;

    public static class UserWebApiHelper
    {
        public static bool IsAutenticado
        {
            get
            {
                if (Id <= 0) return false;

                return true;
            }
        }

        public static int Id
        {
            get
            {
                if (GetValue()[0] != "") return Convert.ToInt32(GetValue()[0]);

                return 0;
            }
        }

        public static string Nome => GetValue()[1] ?? string.Empty;

        public static string Login => GetValue()[2];

        public static string Empresa => GetValue()[3];

        private static string[] GetValue()
        {
            var ArrayString = string.Empty;
            // string cookieId = string.Empty;

            var islogin = HttpContext.Current.Request.Cookies[NameCookie()];
            if (islogin != null)
            {
                var cookieId = Cryptography.Descriptografar(islogin.Value);
                var cookID = Convert.ToInt32(cookieId);

                var model = HttpContext.Current.Items["ApiLoginCache" + cookID] as site;

                // var model = Context.sites.Where(u => u.id_site == cookID).FirstOrDefault();
                if (model != null)
                    ArrayString = "" + model.id_site + ";" + model.nome + ";" + model.login + ";" + model.id_empresa +
                                  ";";
            }

            return ArrayString.Split(';');
        }

        private static string NameCookie()
        {
            var namecok = conf.AppSettings["CookieConfigKey"];
            return namecok;
        }
    }
}