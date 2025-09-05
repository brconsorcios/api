using System.Web.Mvc;

namespace exp.web.Code
{
    public static class ContentBuilder
    {
        public static string Css(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/css/{0}", file));
        }

        public static string CssAdm(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/expadm/css/{0}", file));
        }

        public static string Script(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/Scripts/{0}", file));
        }


        public static string ScriptAdm(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/expadm/js/{0}", file));
        }

        public static string ImgAdm(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/expadm/images/{0}", file));
        }

        public static string Imagem(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/img/{0}", file));
        }

        public static string Uploads(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/arquivos/{0}", file));
        }


        public static string PrettyPhotoCss(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/prettyPhoto/css/{0}", file));
        }

        public static string PrettyPhotoScript(this UrlHelper helper, string file)
        {
            return helper.Content(string.Format("~/content/prettyPhoto/js/{0}", file));
        }
    }
}