using System;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using exp.web.Code;
using Newtonsoft.Json;
//using System.Web.Optimization;

namespace exp.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            //var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            //settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            // jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());

            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Arrays;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();

        }

        /// <summary>
        ///     Adiciona funções para o usuário atual HttpContext
        ///     após a autenticação de formulários autentica o usuário
        ///     de modo que, o mecanismo de autorização pode autorizar
        ///     usuário com base nos grupos / funções do usuário
        /// </summary>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            SetWorkingCulture();

            if (HttpContext.Current.User != null)
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        // Se cookie não é suportado para a autenticação de formulários, então o
                        // bilhete de autenticação é armazenado na URL, que é criptografado.
                        // Então, decifrá-lo
                        var id = (FormsIdentity)HttpContext.Current.User.Identity;
                        var ticket = id.Ticket;

                        // Obter o armazenado de dados do usuário, neste caso, as funções do usuário
                        var userData = ticket.UserData;
                        var roles = userData.Split(',');
                        // Funções foram colocados na propriedade UserData no tíquete de autenticação
                        // enquanto criando
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
        }

        //Padriniza a  data em português
        protected void SetWorkingCulture()
        {
            var culture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}