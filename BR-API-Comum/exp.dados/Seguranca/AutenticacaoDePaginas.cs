using System;
using System.Web;
using System.Web.Security;

namespace exp.dados.Seguranca
{
    public class AutenticacaoDePaginas
    {
        //public void Logar(string nome, int id, string[] regras)
        public void Logar(string[] userlogado, string[] regras)
        {
            var regrasSeparadasPorVirgulas = string.Join(",", regras);
            var chave = string.Join(";", userlogado);
            //new string[] { "10", "Wesdra Lima", "wesdra@expertu.com.br" }
            FormsAuthentication.Initialize();
            var ticket =
                new FormsAuthenticationTicket(
                    1, //Uma versão bilhete fictício
                    chave, //Nome de usuário para quem o bilhete é emitido
                    DateTime.Now, //Data e hora atual
                    DateTime.Now.AddMinutes(120), //Data e hora de expiração
                    true, //Se persistir cookie no lado do cliente. Se for verdade,
                    //o bilhete de autenticação será emitido para novas sessões do PC mesmo cliente
                    regrasSeparadasPorVirgulas, //Separados por vírgula funções de usuário (Role)
                    FormsAuthentication.FormsCookiePath); //Path cookie valid for

            //Criptografar o tíquete de autenticação
            var encrypetedTicket = FormsAuthentication.Encrypt(ticket);

            if (!FormsAuthentication.CookiesSupported)
            {
                //Se o tíquete de autenticação é especificada não usar cookies, configurá-lo na URL
                FormsAuthentication.SetAuthCookie(encrypetedTicket, false);
            }
            else
            {
                // Se o tíquete de autenticação é especificado para usar um cookie,
                // envolvê-la dentro de um cookie.
                // O nome do cookie padrão é. ASPXAUTH se não especificado
                // no elemento <forms> no web.config
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypetedTicket);
                //Definir o tempo de validade do cookie para o tempo de expiração de bilhetes
                authCookie.Expires = ticket.Expiration;
                //Definir o cookie na resposta
                HttpContext.Current.Response.Cookies.Add(authCookie);

                //Cria um cookie e coloca o id do usuario
                //HttpCookie idCookie = new HttpCookie("TCGLkoo", Convert.ToString(id));
                //idCookie.Expires = DateTime.Now.AddDays(+1d);
                //HttpContext.Current.Response.Cookies.Add(idCookie);
            }
        }

        public void Deslogar()
        {
            //Logout
            FormsAuthentication.SignOut();

            //Elimina o Cookie que contem o id do usuario
            //HttpCookie idCookie = new HttpCookie("TCGLkoo", "");
            //idCookie.Expires = DateTime.Now.AddDays(-1d);
            //HttpContext.Current.Response.Cookies.Add(idCookie);
        }
    }
}