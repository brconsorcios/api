using System;
using System.Drawing;
using System.IO;
using System.Web.Hosting;
using exp.dados;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace exp.web.Code
{
    public class GerarPropostaPdf
    {
        public GerarPropostaPdf()
        {
            #region CORES

            ///CORES======================================================================
            //Cor do fundo base da tabela
            var _bgc = ColorTranslator.FromHtml("#ECEDEF");
            bgcolor = new BaseColor(_bgc.R, _bgc.G, _bgc.B);
            //cor vermelha do número da proposta
            CorNoProposta = new BaseColor(190, 34, 47);
            ///CORES======================================================================

            #endregion
        }

        public string path_do_pdf { get; set; }

        public string path_imagens { get; set; }

        //public string logomarca { get; set; }
        //public string ImgTitulo { get; set; }
        public string none_do_pdf { get; set; }
        public string NM_empresa { get; set; }

        public indicaco indicacao { get; set; }
        public site site { get; set; }
        public SiteLayout Layout { get; set; }

        private BaseColor CorNoProposta { get; }
        private BaseColor CorFnd { get; set; }
        private BaseColor bgcolor { get; }

        //public static Font GetLatoHai(string path_do_pdf)
        //{
        //    var fontName = "LatoHai";
        //    if (!FontFactory.IsRegistered(fontName))
        //    {
        //       // var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\fontawesome-webfont.ttf";
        //        var fontPath = path_do_pdf + "\\fonts\\LatoHai.ttf";


        //        FontFactory.Register(fontPath);
        //    }
        //    return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //}
        //GerarPropostaPdf.GetLatoHai(path_do_pdf);


        public bool executar()
        {
            var doc = new Document(PageSize.A4, 20, 20, 20, 20);
            try
            {
                var wri = PdfWriter.GetInstance(doc, new FileStream(path_do_pdf + none_do_pdf, FileMode.OpenOrCreate));

                var linebreak1 = new Chunk(new DottedLineSeparator());

                #region Imagens

                //imagens =============================================================================================
                Image logo = null;
                Image background = null;
                Image logoassociada = null;
                Image imgtopo = null;
                var siteUrl = Layout.UrlSite;

                if (!string.IsNullOrEmpty(Layout.logomarca))
                {
                    if (File.Exists(path_imagens + Layout.logomarca))
                    {
                        logo = Image.GetInstance(path_imagens + Layout.logomarca);
                    }
                    else
                    {
                        logo = null;
                        Layout.logomarca = string.Empty;
                    }
                }

                if (!string.IsNullOrEmpty(Layout.logomarca))
                {
                    if (File.Exists(path_imagens + Layout.logomarca))
                    {
                        logo = Image.GetInstance(path_imagens + Layout.logomarca);
                    }
                    else
                    {
                        logo = null;
                        Layout.logomarca = string.Empty;
                    }
                }

                #endregion

                #region Padrões

                //Todas SCPs agora possuem logo com texto dizendo que é associada
                //logoassociada = Image.GetInstance(path_imagens + "/brconsorcios.png");
                imgtopo = Image.GetInstance(path_imagens + Layout.ImgTitulo);

                //Cor cinza abaixo do nuemro da proposta
                var _cfn = ColorTranslator.FromHtml(Layout.CorFndTabela); //
                CorFnd = new BaseColor(_cfn.R, _cfn.G, _cfn.B);

                #endregion

                //imagens =============================================================================================

                #region Fonts

                //fontes =============================================================================================
                var fntTableFont12proposta = FontFactory.GetFont("Arial", 11, Font.NORMAL, CorNoProposta);
                var fntTableFont12 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                var fntTableFont16 = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK);
                var fntTableFont16blue = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLUE);

                var corFonteTitulo = ColorTranslator.FromHtml(Layout.CorFndTitulos); //

                var goodBlackFont = BaseFont.CreateFont(HostingEnvironment.MapPath("~/content/font/GoodOSF-Black.ttf"),
                    BaseFont.CP1252, BaseFont.EMBEDDED);
                var fntTitulo = new Font(goodBlackFont, 15f, Font.NORMAL,
                    new BaseColor(corFonteTitulo.R, corFonteTitulo.G, corFonteTitulo.B));

                var goodBookFont = BaseFont.CreateFont(HostingEnvironment.MapPath("~/content/font/GoodOSF-Book.ttf"),
                    BaseFont.CP1252, BaseFont.EMBEDDED);
                var fntTitulo2 = new Font(goodBookFont, 8.5f, Font.NORMAL, BaseColor.BLACK);
                //fontes =============================================================================================

                #endregion

                doc.Open();


                var myTable = new PdfPTable(2);
                myTable.WidthPercentage = 100;
                myTable.HorizontalAlignment = 0;
                myTable.SpacingAfter = 0;
                //myTable.SpacingAfter = 20;
                //myTable.SpacingBefore = 20;
                myTable.SetWidths(new[] { 30, 70 });

                var administradora = "BR CONSÓRCIOS ADMINISTRADORA DE CONSÓRCIOS LTDA";
                var cnpj = "14.723.388/0001-63";
                var txtgrupo = string.Empty;

                if (indicacao.id_site == 10)
                {
                    logoassociada = null;
                    administradora = "BMG BR ADMINISTRADORA DE CONSÓRCIOS LTDA";
                    cnpj = "75.770.164/0001-05";
                }

                if (indicacao.id_site == 7 || indicacao.id_site == 12) logoassociada = null;
                //Logomarca do banco
                if (logo == null)
                {
                    var tr1td1 = new PdfPCell(new Phrase(administradora, fntTableFont12));
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.BackgroundColor = CorFnd;
                    myTable.AddCell(tr1td1);
                }
                else
                {
                    var tr1td1 = new PdfPCell(logo, true);
                    tr1td1.Image.ScaleToFitHeight = false;
                    tr1td1.BackgroundColor = CorFnd;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.Padding = 0f;
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTable.AddCell(tr1td1);
                }

                var tr1td2_table = new PdfPTable(1);
                tr1td2_table.WidthPercentage = 100;
                tr1td2_table.HorizontalAlignment = 0;
                tr1td2_table.SpacingAfter = 0;
                tr1td2_table.SetWidths(new[] { 100 });

                var tr1td2ln1 = new PdfPCell(new Phrase("PROPOSTA DE PARTICIPAÇÃO EM GRUPO DE CONSÓRCIO", fntTitulo));
                tr1td2ln1.BackgroundColor = CorFnd;
                tr1td2ln1.PaddingLeft = 4f;
                tr1td2ln1.Top = 0f;
                tr1td2ln1.Padding = 0f;
                tr1td2ln1.BorderColorLeft = BaseColor.WHITE;
                tr1td2ln1.BorderColorRight = BaseColor.WHITE;
                tr1td2ln1.BorderColorTop = BaseColor.WHITE;
                tr1td2ln1.BorderColorBottom = BaseColor.WHITE;
                tr1td2ln1.BorderWidthLeft = 0f;
                tr1td2ln1.BorderWidthRight = 0f;
                tr1td2ln1.BorderWidthTop = 0f;
                tr1td2ln1.BorderWidthBottom = 0f;
                //tr1td2ln1.Border = Rectangle.NO_BORDER;
                tr1td2ln1.VerticalAlignment = Element.ALIGN_BOTTOM;
                tr1td2ln1.HorizontalAlignment = Element.ALIGN_CENTER;
                tr1td2ln1.FixedHeight = 50f;
                tr1td2_table.AddCell(tr1td2ln1);


                var tr1td2ln2 =
                    new PdfPCell(new Phrase(
                        "O Regulamento do Grupo de Consórcio encontra-se disponível no site " + siteUrl, fntTitulo2));
                // tr2td1.Image.ScaleToFitHeight = false;
                tr1td2ln2.BackgroundColor = CorFnd;
                tr1td2ln2.PaddingTop = 4f;
                tr1td2ln2.PaddingLeft = 0f;
                tr1td2ln2.BorderColorLeft = BaseColor.WHITE;
                tr1td2ln2.BorderColorRight = BaseColor.WHITE;
                tr1td2ln2.BorderColorTop = BaseColor.WHITE;
                tr1td2ln2.BorderColorBottom = BaseColor.WHITE;
                tr1td2ln2.BorderWidthLeft = 0f;
                tr1td2ln2.BorderWidthRight = 0f;
                tr1td2ln2.BorderWidthTop = 0f;
                tr1td2ln2.BorderWidthBottom = 0f;
                tr1td2ln2.Border = Rectangle.NO_BORDER;
                tr1td2ln2.VerticalAlignment = Element.ALIGN_TOP;
                tr1td2ln2.HorizontalAlignment = Element.ALIGN_CENTER;
                tr1td2ln2.FixedHeight = 50f;
                tr1td2_table.AddCell(tr1td2ln2);

                var tr1td2 = new PdfPCell(tr1td2_table);
                tr1td2.BackgroundColor = CorFnd;
                tr1td2.BorderColorLeft = BaseColor.WHITE;
                tr1td2.BorderColorRight = BaseColor.WHITE;
                tr1td2.BorderColorTop = BaseColor.WHITE;
                tr1td2.BorderColorBottom = BaseColor.WHITE;
                tr1td2.BorderWidthLeft = 4f;
                tr1td2.BorderWidthRight = 0f;
                tr1td2.BorderWidthTop = 0f;
                tr1td2.BorderWidthBottom = 0f;
                tr1td2.Padding = 0f;
                tr1td2.PaddingLeft = 4f;
                //tr1td2.Border = Rectangle.NO_BORDER;

                myTable.AddCell(tr1td2);


                //BaseColor color = new BaseColor(red, green, blue); // or red, green, blue, alpha
                //CYMKColor cmyk = new CMYKColor(cyan, yellow, magenta, black); // no alpha
                //GrayColor gray = new GrayColor(someFloatBetweenZeroAndOneInclusive); // no alpha

                var tr2td1 = new PdfPCell();
                // tr2td1.Image.ScaleToFitHeight = false;
                tr2td1.BackgroundColor = bgcolor;
                tr2td1.Top = 6f;
                tr2td1.FixedHeight = 30f;
                tr2td1.Padding = 2f;
                tr2td1.BorderColorLeft = BaseColor.WHITE;
                tr2td1.BorderColorRight = BaseColor.WHITE;
                tr2td1.BorderColorTop = BaseColor.WHITE;
                tr2td1.BorderColorBottom = BaseColor.WHITE;
                tr2td1.BorderWidthLeft = 0f;
                tr2td1.BorderWidthRight = 0f;
                tr2td1.BorderWidthTop = 4f;
                tr2td1.BorderWidthBottom = 4f;
                ///tr2td1.Border = Rectangle.NO_BORDER;
                tr2td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable.AddCell(tr2td1);


                //------------------------------------------------------------------------------
                var tr2td2_table1 = new PdfPTable(2);
                tr2td2_table1.WidthPercentage = 100;
                tr2td2_table1.HorizontalAlignment = 0;
                tr2td2_table1.SpacingAfter = 0;

                tr2td2_table1.SetWidths(new[] { 50f, 50f });

                if (!string.IsNullOrEmpty(indicacao.cd_grupo)) txtgrupo = "Grupo: ";

                var tr1table1td1 = new PdfPCell(new Phrase(txtgrupo + indicacao.cd_grupo + "", fntTableFont12proposta));
                tr1table1td1.Top = 6f;
                tr1table1td1.FixedHeight = 30f;
                tr1table1td1.PaddingLeft = 20f;
                tr1table1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr1table1td1.HorizontalAlignment = Element.ALIGN_LEFT;
                tr1table1td1.Border = Rectangle.NO_BORDER;
                tr2td2_table1.AddCell(tr1table1td1);

                var tr1table1td2 =
                    new PdfPCell(new Phrase("Nº Contrato:" + indicacao.id_documento + "", fntTableFont12proposta));
                tr1table1td2.Top = 6f;
                tr1table1td2.FixedHeight = 30f;
                tr1table1td2.PaddingRight = 20f;
                tr1table1td2.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr1table1td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr1table1td2.Border = Rectangle.NO_BORDER;
                tr2td2_table1.AddCell(tr1table1td2);
                //------------------------------------------------------------------------------


                var tr2td2 = new PdfPCell(tr2td2_table1);
                tr2td2.BackgroundColor = bgcolor;
                tr2td2.BorderColorLeft = BaseColor.WHITE;
                tr2td2.BorderColorRight = BaseColor.WHITE;
                tr2td2.BorderColorTop = BaseColor.WHITE;
                tr2td2.BorderColorBottom = BaseColor.WHITE;
                tr2td2.BorderWidthLeft = 4f;
                tr2td2.BorderWidthRight = 0f;
                tr2td2.BorderWidthTop = 4f;
                tr2td2.BorderWidthBottom = 4f;

                myTable.AddCell(tr2td2);
                //------------------------------------------------------------------------------


                //PdfPCell tr2td2 = new PdfPCell(new Phrase("Nº Contrato:" + indicacao.id_documento + "", fntTableFont12proposta));
                //tr2td2.BackgroundColor = bgcolor;
                //tr2td2.Top = 6f;
                //tr2td2.FixedHeight = 30f;
                //tr2td2.PaddingRight = 20f;
                //tr2td2.BorderColorLeft = BaseColor.WHITE;
                //tr2td2.BorderColorRight = BaseColor.WHITE;
                //tr2td2.BorderColorTop = BaseColor.WHITE;
                //tr2td2.BorderColorBottom = BaseColor.WHITE;
                //tr2td2.BorderWidthLeft = 4f;
                //tr2td2.BorderWidthRight = 0f;
                //tr2td2.BorderWidthTop = 4f;
                //tr2td2.BorderWidthBottom = 4f;
                //tr2td2.VerticalAlignment = Element.ALIGN_MIDDLE;
                //tr2td2.HorizontalAlignment = Element.ALIGN_RIGHT;


                // myTable.AddCell(tr2td2);


                #region Converte HTML em PDF

                var cellcodbar = new PdfPCell();
                cellcodbar.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellcodbar.Border = Rectangle.NO_BORDER;

                #endregion


                ///AQUI==========================================================================
                var tr3td1 = new PdfPCell(cellcodbar);
                tr3td1.Colspan = 2;
                tr3td1.Padding = 0f;
                tr3td1.BorderColorLeft = BaseColor.WHITE;
                tr3td1.BorderColorRight = BaseColor.WHITE;
                tr3td1.BorderColorTop = BaseColor.WHITE;
                tr3td1.BorderColorBottom = BaseColor.WHITE;
                tr3td1.BorderWidthLeft = 0f;
                tr3td1.BorderWidthRight = 0f;
                tr3td1.BorderWidthTop = 0f;
                tr3td1.BorderWidthBottom = 0f;
                tr3td1.Border = Rectangle.NO_BORDER;
                tr3td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable.AddCell(tr3td1);
                ///</tr2>==========================================================================


                var myTableThermo = new PdfPTable(2);
                myTableThermo.WidthPercentage = 100;
                myTableThermo.HorizontalAlignment = 0;
                myTableThermo.SpacingAfter = 0;
                //myTableThermo.SpacingAfter = 20;
                //myTableThermo.SpacingBefore = 20;
                myTableThermo.SetWidths(new[] { 30, 70 });


                if (logo == null)
                {
                    var tr1td1 = new PdfPCell(new Phrase("Associada a Br Consórcios", fntTableFont12));
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.BackgroundColor = CorFnd;
                    myTableThermo.AddCell(tr1td1);
                }
                else
                {
                    var tr1td1 = new PdfPCell(logo, true);
                    tr1td1.Image.ScaleToFitHeight = false;
                    tr1td1.BackgroundColor = CorFnd;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.Padding = 0f;
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTableThermo.AddCell(tr1td1);
                }


                myTableThermo.AddCell(tr1td2);
                myTableThermo.AddCell(tr2td1);
                myTableThermo.AddCell(tr2td2);


                #region Converte THERMO em PDF -----------

                var cellcodbarthermo = new PdfPCell();
                cellcodbarthermo.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellcodbarthermo.Border = Rectangle.NO_BORDER;
                ///AQUI==========================================================================
                var tr3td1thermo = new PdfPCell(cellcodbarthermo);
                tr3td1thermo.Colspan = 2;
                tr3td1thermo.Padding = 0f;
                tr3td1thermo.BorderColorLeft = BaseColor.WHITE;
                tr3td1thermo.BorderColorRight = BaseColor.WHITE;
                tr3td1thermo.BorderColorTop = BaseColor.WHITE;
                tr3td1thermo.BorderColorBottom = BaseColor.WHITE;
                tr3td1thermo.BorderWidthLeft = 0f;
                tr3td1thermo.BorderWidthRight = 0f;
                tr3td1thermo.BorderWidthTop = 0f;
                tr3td1thermo.BorderWidthBottom = 0f;
                tr3td1thermo.Border = Rectangle.NO_BORDER;
                tr3td1thermo.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                myTableThermo.AddCell(tr3td1thermo);
                ///</tr2>==========================================================================        

                #endregion

                doc.Add(myTable);
                doc.NewPage();
                doc.Add(myTableThermo);
                // doc.Add(linebreak1);
                ///#################################################################################################

                doc.Close();
                doc.Dispose();
                wri.Dispose();
                return true;
            }
            catch (Exception)
            {
                doc.Close();
                doc.Dispose();
                return false;
                throw;
            }
        }
    }
}