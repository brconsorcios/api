using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using exp.core;
using exp.core.Utilitarios;
using exp.dados;

namespace exp.web.Code
{
    public class AcessoWebApiExpertu
    {

        public static string ConsultarIndexadorProduto(int ID_Bem)
        {
            var UrlApi = SiteSettings.ExpAPIurl;
            var ApiLogin = SiteSettings.ExpAPIlogin;
            var ApiPass = SiteSettings.ExpAPIsenha;
            var ApiPasta = SiteSettings.ExpAPIpasta;

            var http = new HttpHelpers(UrlApi, ApiLogin, ApiPass);

            return http.Get<string>(ApiPasta + "/api/ConsultarIndexadorProduto?ID_Bem=" + ID_Bem, true);
        }

        /// <summary>
        ///     Método para obter a vagas disponíveis do grupo
        /// </summary>
        /// <returns></returns>
        public static List<ConsultarVagaGrupoResult> ConsultarVagaGrupo()
        {
            var UrlApi = SiteSettings.ExpAPIurl;
            var ApiLogin = SiteSettings.ExpAPIlogin;
            var ApiPass = SiteSettings.ExpAPIsenha;
            var ApiPasta = SiteSettings.ExpAPIpasta;

            var http = new HttpHelpers(UrlApi, ApiLogin, ApiPass);

            return http.Get<List<ConsultarVagaGrupoResult>>(ApiPasta + "/api/ConsultarVagaGrupo", true);
        }

        /// <summary>
        ///     Método para obter a data da assembleia e vendimento do grupo
        /// </summary>
        /// <param name="ID_Assembleia"></param>
        /// <param name="ID_Grupo"></param>
        /// <returns></returns>
        public static ConsultarAssembleiaResult ConsultarAssembleia(int? ID_Assembleia, int ID_Grupo)
        {
            var UrlApi = SiteSettings.ExpAPIurl;
            var ApiLogin = SiteSettings.ExpAPIlogin;
            var ApiPass = SiteSettings.ExpAPIsenha;
            var ApiPasta = SiteSettings.ExpAPIpasta;

            if (ID_Assembleia > 0)
            {
                var http = new HttpHelpers(UrlApi, ApiLogin, ApiPass);

                return http.Get<ConsultarAssembleiaResult>(
                    ApiPasta + $"/api/ConsultarAssembleia?ID_Assembleia={ID_Assembleia}&ID_Grupo={ID_Grupo}", true);
            }

            return new ConsultarAssembleiaResult();
        }


        public static List<ConsultarPlanoVendaUnidadeResult> ConsultarPlanoVendaUnidade()
        {
            var UrlApi = SiteSettings.ExpAPIurl;
            var ApiLogin = SiteSettings.ExpAPIlogin;
            var ApiPass = SiteSettings.ExpAPIsenha;
            var ApiPasta = SiteSettings.ExpAPIpasta;

            try
            {
                var http = new HttpHelpers(UrlApi, ApiLogin, ApiPass);

                return http.Get<List<ConsultarPlanoVendaUnidadeResult>>(ApiPasta + "/api/ConsultarPlanoVendaUnidade",
                    true);
            }
            catch
            {
                return new List<ConsultarPlanoVendaUnidadeResult>();
            }
        }

        public static bool AtualizarFaturaDigital(string Lista_ID_Cota)
        {
            var UrlApi = SiteSettings.ExpAPIurl;
            var ApiLogin = SiteSettings.ExpAPIlogin;
            var ApiPass = SiteSettings.ExpAPIsenha;
            var ApiPasta = SiteSettings.ExpAPIpasta;

            try
            {
                var http = new HttpHelpers(UrlApi, ApiLogin, ApiPass);
                var retorno = false;
                if (bool.TryParse(
                        http.Get<string>(ApiPasta + $"/api/AtualizarFaturaDigital?Lista_ID_Cota={Lista_ID_Cota}", true)
                            .ToLower(), out retorno)) return retorno;

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}