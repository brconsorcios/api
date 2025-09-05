using System.IO;
using System.Web.Hosting;
using exp.dados;

namespace exp.web.Code
{
    public class PropostaNova
    {
        public indicaco indicacao { get; set; }
        
        //public ben ben { get; set; }
        public site site { get; set; }
        public string path { get; set; }

        public string Emitir() //int id, int site)
        {
            if (indicacao != null || site != null)
            {
                var layout = Layout.Gerar(site.id_site);

                var novaproposta = new GerarPropostaPdf();

                novaproposta.NM_empresa = "";
                novaproposta.path_imagens =
                    HostingEnvironment.MapPath("~/content/logos/"); //Server.MapPath("~/content/imagesboleto/");
                if (!string.IsNullOrEmpty(path))
                    novaproposta.path_do_pdf = path;
                else
                    novaproposta.path_do_pdf =
                        HostingEnvironment.MapPath("~/content/propostas/"); //Server.MapPath("~/content/boletos/");
                novaproposta.none_do_pdf =
                    "proposta_" + indicacao.id + "_" + indicacao.id_documento + ".pdf"; //DateTime.Now.Ticks
                //novaproposta.logomarca = layout.logomarca; //"/bradesco_color.jpg";//"/hsbc_color.jpg"  "/bradesco_color.jpg" "/banese_color.jpg"
                //novaproposta.ImgTitulo = layout.ImgTitulo;
                // novaproposta.background_imgem = "/br-loader.jpg";

                novaproposta.indicacao = indicacao;
                novaproposta.site = site;
                novaproposta.Layout = layout;


                if (novaproposta.executar())
                    // return Redirect("/content/boletos/" + novaproposta.none_do_pdf);
                    return novaproposta.none_do_pdf;

                if (File.Exists(novaproposta.path_do_pdf + novaproposta.none_do_pdf)) return novaproposta.none_do_pdf;

                return string.Empty;
            }

            return string.Empty;
        }
    }
}