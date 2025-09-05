using System;
using System.Drawing;
using System.IO;
using System.Web.Hosting;
using exp.dados;
using exp.web.Template.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using RazorEngine;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace exp.web.Code
{
    public class GerarParceiroPdf
    {
        private BaseColor CorNoProposta { get; set; }
        private BaseColor CorFnd { get; set; }
        private BaseColor bgcolor { get; set; }

        public string Criar(tbparceiro parceiro)
        {
            Document doc = null;
            PdfWriter wri = null;
            var pathPDF = HostingEnvironment.MapPath("~/content/propostasparceria/");
            var nomePDF = "propostaparceria_" + parceiro.id + ".pdf";

            try
            {
                if (File.Exists(pathPDF + nomePDF))
                    return nomePDF;

                var IdSCP = parceiro.id_site; // Validar melhor

                var layout = Layout.Gerar(IdSCP);

                //string siteUrl = Parametros.GetParameter("URL_SCP_SITE", IdSCP)?.ToUpper();


                doc = new Document(PageSize.A4, 20, 20, 20, 20);
                wri = PdfWriter.GetInstance(doc, new FileStream(pathPDF + nomePDF, FileMode.OpenOrCreate));

                var linebreak1 = new Chunk(new DottedLineSeparator());

                #region Imagens

                //imagens =============================================================================================
                Image logo = null;

                //string logoPath = HostingEnvironment.MapPath("~/Content/logos/" + layout.logomarca);
                var logoPath = HostingEnvironment.MapPath("~/Content/logosparceria/" + IdSCP + ".png");

                //if (!string.IsNullOrEmpty(Layout.logomarca))
                //{
                if (File.Exists(logoPath))
                    logo = Image.GetInstance(logoPath);
                else
                    logo = null;

                #endregion

                #region Padrões

                //Cor cinza abaixo do nuemro da proposta
                var _cfn = ColorTranslator.FromHtml(layout.CorFndTabela); //
                CorFnd = new BaseColor(_cfn.R, _cfn.G, _cfn.B);

                #endregion

                //imagens =============================================================================================

                #region Fonts

                //fontes =============================================================================================
                var fntTableFont12proposta = FontFactory.GetFont("Arial", 11, Font.NORMAL, CorNoProposta);
                var fntTableFont12 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                var fntTableFont16 = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK);
                var fntTableFont16blue = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLUE);
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
                myTable.SplitLate = false;


                if (logo != null)
                {
                    //logo.ScalePercent(24f);
                    logo.ScalePercent(50f);
                    var tr1td1 = new PdfPCell(logo);
                    //tr1td1.Image.ScaleToFitHeight = false;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.Padding = 0f;
                    tr1td1.Colspan = 2;
                    tr1td1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    myTable.AddCell(tr1td1);
                }


                var templateFilePath = HostingEnvironment.MapPath("~/template/PropostaParceriaTemplate.cshtml");

                var model = new PropostaParceriaPdfModel
                {
                    Parceiro = parceiro,
                    Layout = layout,
                    LogoPath = logoPath
                };


                var mensagemProposta = Razor.Parse(File.ReadAllText(templateFilePath), model, null, null);


                #region Converte HTML em PDF

                var cellcodbar = new PdfPCell();
                cellcodbar.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellcodbar.Border = Rectangle.NO_BORDER;

                var htmlarraylist = HTMLWorker.ParseToList(new StringReader(mensagemProposta), null);
                for (var k = 0; k < htmlarraylist.Count; k++)
                    //doc.Add((IElement)htmlarraylist[k]);
                    cellcodbar.AddElement(htmlarraylist[k]);

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


                doc.Add(myTable);

                doc.Close();
                doc.Dispose();
                wri.Dispose();
                return nomePDF;
            }
            catch (Exception ex)
            {
                if (wri != null)
                {
                    wri.Close();
                    wri.Dispose();
                }

                if (doc != null)
                {
                    doc.Close();
                    doc.Dispose();
                }

                if (File.Exists(pathPDF + nomePDF))
                    File.Delete(pathPDF + nomePDF);

                return "ERRO: " + ex.Message;
                throw;
            }
        }
    }
}