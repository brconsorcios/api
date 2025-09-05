namespace exp.dados
{
    public class SiteLayout
    {
        public string logomarca { get; set; }
        public string ImgTitulo { get; set; }
        public string CorFndTitulos { get; set; }
        public string CorFontTitulos { get; set; }
        public string CorFontCampo { get; set; }
        public string CorFontValor { get; set; }
        public string CorFndTabela { get; set; }
        public string NomeEmpresa { get; set; }

        public string UrlSite { get; set; }

        public int? LarguraLogo { get; set; }
    }

    public class Layout
    {
        public static SiteLayout Gerar(int site)
        {
            var layout = new SiteLayout();

            switch (site)
            {
                case 1:
                    layout.logomarca = "1_scp1.png";
                    layout.ImgTitulo = "1_scp1titulo.jpg";
                    layout.CorFndTitulos = "#60a467";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#0d1653";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#c8dfc5";
                    layout.NomeEmpresa = "Consórcio scp1";
                    layout.UrlSite = "www.consorcioscp1.com.br";
                    break;
                case 2:
                    layout.logomarca = "2_scp3.png";
                    layout.ImgTitulo = "2_scp3titulo.jpg";
                    layout.CorFndTitulos = "#014694";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#4362ab";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#cae4f5";
                    layout.NomeEmpresa = "Consórcio scp3";
                    layout.UrlSite = "www.consorcioscp3.com.br";
                    break;
                case 4:
                    layout.logomarca = "4_scp2.jpg";
                    layout.ImgTitulo = "4_scp2titulo.jpg";
                    layout.CorFndTitulos = "#026eb6";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#026eb6";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#cae4f5";
                    layout.NomeEmpresa = "Consórcio scp2";
                    break;
                case 5:
                    layout.logomarca = "5_scp4.png";
                    layout.ImgTitulo = "5_scp4titulo.jpg";
                    layout.CorFndTitulos = "#bf7806";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#0c4da2";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#f8e69a";
                    layout.NomeEmpresa = "Consórcio scp4";
                    layout.UrlSite = "www.consorcioscp4.com.br";
                    break;
                case 6:
                    layout.logomarca = "6_scp5.png";
                    layout.ImgTitulo = "6_scp5titulo.jpg";
                    layout.CorFndTitulos = "#be0411";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f30206";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#e9c5af";
                    layout.NomeEmpresa = "Consórcio scp5";
                    layout.UrlSite = "www.consorcioscp5.com";

                    break;
                case 7:
                    layout.logomarca = "7_scp6.jpg";
                    layout.ImgTitulo = "7_scp6titulo.jpg";
                    layout.CorFndTitulos = "#d27e02";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f37920";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#fff8b4";
                    layout.NomeEmpresa = "Consórcio scp6";

                    break;

                case 8:
                    layout.logomarca = "8_scp7.png";
                    layout.ImgTitulo = "8_scp7titulo.jpg";
                    layout.CorFndTitulos = "#00336d";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#00316c";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#ecf5fc";
                    layout.NomeEmpresa = "Consórcio scp7";
                    layout.UrlSite = "www.consorcioscp7.com.br";
                    break;

                case 9:
                    layout.logomarca = "6_scp8.jpg";
                    layout.ImgTitulo = "6_scp8titulo.jpg";
                    layout.CorFndTitulos = "#be0411";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f30206";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#e9c5af";
                    layout.NomeEmpresa = "Consórcio scp8";
                    break;

                case 10:
                    layout.logomarca = "10_scp6.jpg";
                    layout.ImgTitulo = "10_scp6titulo.jpg";
                    layout.CorFndTitulos = "#d27e02";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f37920";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#fff8b4";
                    layout.NomeEmpresa = "Consórcio scp6";
                    break;

                case 11:
                    layout.logomarca = "11_scp9.jpg";
                    layout.ImgTitulo = "11_scp9titulo.jpg";
                    layout.CorFndTitulos = "#be0411";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f30206";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#f9eff7";
                    layout.NomeEmpresa = "Consórcio scp9";
                    break;

                case 12:
                    layout.logomarca = "12_scp10.png";
                    layout.ImgTitulo = "12_scp10titulo.jpg";
                    layout.CorFndTitulos = "#831717";
                    layout.CorFontTitulos = "#f9eff7";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f30206";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#f9eff7";
                    layout.NomeEmpresa = "Rede scp10 Consorcios";
                    layout.UrlSite = "www.redescp10consorcios.com.br";
                    break;
                case 13:
                    layout.logomarca = "13_scp11.png";
                    layout.ImgTitulo = "13_scp11titulo.jpg";
                    layout.CorFndTitulos = "#CC0000";
                    layout.CorFontTitulos = "#f9eff7";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#f30206";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#efefef";
                    layout.NomeEmpresa = "scp11 Consórcios";
                    layout.UrlSite = "www.scp11consorcios.com.br";
                    break;


                default:
                    layout.logomarca = "0_brconsorcios.png";
                    layout.ImgTitulo = "1_scp1titulo.jpg";
                    layout.CorFndTitulos = "#D0050D";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = layout.CorFndTitulos; //"#0d1653";
                    layout.CorFontValor = "#333333";
                    layout.CorFndTabela = "#f7c8b1";
                    layout.NomeEmpresa = "BR Consórcios";
                    break;
            }

            return layout;
        }

        public static SiteLayout GerarEmail(int site)
        {
            var layout = new SiteLayout();

            switch (site)
            {
                case 1:
                    layout.logomarca = "1_scp1.jpg";
                    layout.ImgTitulo = "1_scp1titulo.jpg";
                    layout.CorFndTitulos = "#01a161";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp1";
                    layout.LarguraLogo = 300;
                    break;
                case 2:
                    layout.logomarca = "2_scp3.jpg";
                    layout.ImgTitulo = "2_scp3titulo.jpg";
                    layout.CorFndTitulos = "#16207e";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp3";
                    layout.LarguraLogo = 298;
                    break;
                //case 3:
                //    logomarca = "norpave.jpg";
                //    ImgTitulo = "8_scp7titulo.jpg";
                //    CorFndTitulos = "#c8db35";
                //    CorFontTitulos = "#ffffff";
                //    CorFontCampo = "#c8db35";
                //    CorFontValor = "#333333";
                //    CorFndTabela = "#ecf5fc";
                //    break;
                case 4:
                    layout.logomarca = "4_scp2.jpg";
                    layout.ImgTitulo = "4_scp2titulo.jpg";
                    layout.CorFndTitulos = "#60a467";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp2";
                    break;
                case 5:
                    layout.logomarca = "5_scp4.jpg";
                    layout.ImgTitulo = "5_scp4titulo.jpg";
                    layout.CorFndTitulos = "#ef7c01";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp4";
                    layout.LarguraLogo = 210;
                    break;
                case 6:
                    layout.logomarca = "6_scp5.jpg";
                    layout.ImgTitulo = "6_scp5titulo.jpg";
                    layout.CorFndTitulos = "#c01127";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp5";
                    layout.LarguraLogo = 210;
                    break;
                case 7:
                    layout.logomarca = "7_scp6.jpg";
                    layout.ImgTitulo = "7_scp6titulo.jpg";
                    layout.CorFndTitulos = "#60a467";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp6";

                    break;

                case 8:
                    layout.logomarca = "8_scp7.jpg";
                    layout.ImgTitulo = "8_scp7titulo.jpg";
                    layout.CorFndTitulos = "#0080c8";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp7";
                    layout.LarguraLogo = 210;
                    break;

                case 9:
                    layout.logomarca = "6_scp8.jpg";
                    layout.ImgTitulo = "6_scp8titulo.jpg";
                    layout.CorFndTitulos = "#60a467";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp8";
                    break;

                case 10:
                    layout.logomarca = "10_scp6.jpg";
                    layout.ImgTitulo = "10_scp6titulo.jpg";
                    layout.CorFndTitulos = "#60a467";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp6";
                    break;

                case 11:
                    layout.logomarca = "11_scp9.jpg";
                    layout.ImgTitulo = "11_scp9titulo.jpg";
                    layout.CorFndTitulos = "#c50d22";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Consórcio scp9";
                    layout.LarguraLogo = 210;
                    break;

                case 12:
                    layout.logomarca = "12_scp10.jpg";
                    layout.ImgTitulo = "12_scp10titulo.jpg";
                    layout.CorFndTitulos = "#9a1a1d";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "Rede scp10 Consorcios";
                    layout.LarguraLogo = 242;
                    break;

                case 13:
                    layout.logomarca = "13_scp11.jpg";
                    layout.ImgTitulo = "13_scp11titulo.jpg";
                    layout.CorFndTitulos = "#CC0000";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "scp11 Consórcios";
                    layout.LarguraLogo = 242;
                    break;

                default:
                    layout.logomarca = "0_brconsorcios.jpg";
                    layout.ImgTitulo = "1_scp1titulo.jpg";
                    layout.CorFndTitulos = "#c1212b";
                    layout.CorFontTitulos = "#ffffff";
                    layout.CorFontCampo = "#666d73";
                    layout.CorFontValor = "#666d73";
                    layout.CorFndTabela = "#eeeeee";
                    layout.NomeEmpresa = "BR Consórcios";
                    layout.LarguraLogo = 242;
                    break;
            }

            return layout;
        }
    }
}