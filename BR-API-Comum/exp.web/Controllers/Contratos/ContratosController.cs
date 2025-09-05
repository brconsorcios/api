using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web.Mvc;
using exp.core;
using exp.core.Utilitarios;
using exp.dados;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace exp.web.Controllers.Contratos
{
    public class ContratosController : Controller
    {

        public static string GetAddresses() //IEnumerable<string> GetAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return (from ip in host.AddressList
                where ip.AddressFamily == AddressFamily.InterNetwork
                select ip.ToString()).FirstOrDefault(); //.ToList();
        }

        //[WebApiOutputCache(120, 60, false)]
        public ActionResult download(string id, string id_adm, string st_grupo)
        {

            var hoje = DateTime.Now;
            var arquivo = "contrato-br";
            var empresa = "BR Consorcios";
            var ip = GetAddresses();

            id = id.toDencod64().Replace("downloadcontrato", "");


            if (Funcao.IsNumeric(id)) id = id.PadLeft(6, '0');

            var _bgc = ColorTranslator.FromHtml("#ECEDEF");
            var fnd = new BaseColor(_bgc.R, _bgc.G, _bgc.B);

            var fontbase = FontFactory.GetFont(FontFactory.COURIER, 7, Font.NORMAL, BaseColor.BLUE);

            var document = new Document(PageSize.A4); //, 10, 10, 10, 10);

            var stream = new MemoryStream();

            try
            {
                var pdfWriter = PdfWriter.GetInstance(document, stream);
                pdfWriter.CloseStream = false;

                document.AddTitle("Contrato Regulamento - " + hoje.ToString("dd/MM/yyyy hh:mm:ss"));
                document.AddSubject("CONTRATO DE ADESÃO (" + empresa + ")");
                document.AddKeywords("Regulamento, Contrato");
                document.AddAuthor("Br Consorcios e Associadas - www.brconsorcios.com.br");
                document.AddCreator("Regulamento");

                document.Open();

                // PROPOSTA /////////////////////////////////////////////////////////////////////////////////////////////////////

                #region anexar a proposta ao documnto

                var ReaderFile = new PdfReader(ServerMap.Path("~/content/contratos/modelo/" + arquivo + ".pdf"));

                var textorodape = "Grupo: " + id + " - Site: www.brconsorcios.com.br - Data: " +
                                  hoje.ToString("dd/MM/yyyy hh:mm:ss") + " - IP: " + ip;


                var bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                for (var i = 1; i <= ReaderFile.NumberOfPages; i++)
                {
                    var page = pdfWriter.GetImportedPage(ReaderFile, i);

                    var text = "Page " + pdfWriter.PageNumber + " of ";
                    var contentByte = pdfWriter.DirectContent;
                    var headerTemplate = contentByte.CreateTemplate(10, 10);
                    var footerTemplate = contentByte.CreateTemplate(30, 30);


                    var grupo = "Grupo: " + id + "";
                    //Add paging to header
                    {
                        var len = bf.GetWidthPoint(grupo, 12);

                        contentByte.BeginText();
                        contentByte.SetFontAndSize(bf, 12);
                        //contentByte.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetTop(25));
                        contentByte.SetTextMatrix(document.PageSize.Width - len - 40, document.PageSize.GetTop(25));
                        contentByte.ShowText(grupo);
                        contentByte.EndText();

                        //Adds "12" in Page 1 of 12
                        //contentByte.AddTemplate(headerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetTop(25));
                        contentByte.AddTemplate(headerTemplate, document.PageSize.Width - len - 40,
                            document.PageSize.GetTop(25));
                    }

                    // get page center
                    float posX;
                    float posY;
                    var rotation = ReaderFile.GetPageRotation(i);
                    if (rotation == 0 || rotation == 180)
                    {
                        posX = page.Width / 2;
                        posY = 0;
                    }
                    else
                    {
                        posX = page.Height / 2;
                        posY = 20f;
                    }


                    contentByte.AddTemplate(page, -20, 0);

                    //Add paging to footer
                    {
                        contentByte.BeginText();
                        contentByte.SetFontAndSize(bf, 8);
                        contentByte.SetTextMatrix(document.PageSize.GetLeft(40), document.PageSize.GetBottom(20));
                        contentByte.ShowText(textorodape);
                        //contentByte.PdfWriter.Add(p);
                        contentByte.EndText();
                        var len = bf.GetWidthPoint(text, 8);
                        contentByte.AddTemplate(footerTemplate, document.PageSize.GetLeft(40) + len,
                            document.PageSize.GetBottom(20));
                    }


                    //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                    //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                    //Third and fourth param is x and y position to start writing
                    // Tabela.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, pdfWriter.DirectContent);

                    //Tabela.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, pdfWriter.DirectContent);

                    //Move the pointer and draw line to separate header section from rest of page
                    contentByte.MoveTo(40, document.PageSize.Height - 30);
                    contentByte.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 30);
                    contentByte.Stroke();

                    //Move the pointer and draw line to separate footer section from rest of page
                    contentByte.MoveTo(40, document.PageSize.GetBottom(40));
                    contentByte.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(40));
                    contentByte.Stroke();

                    document.NewPage();
                }

                #endregion

                var down = new contratos_down();
                down.dt = hoje;
                down.empresa = empresa;
                down.ip = ip;
                down.grupo = id;

            }
            catch (DocumentException de)
            {
                //Console.Error.WriteLine(de.Message);
                return Content(de.Message);
            }
            catch (IOException ioe)
            {
                return Content(ioe.Message);
                //Console.Error.WriteLine(ioe.Message);
            }

            document.Close();

            stream.Flush(); //Always catches me out
            stream.Position = 0; //Not sure if this is required

            return File(stream, "application/pdf",
                "Contrato-Grupo-" + id + "-" + hoje.ToString("ddMMyyyyhhmmss") + ".pdf");
        }
    }
}