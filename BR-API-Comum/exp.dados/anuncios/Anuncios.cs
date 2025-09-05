using System;
using System.Web;
using exp.core.Extensions;

namespace exp.dados
{
    public class Anuncios
    {
        public static bool Salvar(string id, string name, string host)
        {
            try
            {
                //Criando um objeto cookie
                var UserCookie = new HttpCookie(name);
                //Setando o ID do usuário no cookie
                UserCookie.Value = Cryptography.Criptografar(id);
                //Definindo o prazo de vida do cookie
                UserCookie.Expires = DateTime.Now.AddMonths(1);
                //UserCookie.Domain = host;
                //Adicionando o cookie no contexto da aplicação
                HttpContext.Current.Response.Cookies.Add(UserCookie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Apagar(string name)
        {
            try
            {
                var UserCookie = new HttpCookie(name);
                UserCookie.Expires = DateTime.Now.AddMonths(-1);
                HttpContext.Current.Response.Cookies.Add(UserCookie);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}