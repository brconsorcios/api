using System.Web.Mvc;

namespace exp.web.Code
{
    public static class IndicacoesHelpers
    {
        public static MvcHtmlString StatusIndicacao(this HtmlHelper html, int status, bool IsInteracao = false)
        {
            var tag = new TagBuilder("i");
            var span = new TagBuilder("span");
            var strStatus = StringStatus(status, IsInteracao);

            tag.AddCssClass(strStatus[0]);
            span.InnerHtml = string.Format("{0} {1}", tag, strStatus[1]);

            return MvcHtmlString.Create(span.ToString());
        }

        //public static MvcHtmlString StatusInteracao(this HtmlHelper html, int status)
        //{
        //    var tag = new TagBuilder("i");
        //    var span = new TagBuilder("span");
        //    var strStatus = StringStatus(status);

        //    tag.AddCssClass(strStatus[0]);
        //    span.InnerHtml = String.Format("{0} {1}", tag.ToString(), strStatus[1]);

        //    return MvcHtmlString.Create(span.ToString());
        //}

        public static string[] StringStatus(int status, bool IsInteracao)
        {
            var str = new[] { "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADA" };

            switch (status)
            {
                case 0:

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADA" };

                    break;
                case 1:
                    //str = "glyphicon glyphicon-flag img-circle baseicone label-success";

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-flag img-circle baseicone label-success", "NOVA" };
                    break;
                case 2:
                    //str = "glyphicon glyphicon-transfer img-circle baseicone label-info";

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-transfer img-circle baseicone label-info", "NEGOCIAÇÃO" };
                    break;
                case 3:
                    //str = "glyphicon glyphicon-transfer img-circle baseicone label-info";

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-transfer img-circle baseicone label-info", "AGENDADA" };
                    break;
                case 4:
                    //str = "glyphicon glyphicon-ok img-circle baseicone label-primary";

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-ok img-circle baseicone label-primary", "VENDIDA" };
                    break;
                case 5:
                    //str = "glyphicon glyphicon-remove img-circle baseicone label-danger";

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-remove img-circle baseicone label-danger", "CANCELADA" };
                    break;
                default:
                    //str = "glyphicon glyphicon-sort img-circle baseicone label-warning";

                    if (IsInteracao)
                        str = new[]
                        {
                            "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADAS"
                        };
                    else
                        str = new[] { "glyphicon glyphicon-sort img-circle baseicone label-warning", "NÃO FINALIZADA" };
                    break;
            }

            return str;
        }
    }
}