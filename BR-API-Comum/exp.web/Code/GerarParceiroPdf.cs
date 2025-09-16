using exp.dados;
using exp.web.Template.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

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
            string pathPDF = HostingEnvironment.MapPath("~/content/propostasparceria/");
            string nomePDF = "propostaparceria_" + parceiro.id + ".pdf";

            try
            {


                if (File.Exists(pathPDF + nomePDF))
                    return nomePDF;

                int IdSCP = parceiro.id_site; // Validar melhor

                var layout = Layout.Gerar(IdSCP);

                //string siteUrl = Parametros.GetParameter("URL_SCP_SITE", IdSCP)?.ToUpper();


                doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20);
                wri = PdfWriter.GetInstance(doc, new FileStream(pathPDF + nomePDF, FileMode.OpenOrCreate));

                Chunk linebreak1 = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());

                #region Imagens
                //imagens =============================================================================================
                Image logo = null;

                //string logoPath = HostingEnvironment.MapPath("~/Content/logos/" + layout.logomarca);
                string logoPath = HostingEnvironment.MapPath("~/Content/logosparceria/" + IdSCP + ".png");

                //if (!string.IsNullOrEmpty(Layout.logomarca))
                //{
                if (File.Exists(logoPath))
                {
                    logo = Image.GetInstance(logoPath);
                }
                else
                {
                    logo = null;
                }

                #endregion

                #region Padrões
                //Cor cinza abaixo do nuemro da proposta
                System.Drawing.Color _cfn = System.Drawing.ColorTranslator.FromHtml(layout.CorFndTabela);//
                CorFnd = new BaseColor(_cfn.R, _cfn.G, _cfn.B);
                #endregion

                //imagens =============================================================================================

                #region Fonts
                //fontes =============================================================================================
                Font fntTableFont12proposta = FontFactory.GetFont("Arial", 11, Font.NORMAL, CorNoProposta);
                Font fntTableFont12 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                Font fntTableFont16 = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK);
                Font fntTableFont16blue = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLUE);
                //fontes =============================================================================================
                #endregion

                doc.Open();


                PdfPTable myTable = new PdfPTable(2);
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
                    PdfPCell tr1td1 = new PdfPCell(logo);
                    //tr1td1.Image.ScaleToFitHeight = false;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.Padding = 0f;
                    tr1td1.Colspan = 2;
                    tr1td1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    myTable.AddCell(tr1td1);
                }


                string templateFilePath = HostingEnvironment.MapPath("~/template/PropostaParceriaTemplate.cshtml");
                
                PropostaParceriaPdfModel model = new PropostaParceriaPdfModel()
                {
                    Parceiro = parceiro,
                    Layout = layout,
                    LogoPath = logoPath
                };


                string mensagemProposta = Razor.Parse(File.ReadAllText(templateFilePath), model, null, null);


                #region Converte HTML em PDF
                PdfPCell cellcodbar = new PdfPCell();
                cellcodbar.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellcodbar.Border = Rectangle.NO_BORDER;

                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(mensagemProposta), null);
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    //doc.Add((IElement)htmlarraylist[k]);
                    cellcodbar.AddElement((IElement)htmlarraylist[k]);
                }
                #endregion

                ///AQUI==========================================================================
                PdfPCell tr3td1 = new PdfPCell(cellcodbar);
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