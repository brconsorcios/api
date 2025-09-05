using System.Threading;
using exp.core.Utilitarios;

namespace exp.dados
{
    public static class GerarDocsCompra
    {
        public static void ObterTodos(int id, string UrlApi, string ApiLogin, string ApiPass, string ApiPasta)
        {
            ObterBoletodaCompra(id, UrlApi, ApiLogin, ApiPass, ApiPasta);
            Thread.Sleep(2);
            ObterPropostadaCompra(id, UrlApi, ApiLogin, ApiPass, ApiPasta);
            Thread.Sleep(2);
            ObterContratodaCompra(id, UrlApi, ApiLogin, ApiPass, ApiPasta);
        }


        public static string ObterBoletodaCompra(int id, string UrlApi, string ApiLogin, string ApiPass,
            string ApiPasta)
        {
            var httpb = new HttpHelpers(UrlApi, ApiLogin, ApiPass);
            var resposta =
                httpb.Post<string, HttpResposta<string>>(ApiPasta + "EmitirBoletodaCompra/?id=" + id, null, true);

            if (resposta != null)
            {
                if (resposta.erros == null)
                    //deucerto
                    return resposta.objeto;

                //deu erro
                return string.Empty;
            }

            //deu erro
            return string.Empty;
        }

        public static string ObterPropostadaCompra(int id, string UrlApi, string ApiLogin, string ApiPass,
            string ApiPasta)
        {
            var httpb = new HttpHelpers(UrlApi, ApiLogin, ApiPass);
            var resposta =
                httpb.Post<string, HttpResposta<string>>(ApiPasta + "EmitirPropostadaCompra/?id=" + id, null, true);

            if (resposta != null)
            {
                if (resposta.erros == null)
                    //deucerto
                    return resposta.objeto;

                //deu erro
                return string.Empty;
            }

            //deu erro
            return string.Empty;
        }


        public static string ObterContratodaCompra(int id, string UrlApi, string ApiLogin, string ApiPass,
            string ApiPasta)
        {
            var httpb = new HttpHelpers(UrlApi, ApiLogin, ApiPass);
            var resposta =
                httpb.Post<string, HttpResposta<string>>(ApiPasta + "EmitirContratodaCompra/?id=" + id, null, true);

            if (resposta != null)
            {
                if (resposta.erros == null)
                    //deucerto
                    return resposta.objeto;

                //deu erro
                return string.Empty;
            }

            //deu erro
            return string.Empty;
        }


        public static string ObterBoleto2Via(int id, string UrlApi, string ApiLogin, string ApiPass, string ApiPasta)
        {
            var httpb = new HttpHelpers(UrlApi, ApiLogin, ApiPass);
            var resposta =
                httpb.Post<string, HttpResposta<string>>(ApiPasta + "EmitirBoleto2Via/?id=" + id, null, true);

            if (resposta != null)
            {
                if (resposta.erros == null)
                    //deucerto
                    return resposta.objeto;

                //deu erro
                return string.Empty;
            }

            //deu erro
            return string.Empty;
        }
        
    }
}