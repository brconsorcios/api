using System;
using System.IO;
using exp.core.Utilitarios;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace exp.web.Code
{
    public class GerarContratoPdf
    {
        public string path_do_contrato { get; set; }
        public string path_do_proposta { get; set; }
        public string path_do_boleto { get; set; }
        public string path_imagens { get; set; }

        public string nome_do_boleto { get; set; }
        public string nome_da_proposta { get; set; }
        public string nome_do_contrato { get; set; }
        public string contrato_administradora { get; set; }

        public bool executar()
        {
            var doc = new Document(PageSize.A4, 20, 20, 20, 20);

            try
            {
                var wri = PdfWriter.GetInstance(doc,
                    new FileStream(path_do_contrato + nome_do_contrato, FileMode.OpenOrCreate));

                #region imagem de fundo

                //Imagem de fundo
                var imagepath = ServerMap.Path("~/Content/imagesboleto/");
                // add a image
                var ImgFnd = Image.GetInstance(imagepath + "/br-loader.jpg");
                //Resize image depend upon your need
                //For give the size to image
                ImgFnd.ScaleToFit(600, 369);
                //If you want to choose image as background then,
                ImgFnd.Alignment = Image.UNDERLYING;
                //If you want to give absolute/specified fix position to image.
                ImgFnd.SetAbsolutePosition(7, 10);
                //===========

                #endregion

                doc.Open();


                // BOLETO /////////////////////////////////////////////////////////////////////////////////////////////////////

                #region anexar o boleto ao documnto

                //if (System.IO.File.Exists(path_do_boleto + nome_do_boleto))
                //{
                //    PdfReader ReaderBoleto = new PdfReader(path_do_boleto + nome_do_boleto);
                //    for (var i = 1; i <= ReaderBoleto.NumberOfPages; i++)
                //    {
                //        doc.NewPage();
                //        var importedPage = wri.GetImportedPage(ReaderBoleto, i);
                //        var contentByte = wri.DirectContent;
                //        contentByte.AddTemplate(importedPage, 0, 0);
                //        doc.Add(ImgFnd);// imagem de fundo em todas as páginas
                //    }
                //}

                #endregion


                ///////////////////////////////////////////////////////////////////////////////////////////////////////


                // PROPOSTA /////////////////////////////////////////////////////////////////////////////////////////////////////

                #region anexar a proposta ao documnto

                var ReaderProposta = new PdfReader(path_do_proposta + nome_da_proposta);

                //int y;

                for (var i = 1; i <= ReaderProposta.NumberOfPages; i++)
                {
                    doc.NewPage();
                    var importedPage = wri.GetImportedPage(ReaderProposta, i);
                    var contentByte = wri.DirectContent;
                    contentByte.AddTemplate(importedPage, 0, 0);
                    doc.Add(ImgFnd); // imagem de fundo em todas as páginas
                }

                #endregion


                // CONTRATO /////////////////////////////////////////////////////////////////////////////////////////////////////

                #region anexar modelo do contrato ao documnto

                var ReaderContrato =
                    new PdfReader(path_do_contrato.Replace("propostas", "") + "/modelo/" + contrato_administradora);

                #region comentarios de exmplo

                //PdfContentByte cb = wri.DirectContent;

                //// select the font properties
                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252,BaseFont.NOT_EMBEDDED);
                //cb.SetColorFill(BaseColor.DARK_GRAY);
                //cb.SetFontAndSize(bf, 8);

                //// write the text in the pdf content
                //cb.BeginText();
                //string text = "Some random blablablabla...";
                //// put the alignment and coordinates here
                //cb.ShowTextAligned(1, text, 520, 640, 0);
                //cb.EndText();
                //cb.BeginText();
                //text = "Other random blabla...";
                //// put the alignment and coordinates here
                //cb.ShowTextAligned(2, text, 100, 200, 0);
                //cb.EndText();

                //// create the new page and add it to the pdf
                //PdfImportedPage page = wri.GetImportedPage(reader, 1);
                //cb.AddTemplate(page, 0, 0);
                //doc.NewPage();

                #endregion

                //int y;

                for (var i = 1; i <= ReaderContrato.NumberOfPages; i++)
                {
                    doc.NewPage();
                    // var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    var importedPage = wri.GetImportedPage(ReaderContrato, i);
                    var contentByte = wri.DirectContent;
                    //contentByte.BeginText();
                    //contentByte.SetFontAndSize(baseFont, 12);
                    //contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 200, 200, 0);
                    //contentByte.EndText();
                    contentByte.AddTemplate(importedPage, 0, 0);
                    doc.Add(ImgFnd); // imagem de fundo em todas as páginas
                }

                #endregion

                //doc.NewPage();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////

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
                //throw;
                throw new IndexOutOfRangeException();
            }
        }
    }
}