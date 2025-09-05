using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace exp.dados.Seguranca
{
    public class AcessoRestritoAttribute : AuthorizeAttribute
    {
        public AcessoRestritoAttribute()
        {
            Roles = string.Empty;
        }

        public AcessoRestritoAttribute(params string[] perfis)
        {
            Roles = string.Join(",", perfis);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var login = HttpContext.Current.User.Identity.Name;
                // var user = usuarioRepositorio.ObterPorId(id.Value, true);
                //.FirstOrDefault(x => x.Login.Equals(login));

                if (string.IsNullOrWhiteSpace(Roles))
                {
                    HandleUnauthorizedRequest(filterContext);
                    return;
                }

                //se não possuir nenhuma regra
                //var perfis = user.ObterPerfis();
                //if (perfis.Count == 0)
                //{
                //    HandleUnauthorizedRequest(filterContext);
                //    return;
                //}


                //var usuarioRepositorio = new usuarioRepositorio();
                //var _usuario = usuarioRepositorio.RecuperarUsuariosLogin(email, senha, true);

                //if (_usuario == null)
                //{
                //    return false;
                //}
                //else
                //{
                //    List<string> permissoes = new List<string>();

                //    foreach (var permissao in _usuario.menuadms)
                //        permissoes.Add(permissao.id.ToString() + "Permissao");

                //    if (_usuario.Adm)
                //    {
                //        permissoes.Add("Administrator");
                //    }

                //    _autenticacao.Logar(_usuario.Nome, _usuario.id, permissoes.ToArray());

                //    return true;
                //}


                var id = (FormsIdentity)HttpContext.Current.User.Identity;
                // HttpContext.Current.User = new GenericPrincipal(id, perfis.ToArray());
            }

            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                //envia a VIEW "AcessoRestrito".
                filterContext.Result = new PartialViewResult { ViewName = "AcessoRestrito" };
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
}