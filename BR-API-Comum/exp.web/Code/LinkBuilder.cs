using System.Web.Mvc;

namespace exp.web.Code
{
    public static class LinkBuilder
    {
        public static string AcaoPaginacao(this UrlHelper helper, string action, string controle, string area = "",
            int? pagina = 1, string ordem = "", string busca = "")
        {
            var urlatual = "";

            if (area != "") urlatual = "/" + area;

            urlatual += "/" + controle + "/" + action + "/?pagina=" + pagina + "&ordem=" + pagina + "&buscaatual=" +
                        busca + "";


            return urlatual;
            //return helper.Action(action, controle, new { pagina = pagina, ordem = ordem, busca = busca, area = area });
        }


        public static string Informativo(this UrlHelper helper, int? pagina = 1)
        {
            return helper.Action("Index", "informativo", new { pagina, area = "inside" });
        }


        public static string Leis(this UrlHelper helper, int? pagina = 1)
        {
            return helper.Action("Index", "Leis", new { pagina, area = "inside" });
        }


        public static string Fotos(this UrlHelper helper, int? pagina = 1)
        {
            return helper.Action("Index", "fotos", new { pagina, area = "inside" });
        }


        //public static string Infoler(this UrlHelper helper, int id, string acessoSeo)
        //{
        //    return helper.Action("Index", "informativo", new { id = id, acessoSeo = acessoSeo, area = "inside" });
        //}

        public static string InfoSite(this UrlHelper helper, int id, string acessoSeo)
        {
            return helper.Action("detalhe", "Noticias", new { id, acessoSeo });
        }


        //public static string Infobusca(this UrlHelper helper, int? pagina = 1, string search = "")
        //{
        //    return helper.Action("Details", "informativo", new { pagina = pagina, search = search, area = "inside" });
        //}


        //public static string Post(this UrlHelper helper, int id, string acessoSeo)
        //{
        //    return helper.Action("Detalhe", "Posts", new { id = id, acessoSeo = acessoSeo });
        //}

        //public static string Comentario(this UrlHelper helper)
        //{
        //    return helper.Action("Comentar", "Posts");
        //}

        //public static string Categorias(this UrlHelper helper, int? id = null, string acessoSeo = null)
        //{
        //    return helper.Action("Index", "Categorias", new { id = id, acessoSeo = acessoSeo });
        //}

        //public static string Sobre(this UrlHelper helper)
        //{
        //    return helper.Action("Index", "Sobre");
        //}

        //public static string Contato(this UrlHelper helper)
        //{
        //    return helper.Action("Index", "Contato");
        //}

        //public static string Login(this UrlHelper helper)
        //{
        //    return helper.Action("Index", "Login", new { area = String.Empty });
        //}

        //public static string Logout(this UrlHelper helper)
        //{
        //    return helper.Action("Logout", "Login", new { area = String.Empty });
        //}


        #region Admin

        //public static string AdicionarPost(this UrlHelper helper)
        //{
        //    return helper.Action("Index", "Posts", new { area = "Admin" });
        //}

        //public static string EditarPost(this UrlHelper helper, int id)
        //{
        //    return helper.Action("Index", "Posts", new { id = id, area = "Admin" });
        //}

        //public static string ExcluirPost(this UrlHelper helper, int id)
        //{
        //    return helper.Action("Excluir", "Posts", new { id = id, area = "Admin" });
        //}

        public static string ActionUsuario(this UrlHelper helper)
        {
            return helper.Action("Action", "Admin", new { area = "Admin" });
        }

        //public static string GerenciarCategorias(this UrlHelper helper)
        //{
        //    return helper.Action("Index", "Categorias", new { area = "Admin" });
        //}

        //public static string ExcluirCategoria(this UrlHelper helper)
        //{
        //    return helper.Action("Excluir", "Categorias", new { area = "Admin" });
        //}

        //public static string GerenciarComentarios(this UrlHelper helper)
        //{
        //    return helper.Action("Index", "Comentarios", new { area = "Admin" });
        //}

        //public static string ExcluirComentario(this UrlHelper helper)
        //{
        //    return helper.Action("Excluir", "Comentarios", new { area = "Admin" });
        //}

        #endregion
    }
}