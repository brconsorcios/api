using System;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace exp.web.Code
{
    public class GerarBoletoPdf
    {
        public string nome_do_banco { get; set; }
        public string path_imagens { get; set; }
        public string logomarca { get; set; }
        public string none_do_pdf { get; set; }
        public string path_do_pdf { get; set; }
        public string background_imgem { get; set; }
        public string no_do_banco { get; set; }
        public string cedente { get; set; }
        public string CD_Inscricao_Nacional { get; set; }
        public string agencia_cod_cedente { get; set; }
        public string vencimento { get; set; }
        public string sacado { get; set; }

        public string valor_do_documento { get; set; }
        public string nosso_numero { get; set; }
        public string demonstrativo { get; set; }
        public string no_do_documento { get; set; }
        public string no_divitavel { get; set; }
        public string local_de_pagamento { get; set; }
        public string data_do_documento { get; set; }
        public string aceite { get; set; }
        public string sacador_avalista { get; set; }


        public string valor_cobrado { get; set; }
        public string outros_acrescimos { get; set; }
        public string mora_multa { get; set; }
        public string outras_deducoes { get; set; }
        public string desconto_abatimentos { get; set; }
        public string instrucoes { get; set; }
        public string quantidade { get; set; }
        public string especie { get; set; }
        public string carteira { get; set; }
        public string data_processamento { get; set; }

        public string especie_doc { get; set; }
        public string codigo_de_barras { get; set; }

        //public GerarBoletoPdf()
        //{

        //}


        public bool executar()
        {
            try
            {
                //imagens =============================================================================================
                Image logo = null;
                Image background = null;

                if (!string.IsNullOrEmpty(logomarca))
                {
                    if (File.Exists(path_imagens + logomarca))
                    {
                        logo = Image.GetInstance(path_imagens + logomarca);
                    }
                    else
                    {
                        logo = null;
                        logomarca = string.Empty;
                    }
                }

                if (!string.IsNullOrEmpty(background_imgem))
                {
                    if (File.Exists(path_imagens + background_imgem))
                    {
                        background = Image.GetInstance(path_imagens + background_imgem);
                    }
                    else
                    {
                        background = null;
                        background_imgem = string.Empty;
                    }
                }
                //imagens =============================================================================================

                //fontes =============================================================================================
                var fntTableFont6 = FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK);

                var fntTableFont6Bold = FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.DARK_GRAY);

                var fntParagrafoCourierFont6 =
                    FontFactory.GetFont(FontFactory.COURIER, 8, Font.NORMAL, BaseColor.BLACK);

                var fntTableFont8Bold = FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.DARK_GRAY);

                var fntTableFont8 = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK);
                var fntTableFont10 = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
                var fntTableFont12 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                var fntTableFont18 = FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK);
                //fontes =============================================================================================

                var doc = new Document(PageSize.A4, 20, 20, 20, 20);

                var wri = PdfWriter.GetInstance(doc, new FileStream(path_do_pdf + none_do_pdf, FileMode.Create));

                doc.Open();


                var myTable = new PdfPTable(3);

                // Table size is set to 100% of the page
                myTable.WidthPercentage = 100;
                //Left aLign
                myTable.HorizontalAlignment = 0;
                myTable.SpacingAfter = 10;


                var sglTblHdWidths = new float[3];
                sglTblHdWidths[0] = 170f;
                sglTblHdWidths[1] = 104f;
                sglTblHdWidths[2] = 366f;


                ///<tr1>==========================================================================
                // Set the column widths on table creation. Unlike HTML cells cannot be sized.
                myTable.SetWidths(sglTblHdWidths);

                //Logomarca do banco
                if (logo == null)
                {
                    var tr1td1 = new PdfPCell(new Phrase(nome_do_banco, fntTableFont18));
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTable.AddCell(tr1td1);
                }
                else
                {
                    //PdfPCell tr1td1 = new PdfPCell(logo, true);
                    //tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    //myTable.AddCell(tr1td1);

                    var tr1td1 = new PdfPCell(logo, true); //(new Phrase("Banco Itaú S.A. ", fntTableFont10));
                    tr1td1.Image.ScaleToFitHeight = false;
                    tr1td1.Padding = 2f;
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTable.AddCell(tr1td1);
                }


                var tr1td2 = new PdfPCell(new Phrase(no_do_banco, fntTableFont18));
                tr1td2.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr1td2.HorizontalAlignment = Element.ALIGN_CENTER;
                myTable.AddCell(tr1td2);

                var tr1td3 = new PdfPCell(new Phrase(no_divitavel, fntTableFont10)); //"Recibo do Sacado 	"
                tr1td3.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr1td3.HorizontalAlignment = Element.ALIGN_RIGHT;
                myTable.AddCell(tr1td3);

                ///</tr1>==========================================================================


                ///<tr2>==========================================================================
                var tr2td1_table1 = new PdfPTable(3);
                tr2td1_table1.WidthPercentage = 100;
                tr2td1_table1.HorizontalAlignment = 0;
                tr2td1_table1.SpacingAfter = 0;
                tr2td1_table1.SetWidths(new[] { 274f, 183f, 183f });
                //------------------------------------------------------------------------------
                var tr2td1_table1_tb1td1 = new PdfPTable(1);
                tr2td1_table1_tb1td1.TotalWidth = 100;
                var tr1table1td1 = new PdfPCell(new Phrase("Cedente / CNPJ Cedente", fntTableFont6));
                tr1table1td1.Border = Rectangle.NO_BORDER;
                tr1table1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr2td1_table1_tb1td1.AddCell(tr1table1td1);
                var tr1table1td2 = new PdfPCell(new Phrase(cedente + " / " + CD_Inscricao_Nacional, fntTableFont6Bold));
                tr1table1td2.Border = Rectangle.NO_BORDER;
                tr1table1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr2td1_table1_tb1td1.AddCell(tr1table1td2);
                //------------------------------------------------------------------------------    
                var tb2tr1td1 = new PdfPCell();
                tr2td1_table1.AddCell(tr2td1_table1_tb1td1);
                //------------------------------------------------------------------------------

                var tr2td1_table1_tb2td1 = new PdfPTable(1);
                tr2td1_table1_tb2td1.TotalWidth = 100;
                var tr1table2td1 = new PdfPCell(new Phrase("Agência / Cód. Cedente", fntTableFont6));
                tr1table2td1.Border = Rectangle.NO_BORDER;
                tr2td1_table1_tb2td1.AddCell(tr1table2td1);
                var tr1table2td2 = new PdfPCell(new Phrase(agencia_cod_cedente, fntTableFont6Bold));
                tr1table2td2.Border = Rectangle.NO_BORDER;
                tr2td1_table1_tb2td1.AddCell(tr1table2td2);
                //------------------------------------------------------------------------------
                var tb2tr1td2 = new PdfPCell(tr2td1_table1_tb2td1);
                tr2td1_table1.AddCell(tb2tr1td2);
                //------------------------------------------------------------------------------
                var tr2td1_table1_tb3td1 = new PdfPTable(1);
                tr2td1_table1_tb3td1.TotalWidth = 100;
                var tr1table3td1 = new PdfPCell(new Phrase("Vencimento", fntTableFont6));
                tr1table3td1.Border = Rectangle.NO_BORDER;
                tr2td1_table1_tb3td1.AddCell(tr1table3td1);
                var tr1table3td2 = new PdfPCell(new Phrase(vencimento, fntTableFont8Bold));
                tr1table3td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr1table3td2.Border = Rectangle.NO_BORDER;
                tr2td1_table1_tb3td1.AddCell(tr1table3td2);
                //------------------------------------------------------------------------------
                var tb2tr1td3 = new PdfPCell(tr2td1_table1_tb3td1);
                tr2td1_table1.AddCell(tb2tr1td3);


                ///AQUI==========================================================================
                var tr2td1 = new PdfPCell(tr2td1_table1);
                tr2td1.Colspan = 3;
                tr2td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable.AddCell(tr2td1);
                ///</tr2>==========================================================================


                ///<tr3>==========================================================================

                var tr3td1_table1 = new PdfPTable(2);
                tr3td1_table1.WidthPercentage = 100;
                tr3td1_table1.HorizontalAlignment = 0;
                tr3td1_table1.SpacingAfter = 0;
                tr3td1_table1.SetWidths(new[] { 457f, 183f });
                //------------------------------------------------------------------------------
                var tr3td1_table1_tb1td1 = new PdfPTable(1);
                tr3td1_table1_tb1td1.TotalWidth = 100;
                var tr2table2td1 = new PdfPCell(new Phrase("Sacado - CNPJ/CPF", fntTableFont6));
                tr2table2td1.Border = Rectangle.NO_BORDER;
                tr3td1_table1_tb1td1.AddCell(tr2table2td1);
                var tr2table2td2 = new PdfPCell(new Phrase(sacado, fntTableFont8Bold));
                tr2table2td2.Border = Rectangle.NO_BORDER;
                tr3td1_table1_tb1td1.AddCell(tr2table2td2);
                //------------------------------------------------------------------------------
                var tb2tr2td1 = new PdfPCell();
                tb2tr2td1.Colspan = 2;
                tr3td1_table1.AddCell(tr3td1_table1_tb1td1);

                //------------------------------------------------------------------------------
                var tr3td2_table1_tb2td1 = new PdfPTable(1);
                tr3td2_table1_tb2td1.TotalWidth = 100;
                var tr2table3td1 = new PdfPCell(new Phrase("Valor do Documento", fntTableFont6));
                tr2table3td1.Border = Rectangle.NO_BORDER;
                tr3td2_table1_tb2td1.AddCell(tr2table3td1);
                var tr2table3td2 = new PdfPCell(new Phrase(valor_do_documento, fntTableFont8Bold));
                tr2table3td2.Border = Rectangle.NO_BORDER;
                tr2table3td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr3td2_table1_tb2td1.AddCell(tr2table3td2);
                //------------------------------------------------------------------------------
                var tb2tr2td2 = new PdfPCell(tr3td2_table1_tb2td1);
                tr3td1_table1.AddCell(tb2tr2td2);


                ///</tr3>AQUI==========================================================================
                var tr3td1 = new PdfPCell(tr3td1_table1);
                tr3td1.Colspan = 3;
                tr3td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable.AddCell(tr3td1);
                ///</tr3>==========================================================================

                ///<tr4>==========================================================================
                var tr4td1_table1 = new PdfPTable(2);
                tr4td1_table1.WidthPercentage = 100;
                tr4td1_table1.HorizontalAlignment = 0;
                tr4td1_table1.SpacingAfter = 0;
                tr4td1_table1.SetWidths(new[] { 457f, 183f });
                //------------------------------------------------------------------------------
                var tr4td1_table1_tb1td1 = new PdfPTable(1);
                tr4td1_table1_tb1td1.TotalWidth = 100;
                var tr4table2td1 = new PdfPCell(new Phrase("Instruções", fntTableFont6));
                // tr4table2td1.AddElement(new Paragraph(" ", fntTableFont6));
                tr4table2td1.Border = Rectangle.NO_BORDER;
                tr4td1_table1_tb1td1.AddCell(tr4table2td1);
                var tr4table2td2 = new PdfPCell(new Phrase(instrucoes, fntTableFont8Bold));
                tr4table2td2.Border = Rectangle.NO_BORDER;
                tr4td1_table1_tb1td1.AddCell(tr4table2td2);
                //------------------------------------------------------------------------------
                var tb2tr4td1 = new PdfPCell();
                tb2tr4td1.Colspan = 2;
                tr4td1_table1.AddCell(tr4td1_table1_tb1td1);

                //------------------------------------------------------------------------------


                var tr4td2_table2_tb2td1 = new PdfPTable(1);
                tr4td2_table2_tb2td1.TotalWidth = 100;

                //wwwwwwwwwwww----------------------------------------------------------------
                var tr4td2_table1_tb2td1 = new PdfPTable(1);
                tr4td2_table1_tb2td1.TotalWidth = 100;
                var tr4table3td1 = new PdfPCell(new Phrase("Nosso Número", fntTableFont6));
                tr4table3td1.Border = Rectangle.NO_BORDER;
                tr4td2_table1_tb2td1.AddCell(tr4table3td1);
                var tr4table3td2 = new PdfPCell(new Phrase(nosso_numero, fntTableFont8Bold));
                tr4table3td2.Border = Rectangle.NO_BORDER;
                tr4table3td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr4td2_table1_tb2td1.AddCell(tr4table3td2);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr4table3td1td1 = new PdfPCell(tr4td2_table1_tb2td1);
                tr4td2_table2_tb2td1.AddCell(tr4table3td1td1);

                //wwwwwwwwwwww----------------------------------------------------------------
                var tr4td2_table2_tb3td1 = new PdfPTable(1);
                tr4td2_table2_tb3td1.TotalWidth = 100;
                var tr4table3td3 = new PdfPCell(new Phrase("Nº do Documento", fntTableFont6));
                tr4table3td3.Border = Rectangle.NO_BORDER;
                tr4td2_table2_tb3td1.AddCell(tr4table3td3);
                var tr4table3td4 = new PdfPCell(new Phrase(no_do_documento, fntTableFont8Bold));
                tr4table3td4.Border = Rectangle.NO_BORDER;
                tr4table3td4.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr4td2_table2_tb3td1.AddCell(tr4table3td4);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr4table3td2td2 = new PdfPCell(tr4td2_table2_tb3td1);
                tr4table3td2td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr4td2_table2_tb2td1.AddCell(tr4table3td2td2);


                //------------------------------------------------------------------------------
                var tb2tr4td2 = new PdfPCell(tr4td2_table2_tb2td1);
                tr4td1_table1.AddCell(tb2tr4td2);


                ///</tr4>AQUI==========================================================================
                var tr4td1 = new PdfPCell(tr4td1_table1);
                tr4td1.Colspan = 3;
                tr4td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable.AddCell(tr4td1);
                ///</tr4>==========================================================================


                doc.Add(myTable);


                ///#################################################################################################

                var table = new PdfPTable(1);
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingAfter = 0;
                table.SetWidths(new[] { 100 });
                //table.LockedWidth = true;
                var bottom = new PdfPCell(new Phrase("Autenticação Mecânica", fntTableFont6));
                //bottom.AddElement(new Paragraph("Autenticação Mecânica", fntTableFont6));
                bottom.Border = Rectangle.NO_BORDER;
                bottom.PaddingTop = 0f;
                // bottom.PaddingBottom = 20f;
                bottom.VerticalAlignment = Element.ALIGN_TOP;
                bottom.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(bottom);

                doc.Add(table);

                ///#################################################################################################


                //doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(demonstrativo, fntParagrafoCourierFont6));
                //doc.Add(new Paragraph(" "));

                var linebreak = new Chunk(new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1));

                // Chunk linebreak = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());


                doc.Add(linebreak);

                doc.Add(new Paragraph("corte na linha", fntTableFont6));
                doc.Add(new Paragraph(" "));

                ///#################################################################################################

                var myTable2 = new PdfPTable(3);
                myTable2.WidthPercentage = 100;
                myTable2.HorizontalAlignment = 0;
                myTable2.SpacingAfter = 10;
                myTable2.SetWidths(new[] { 170f, 104f, 366f });

                ///<tr1>==========================================================================


                if (logo == null)
                {
                    var my2tr1td1 = new PdfPCell(new Phrase(nome_do_banco, fntTableFont18));
                    my2tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTable2.AddCell(my2tr1td1);
                }
                else
                {
                    var my2tr1td1 = new PdfPCell(logo, true); //(new Phrase("Banco Itaú S.A. ", fntTableFont10));
                    my2tr1td1.Image.ScaleToFitHeight = false;
                    my2tr1td1.Padding = 2f;
                    my2tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTable2.AddCell(my2tr1td1);
                }


                var my2tr1td2 = new PdfPCell(new Phrase(no_do_banco, fntTableFont18));
                my2tr1td2.VerticalAlignment = Element.ALIGN_MIDDLE;
                my2tr1td2.HorizontalAlignment = Element.ALIGN_CENTER;
                myTable2.AddCell(my2tr1td2);

                var my2tr1td3 = new PdfPCell(new Phrase(no_divitavel, fntTableFont10));
                my2tr1td3.VerticalAlignment = Element.ALIGN_MIDDLE;
                my2tr1td3.HorizontalAlignment = Element.ALIGN_RIGHT;
                myTable2.AddCell(my2tr1td3);

                ///</tr1>==========================================================================
                ///
                /// 
                ///<tr2>==========================================================================

                #region <TR2>

                var my2tr2td1_table1 = new PdfPTable(2);
                my2tr2td1_table1.WidthPercentage = 100;
                my2tr2td1_table1.HorizontalAlignment = 0;
                my2tr2td1_table1.SpacingAfter = 0;
                my2tr2td1_table1.SetWidths(new[] { 457f, 183f });
                //------------------------------------------------------------------------------
                var my2tr2td1_table1_tb1td1 = new PdfPTable(1);
                my2tr2td1_table1_tb1td1.TotalWidth = 100;
                var my2tr2table2td1 = new PdfPCell(new Phrase("Local de pagamento", fntTableFont6));
                my2tr2table2td1.Border = Rectangle.NO_BORDER;
                my2tr2td1_table1_tb1td1.AddCell(my2tr2table2td1);
                var my2tr2table2td2 = new PdfPCell(new Phrase(local_de_pagamento, fntTableFont8Bold));
                my2tr2table2td2.Border = Rectangle.NO_BORDER;
                my2tr2td1_table1_tb1td1.AddCell(my2tr2table2td2);
                //------------------------------------------------------------------------------
                var my2tb2tr2td1 = new PdfPCell();
                my2tb2tr2td1.Colspan = 2;
                my2tr2td1_table1.AddCell(my2tr2td1_table1_tb1td1);

                //-A mesma de cima-----------------------------------------------------------------------------
                var my2tb2tr2td2 = new PdfPCell(tr2td1_table1_tb3td1);
                my2tr2td1_table1.AddCell(my2tb2tr2td2);


                ///</tr2>AQUI==========================================================================
                var my2tr2td1 = new PdfPCell(my2tr2td1_table1);
                my2tr2td1.Colspan = 3;
                my2tr2td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable2.AddCell(my2tr2td1);
                ///</tr2>==========================================================================

                #endregion

                #region <TR3>

                var my2tr3td1_table1 = new PdfPTable(2);
                my2tr3td1_table1.WidthPercentage = 100;
                my2tr3td1_table1.HorizontalAlignment = 0;
                my2tr3td1_table1.SpacingAfter = 0;
                my2tr3td1_table1.SetWidths(new[] { 457f, 183f });
                //------------------------------------------------------------------------------
                var my2tr3td1_table1_tb1td1 = new PdfPTable(1);
                my2tr3td1_table1_tb1td1.TotalWidth = 100;
                var my2tr3table2td1 = new PdfPCell(new Phrase("Cedente / CNPJ Cedente", fntTableFont6));
                my2tr3table2td1.Border = Rectangle.NO_BORDER;
                my2tr3td1_table1_tb1td1.AddCell(my2tr3table2td1);
                var my2tr3table2td2 =
                    new PdfPCell(new Phrase(cedente + " / " + CD_Inscricao_Nacional, fntTableFont8Bold));
                my2tr3table2td2.Border = Rectangle.NO_BORDER;
                my2tr3td1_table1_tb1td1.AddCell(my2tr3table2td2);
                //------------------------------------------------------------------------------
                var my2tb2tr3td1 = new PdfPCell();
                my2tb2tr3td1.Colspan = 2;
                my2tr3td1_table1.AddCell(my2tr3td1_table1_tb1td1);
                //------------------------------------------------------------------------------
                var my2tr3td2_table1_tb2td1 = new PdfPTable(1);
                my2tr3td2_table1_tb2td1.TotalWidth = 100;
                var my2tr2table3td1 = new PdfPCell(new Phrase("Agência / Cód. Cedente", fntTableFont6));
                my2tr2table3td1.Border = Rectangle.NO_BORDER;
                my2tr3td2_table1_tb2td1.AddCell(my2tr2table3td1);
                var my2tr2table3td2 = new PdfPCell(new Phrase(agencia_cod_cedente, fntTableFont8Bold));
                my2tr2table3td2.Border = Rectangle.NO_BORDER;
                my2tr2table3td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                my2tr3td2_table1_tb2td1.AddCell(my2tr2table3td2);
                //------------------------------------------------------------------------------
                var my2tb2tr3td2 = new PdfPCell(my2tr3td2_table1_tb2td1);
                my2tr3td1_table1.AddCell(my2tb2tr3td2);


                ///</tr3>AQUI==========================================================================
                var my2tr3td1 = new PdfPCell(my2tr3td1_table1);
                my2tr3td1.Colspan = 3;
                my2tr3td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable2.AddCell(my2tr3td1);
                ///</tr3>==========================================================================

                #endregion

                #region <TR4>

                var my2tr4td1_table1 = new PdfPTable(6);
                my2tr4td1_table1.WidthPercentage = 100;
                my2tr4td1_table1.HorizontalAlignment = 0;
                my2tr4td1_table1.SpacingAfter = 0;
                my2tr4td1_table1.SetWidths(new[] { 101f, 101f, 104f, 60f, 91f, 183f });
                //111------------------------------------------------------------------------------
                var my2tr4td1_table1_tb1td1 = new PdfPTable(1);
                my2tr4td1_table1_tb1td1.TotalWidth = 100;
                //-----------------
                var my2tr4table1td1 = new PdfPCell(new Phrase("Data do documento", fntTableFont6));
                my2tr4table1td1.Border = Rectangle.NO_BORDER;
                my2tr4td1_table1_tb1td1.AddCell(my2tr4table1td1);
                //-----------------
                var my2tr4table1td2 = new PdfPCell(new Phrase(data_do_documento, fntTableFont8Bold));
                my2tr4table1td2.Border = Rectangle.NO_BORDER;
                my2tr4td1_table1_tb1td1.AddCell(my2tr4table1td2);
                //111------------------------------------------------------------------------------
                var my2tb2tr4td1 = new PdfPCell();
                my2tb2tr4td1.Colspan = 2;
                my2tr4td1_table1.AddCell(my2tr4td1_table1_tb1td1);
                //111----------------------------------------------------------------------------

                //333------------------------------------------------------------------------------
                var my2tr4td2_table1_tb3td3 = new PdfPTable(1);
                my2tr4td2_table1_tb3td3.TotalWidth = 100;
                //-----------------
                var my2tr4table3td1 = new PdfPCell(new Phrase("Nº documento", fntTableFont6));
                my2tr4table3td1.Border = Rectangle.NO_BORDER;
                my2tr4td2_table1_tb3td3.AddCell(my2tr4table3td1);
                //-----------------
                var my2tr4table3td2 = new PdfPCell(new Phrase(no_do_documento, fntTableFont8Bold));
                my2tr4table3td2.Border = Rectangle.NO_BORDER;
                my2tr4table3td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2tr4td2_table1_tb3td3.AddCell(my2tr4table3td2);
                //333------------------------------------------------------------------------------
                var my2tb3tr4td2 = new PdfPCell(my2tr4td2_table1_tb3td3);
                my2tr4td1_table1.AddCell(my2tb3tr4td2);
                //333----------------------------------------------------------------------------

                //444------------------------------------------------------------------------------
                var my2tr4td2_table1_tb4td4 = new PdfPTable(1);
                my2tr4td2_table1_tb4td4.TotalWidth = 100;
                //-----------------
                var my2tr4table4td1 = new PdfPCell(new Phrase("Espécie doc.", fntTableFont6));
                my2tr4table4td1.Border = Rectangle.NO_BORDER;
                my2tr4td2_table1_tb4td4.AddCell(my2tr4table4td1);
                //-----------------
                var my2tr4table4td2 = new PdfPCell(new Phrase(especie_doc, fntTableFont8Bold));
                my2tr4table4td2.Border = Rectangle.NO_BORDER;
                my2tr4table4td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2tr4td2_table1_tb4td4.AddCell(my2tr4table4td2);
                //444------------------------------------------------------------------------------
                var my2tb4tr4td2 = new PdfPCell(my2tr4td2_table1_tb4td4);
                my2tr4td1_table1.AddCell(my2tb4tr4td2);
                //444----------------------------------------------------------------------------


                //555------------------------------------------------------------------------------
                var my2tr4td2_table1_tb5td5 = new PdfPTable(1);
                my2tr4td2_table1_tb5td5.TotalWidth = 100;
                //-----------------
                var my2tr4table5td1 = new PdfPCell(new Phrase("Aceite", fntTableFont6));
                my2tr4table5td1.Border = Rectangle.NO_BORDER;
                my2tr4td2_table1_tb5td5.AddCell(my2tr4table5td1);
                //-----------------
                var my2tr4table5td2 = new PdfPCell(new Phrase(aceite, fntTableFont8Bold));
                my2tr4table5td2.Border = Rectangle.NO_BORDER;
                my2tr4table5td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2tr4td2_table1_tb5td5.AddCell(my2tr4table5td2);
                //555------------------------------------------------------------------------------
                var my2tb5tr4td2 = new PdfPCell(my2tr4td2_table1_tb5td5);
                my2tr4td1_table1.AddCell(my2tb5tr4td2);
                //555----------------------------------------------------------------------------

                //666------------------------------------------------------------------------------
                var my2tr4td2_table1_tb6td6 = new PdfPTable(1);
                my2tr4td2_table1_tb6td6.TotalWidth = 100;
                //-----------------
                var my2tr4table6td1 = new PdfPCell(new Phrase("Data processamento", fntTableFont6));
                my2tr4table6td1.Border = Rectangle.NO_BORDER;
                my2tr4td2_table1_tb6td6.AddCell(my2tr4table6td1);
                //-----------------
                var my2tr4table6td2 = new PdfPCell(new Phrase(data_processamento, fntTableFont8Bold));
                my2tr4table6td2.Border = Rectangle.NO_BORDER;
                my2tr4table6td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2tr4td2_table1_tb6td6.AddCell(my2tr4table6td2);
                //666------------------------------------------------------------------------------
                var my2tb6tr4td2 = new PdfPCell(my2tr4td2_table1_tb6td6);
                my2tr4td1_table1.AddCell(my2tb6tr4td2);
                //666----------------------------------------------------------------------------


                //777------------------------------------------------------------------------------
                var my2tr4td2_table1_tb7td7 = new PdfPTable(1);
                my2tr4td2_table1_tb7td7.TotalWidth = 100;
                //-----------------
                var my2tr4table7td1 = new PdfPCell(new Phrase("Nosso número", fntTableFont6));
                my2tr4table7td1.Border = Rectangle.NO_BORDER;
                my2tr4td2_table1_tb7td7.AddCell(my2tr4table7td1);
                //-----------------
                var my2tr4table7td2 = new PdfPCell(new Phrase(nosso_numero, fntTableFont8Bold));
                my2tr4table7td2.Border = Rectangle.NO_BORDER;
                my2tr4table7td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                my2tr4td2_table1_tb7td7.AddCell(my2tr4table7td2);
                //777------------------------------------------------------------------------------
                var my2tb7tr4td2 = new PdfPCell(my2tr4td2_table1_tb7td7);
                my2tr4td1_table1.AddCell(my2tb7tr4td2);
                //777----------------------------------------------------------------------------


                ///</tr4>AQUI==========================================================================
                var my2tr4td1 = new PdfPCell(my2tr4td1_table1);
                my2tr4td1.Colspan = 3;
                my2tr4td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable2.AddCell(my2tr4td1);
                ///</tr4>==========================================================================

                #endregion

                #region <TR5>

                var my2tr5_td1_table1 = new PdfPTable(6);
                my2tr5_td1_table1.WidthPercentage = 100;
                my2tr5_td1_table1.HorizontalAlignment = 0;
                my2tr5_td1_table1.SpacingAfter = 0;
                my2tr5_td1_table1.SetWidths(new[] { 92f, 91f, 91f, 81f, 102f, 183f });
                //111------------------------------------------------------------------------------
                var my2tr5_td1_table1_tb1td1 = new PdfPTable(1);
                my2tr5_td1_table1_tb1td1.TotalWidth = 100;
                //-----------------
                var my2_tr4_table1td1 = new PdfPCell(new Phrase("Uso do banco", fntTableFont6));
                my2_tr4_table1td1.Border = Rectangle.NO_BORDER;
                my2tr5_td1_table1_tb1td1.AddCell(my2_tr4_table1td1);
                //-----------------
                var my2_tr5_table1td2 = new PdfPCell(new Phrase(" ", fntTableFont8Bold));
                my2_tr5_table1td2.Border = Rectangle.NO_BORDER;
                my2tr5_td1_table1_tb1td1.AddCell(my2_tr5_table1td2);
                //111------------------------------------------------------------------------------
                var my2tb2_tr4_td1 = new PdfPCell();
                my2tb2_tr4_td1.Colspan = 2;
                my2tr5_td1_table1.AddCell(my2tr5_td1_table1_tb1td1);
                //111----------------------------------------------------------------------------

                //333------------------------------------------------------------------------------
                var my2_tr5_td2_table1_tb3td3 = new PdfPTable(1);
                my2_tr5_td2_table1_tb3td3.TotalWidth = 100;
                //-----------------
                var my2_tr5_table3_td1 = new PdfPCell(new Phrase("Carteira", fntTableFont6));
                my2_tr5_table3_td1.Border = Rectangle.NO_BORDER;
                my2_tr5_td2_table1_tb3td3.AddCell(my2_tr5_table3_td1);
                //-----------------
                var my2_tr5_table3_td2 = new PdfPCell(new Phrase(carteira, fntTableFont8Bold));
                my2_tr5_table3_td2.Border = Rectangle.NO_BORDER;
                my2_tr5_table3_td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2_tr5_td2_table1_tb3td3.AddCell(my2_tr5_table3_td2);
                //333------------------------------------------------------------------------------
                var my2_tb3_tr5_td2 = new PdfPCell(my2_tr5_td2_table1_tb3td3);
                my2tr5_td1_table1.AddCell(my2_tb3_tr5_td2);
                //333----------------------------------------------------------------------------

                //444------------------------------------------------------------------------------
                var my2_tr5_td2_table1_tb4td4 = new PdfPTable(1);
                my2_tr5_td2_table1_tb4td4.TotalWidth = 100;
                //-----------------
                var my2_tr5_table4_td1 = new PdfPCell(new Phrase("Espécie", fntTableFont6));
                my2_tr5_table4_td1.Border = Rectangle.NO_BORDER;
                my2_tr5_td2_table1_tb4td4.AddCell(my2_tr5_table4_td1);
                //-----------------
                var my2_tr5_table4_td2 = new PdfPCell(new Phrase(especie, fntTableFont8Bold));
                my2_tr5_table4_td2.Border = Rectangle.NO_BORDER;
                my2_tr5_table4_td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2_tr5_td2_table1_tb4td4.AddCell(my2_tr5_table4_td2);
                //444------------------------------------------------------------------------------
                var my2_tb4_tr5_td2 = new PdfPCell(my2_tr5_td2_table1_tb4td4);
                my2tr5_td1_table1.AddCell(my2_tb4_tr5_td2);
                //444----------------------------------------------------------------------------


                //555------------------------------------------------------------------------------
                var my2_tr5_td2_table1_tb5td5 = new PdfPTable(1);
                my2_tr5_td2_table1_tb5td5.TotalWidth = 100;
                //-----------------
                var my2_tr5_table5_td1 = new PdfPCell(new Phrase("Quantidade", fntTableFont6));
                my2_tr5_table5_td1.Border = Rectangle.NO_BORDER;
                my2_tr5_td2_table1_tb5td5.AddCell(my2_tr5_table5_td1);
                //-----------------
                var my2_tr5_table5_td2 = new PdfPCell(new Phrase(quantidade, fntTableFont8Bold));
                my2_tr5_table5_td2.Border = Rectangle.NO_BORDER;
                my2_tr5_table5_td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2_tr5_td2_table1_tb5td5.AddCell(my2_tr5_table5_td2);
                //555------------------------------------------------------------------------------
                var my2_tb5_tr5_td2 = new PdfPCell(my2_tr5_td2_table1_tb5td5);
                my2tr5_td1_table1.AddCell(my2_tb5_tr5_td2);
                //555----------------------------------------------------------------------------

                //666------------------------------------------------------------------------------
                var my2_tr5_td2_table1_tb6td6 = new PdfPTable(1);
                my2_tr5_td2_table1_tb6td6.TotalWidth = 100;
                //-----------------
                var my2_tr5_table6_td1 = new PdfPCell(new Phrase("Valor documento", fntTableFont6));
                my2_tr5_table6_td1.Border = Rectangle.NO_BORDER;
                my2_tr5_td2_table1_tb6td6.AddCell(my2_tr5_table6_td1);
                //-----------------
                var my2_tr5_table6_td2 = new PdfPCell(new Phrase(valor_do_documento, fntTableFont8Bold));
                my2_tr5_table6_td2.Border = Rectangle.NO_BORDER;
                my2_tr5_table6_td2.HorizontalAlignment = Element.ALIGN_LEFT;
                my2_tr5_td2_table1_tb6td6.AddCell(my2_tr5_table6_td2);
                //666------------------------------------------------------------------------------
                var my2_tb6_tr5_td2 = new PdfPCell(my2_tr5_td2_table1_tb6td6);
                my2tr5_td1_table1.AddCell(my2_tb6_tr5_td2);
                //666----------------------------------------------------------------------------


                //777------------------------------------------------------------------------------
                var my2_tr5_td2_table1_tb7td7 = new PdfPTable(1);
                my2_tr5_td2_table1_tb7td7.TotalWidth = 100;
                //-----------------
                var my2_tr5_table7_td1 = new PdfPCell(new Phrase("(=) Valor do documento", fntTableFont6));
                my2_tr5_table7_td1.Border = Rectangle.NO_BORDER;
                my2_tr5_td2_table1_tb7td7.AddCell(my2_tr5_table7_td1);
                //-----------------
                var my2_tr5_table7_td2 = new PdfPCell(new Phrase(valor_do_documento, fntTableFont8Bold));
                my2_tr5_table7_td2.Border = Rectangle.NO_BORDER;
                my2_tr5_table7_td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                my2_tr5_td2_table1_tb7td7.AddCell(my2_tr5_table7_td2);
                //777------------------------------------------------------------------------------
                var my2_tb7_tr5_td2 = new PdfPCell(my2_tr5_td2_table1_tb7td7);
                my2tr5_td1_table1.AddCell(my2_tb7_tr5_td2);
                //777----------------------------------------------------------------------------


                ///</tr5>AQUI==========================================================================
                var my2_tr5_td1 = new PdfPCell(my2tr5_td1_table1);
                my2_tr5_td1.Colspan = 3;
                my2_tr5_td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable2.AddCell(my2_tr5_td1);
                ///</tr5>==========================================================================

                #endregion


                ///<tr7>==========================================================================

                #region <TR7>

                ///<tr4>==========================================================================
                var tr7_td1_table1 = new PdfPTable(2);
                tr7_td1_table1.WidthPercentage = 100;
                tr7_td1_table1.HorizontalAlignment = 0;
                tr7_td1_table1.SpacingAfter = 0;
                tr7_td1_table1.SetWidths(new[] { 457f, 183f });
                //------------------------------------------------------------------------------
                var tr7_td1_table1_tb1td1 = new PdfPTable(1);
                tr7_td1_table1_tb1td1.TotalWidth = 100;
                var tr7_table2_td1 =
                    new PdfPCell(new Phrase("Instruções (Texto de responsabilidade do cedente)", fntTableFont6));
                // tr7_table2_td1.AddElement(new Paragraph(" ", fntTableFont6));
                tr7_table2_td1.Border = Rectangle.NO_BORDER;
                tr7_td1_table1_tb1td1.AddCell(tr7_table2_td1);
                var tr7_table2_td2 = new PdfPCell(new Phrase(instrucoes, fntTableFont8Bold));
                tr7_table2_td2.Border = Rectangle.NO_BORDER;
                tr7_td1_table1_tb1td1.AddCell(tr7_table2_td2);
                //------------------------------------------------------------------------------
                var tb2_tr7_td1 = new PdfPCell();
                tb2_tr7_td1.Colspan = 2;
                tr7_td1_table1.AddCell(tr7_td1_table1_tb1td1);

                //------------------------------------------------------------------------------


                var tr7_td2_table2_tb2_td1 = new PdfPTable(1);
                tr7_td2_table2_tb2_td1.TotalWidth = 100;
                //LINHA 1111 -----------------------------------------------------------------
                //wwwwwwwwwwww----------------------------------------------------------------
                var tr7_td2_table1_tb2_td1 = new PdfPTable(1);
                tr7_td2_table1_tb2_td1.TotalWidth = 100;
                var tr7_table3_td1 = new PdfPCell(new Phrase("(-) Desconto/Abatimentos", fntTableFont6));
                tr7_table3_td1.Border = Rectangle.NO_BORDER;
                tr7_td2_table1_tb2_td1.AddCell(tr7_table3_td1);
                var tr7_table3_td2 = new PdfPCell(new Phrase(desconto_abatimentos, fntTableFont8Bold));
                tr7_table3_td2.Border = Rectangle.NO_BORDER;
                tr7_table3_td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr7_td2_table1_tb2_td1.AddCell(tr7_table3_td2);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr7_table3_td1td1 = new PdfPCell(tr7_td2_table1_tb2_td1);
                tr7_td2_table2_tb2_td1.AddCell(tr7_table3_td1td1);
                //LINHA 1111 -----------------------------------------------------------------

                //LINHA 2222 -----------------------------------------------------------------
                //wwwwwwwwwwww----------------------------------------------------------------
                var tr7_td2_table2_tb3_td1 = new PdfPTable(1);
                tr7_td2_table2_tb3_td1.TotalWidth = 100;
                var tr7_table3_td3 = new PdfPCell(new Phrase("(-) Outras deduções", fntTableFont6));
                tr7_table3_td3.Border = Rectangle.NO_BORDER;
                tr7_td2_table2_tb3_td1.AddCell(tr7_table3_td3);
                var tr7_table3_td4 = new PdfPCell(new Phrase(outras_deducoes, fntTableFont8Bold));
                tr7_table3_td4.Border = Rectangle.NO_BORDER;
                tr7_table3_td4.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr7_td2_table2_tb3_td1.AddCell(tr7_table3_td4);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr7_table3_td2td2 = new PdfPCell(tr7_td2_table2_tb3_td1);
                //tr7_table3_td2td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr7_td2_table2_tb2_td1.AddCell(tr7_table3_td2td2);
                //LINHA 2222 ----------------------------------------------------------------

                //LINHA 3333 -----------------------------------------------------------------
                //wwwwwwwwwwww----------------------------------------------------------------
                var tr7_td2_table3_tb4_td1 = new PdfPTable(1);
                tr7_td2_table3_tb4_td1.TotalWidth = 100;
                var tr7_table3_td5 = new PdfPCell(new Phrase("(+) Mora/Multa", fntTableFont6));
                tr7_table3_td5.Border = Rectangle.NO_BORDER;
                tr7_td2_table3_tb4_td1.AddCell(tr7_table3_td5);
                var tr7_table3_td6 = new PdfPCell(new Phrase(mora_multa, fntTableFont8Bold));
                tr7_table3_td6.Border = Rectangle.NO_BORDER;
                tr7_table3_td6.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr7_td2_table3_tb4_td1.AddCell(tr7_table3_td6);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr7_table3_td3td3 = new PdfPCell(tr7_td2_table3_tb4_td1);
                tr7_td2_table2_tb2_td1.AddCell(tr7_table3_td3td3);
                //LINHA 3333 -------------------------------------------------------------------

                //LINHA 4444 -----------------------------------------------------------------
                //wwwwwwwwwwww----------------------------------------------------------------
                var tr7_td2_table2_tb5_td1 = new PdfPTable(1);
                tr7_td2_table2_tb5_td1.TotalWidth = 100;
                var tr7_table3_td7 = new PdfPCell(new Phrase("(+) Outros acréscimos", fntTableFont6));
                tr7_table3_td7.Border = Rectangle.NO_BORDER;
                tr7_td2_table2_tb5_td1.AddCell(tr7_table3_td7);
                var tr7_table3_td8 = new PdfPCell(new Phrase(outros_acrescimos, fntTableFont8Bold));
                tr7_table3_td8.Border = Rectangle.NO_BORDER;
                tr7_table3_td8.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr7_td2_table2_tb5_td1.AddCell(tr7_table3_td8);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr7_table3_td4td4 = new PdfPCell(tr7_td2_table2_tb5_td1);
                tr7_td2_table2_tb2_td1.AddCell(tr7_table3_td4td4);
                //LINHA 4444 -------------------------------------------------------------------

                //LINHA 5555 -----------------------------------------------------------------
                //wwwwwwwwwwww----------------------------------------------------------------
                var tr7_td2_table2_tb6_td1 = new PdfPTable(1);
                tr7_td2_table2_tb6_td1.TotalWidth = 100;
                var tr7_table3_td9 = new PdfPCell(new Phrase("(=) Valor cobrado", fntTableFont6));
                tr7_table3_td9.Border = Rectangle.NO_BORDER;
                tr7_td2_table2_tb6_td1.AddCell(tr7_table3_td9);
                var tr7_table3_td10 = new PdfPCell(new Phrase(valor_cobrado, fntTableFont8Bold));
                tr7_table3_td10.Border = Rectangle.NO_BORDER;
                tr7_table3_td10.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr7_td2_table2_tb6_td1.AddCell(tr7_table3_td10);
                //wwwwwwwwwwww----------------------------------------------------------------

                var tr7_table3_td5td5 = new PdfPCell(tr7_td2_table2_tb6_td1);
                tr7_td2_table2_tb2_td1.AddCell(tr7_table3_td5td5);
                //LINHA 5555 -------------------------------------------------------------------

                //------------------------------------------------------------------------------
                var tb2_tr7_td2 = new PdfPCell(tr7_td2_table2_tb2_td1);
                tr7_td1_table1.AddCell(tb2_tr7_td2);


                ///</tr4>AQUI==========================================================================
                var tr7_td1 = new PdfPCell(tr7_td1_table1);
                tr7_td1.Colspan = 3;
                tr7_td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                myTable2.AddCell(tr7_td1);
                ///</tr4>==========================================================================

                #endregion

                //777------------------------------------------------------------------------------
                ///<tr7>==========================================================================

                #region <TR8>

                ///<tr8>==========================================================================
                ///

                ///#################################################################################################

                var tablesacado = new PdfPTable(1);
                tablesacado.WidthPercentage = 100;
                tablesacado.HorizontalAlignment = 0;
                tablesacado.SpacingAfter = 0;
                tablesacado.SetWidths(new[] { 100 });
                //table.LockedWidth = true;
                var sacado1 = new PdfPCell(new Phrase("Sacado - CNPJ/CPF", fntTableFont6));
                sacado1.Border = Rectangle.NO_BORDER;
                sacado1.PaddingTop = 0f;
                sacado1.VerticalAlignment = Element.ALIGN_TOP;
                sacado1.HorizontalAlignment = Element.ALIGN_LEFT;
                tablesacado.AddCell(sacado1);

                var sacado2 = new PdfPCell(new Phrase(sacado, fntTableFont8Bold));
                sacado2.Border = Rectangle.NO_BORDER;
                sacado2.PaddingTop = 0f;
                sacado2.VerticalAlignment = Element.ALIGN_TOP;
                sacado2.HorizontalAlignment = Element.ALIGN_LEFT;
                tablesacado.AddCell(sacado2);


                var sacador = new PdfPCell(new Phrase("Sacador/Avalista:" + sacador_avalista, fntTableFont6));
                sacador.Border = Rectangle.NO_BORDER;
                sacador.PaddingTop = 10f;
                sacador.VerticalAlignment = Element.ALIGN_TOP;
                sacador.HorizontalAlignment = Element.ALIGN_LEFT;
                tablesacado.AddCell(sacador);

                ///#################################################################################################


                var tr8_td1_table1 = new PdfPCell(tablesacado); //
                tr8_td1_table1.Colspan = 3;
                tr8_td1_table1.VerticalAlignment = Element.ALIGN_MIDDLE;

                myTable2.AddCell(tr8_td1_table1);

                #endregion

                ///<tr9>==========================================================================


                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                #region CodigoBarras25I --------------------------------------------------------------------------

                //string Valor = "39991610600000390054294564000002646940417742";

                int f, f1, f2, i;
                string s;
                string texto;
                var fino = 1;
                var largo = 3;
                var altura = 40;
                var BarCodes = new string[100];
                var Codbarras = new StringBuilder();

                BarCodes[0] = "00110";
                BarCodes[1] = "10001";
                BarCodes[2] = "01001";
                BarCodes[3] = "11000";
                BarCodes[4] = "00101";
                BarCodes[5] = "10100";
                BarCodes[6] = "01100";
                BarCodes[7] = "00011";
                BarCodes[8] = "10010";
                BarCodes[9] = "01010";
                for (f1 = 9; f1 >= 0; f1--)
                for (f2 = 9; f2 >= 0; f2--)
                {
                    f = f1 * 10 + f2;
                    texto = "";
                    for (i = 0; i <= 4; i++)
                        texto += BarCodes[f1].Substring(i, 1) + BarCodes[f2].Substring(i, 1);
                    BarCodes[f] = texto;
                }

                texto = codigo_de_barras;
                if (texto.Length % 2 != 0)
                    texto = "0" + texto;

                //draw da guarda inicial
                Codbarras.Append("<img src=\"" + path_imagens + "/p.gif\" width=\"" + fino + "\" height=\"" + altura +
                                 "\" border=0>");
                Codbarras.Append("<img src=\"" + path_imagens + "/b.gif\" width=\"" + fino + "\" height=\"" + altura +
                                 "\" border=0>");
                Codbarras.Append("<img src=\"" + path_imagens + "/p.gif\" width=\"" + fino + "\" height=\"" + altura +
                                 "\" border=0>");
                Codbarras.Append("<img src=\"" + path_imagens + "/b.gif\" width=\"" + fino + "\" height=\"" + altura +
                                 "\" border=0>");

                // Draw dos dados
                while (texto.Length > 0)
                {
                    i = Convert.ToInt32(texto.Substring(0, 2));
                    texto = texto.Remove(0, 2);

                    s = BarCodes[i];

                    for (i = 0; i <= 9; i += 2)
                    {
                        if (s[i] == '0') f1 = fino;
                        else f1 = largo;

                        Codbarras.Append("<img src=\"" + path_imagens + "/p.gif\" width=\"" + f1 + "\" height=\"" +
                                         altura + "\" border=0>");

                        if (s[i + 1] == '0') f2 = fino;
                        else f2 = largo;

                        Codbarras.Append("<img src=\"" + path_imagens + "/b.gif\" width=\"" + f2 + "\" height=\"" +
                                         altura + "\" border=0>");
                    }
                }

                // draw da guarda final
                Codbarras.Append("<img src=\"" + path_imagens + "/p.gif\" width=\"" + largo + "\" height=\"" + altura +
                                 "\" border=0>");
                Codbarras.Append("<img src=\"" + path_imagens + "/b.gif\" width=\"" + fino + "\" height=\"" + altura +
                                 "\" border=0>");
                Codbarras.Append("<img src=\"" + path_imagens + "/p.gif\" width=\"" + fino + "\" height=\"" + altura +
                                 "\" border=0>");

                #endregion


                var cellcodbar = new PdfPCell(); //tr9_td1_table1
                cellcodbar.Colspan = 3;
                cellcodbar.VerticalAlignment = Element.ALIGN_MIDDLE;

                var htmlarraylist = HTMLWorker.ParseToList(new StringReader(Codbarras.ToString()), null);
                for (var k = 0; k < htmlarraylist.Count; k++)
                    //doc.Add((IElement)htmlarraylist[k]);
                    cellcodbar.AddElement(htmlarraylist[k]);


                #region <TR9>

                ///<tr9>==========================================================================

                doc.Add(myTable2);


                ///</tr9>==========================================================================

                #endregion


                ///#################################################################################################

                var tablebottom = new PdfPTable(2);
                tablebottom.WidthPercentage = 100;
                tablebottom.HorizontalAlignment = 0;
                tablebottom.SpacingAfter = 0;
                tablebottom.SetWidths(new[] { 457f, 183f });
                //table.LockedWidth = true;
                var bottom2 = new PdfPCell(new Phrase("Autenticação Mecânica", fntTableFont6));
                bottom2.Border = Rectangle.NO_BORDER;
                bottom2.PaddingTop = 0f;
                bottom2.VerticalAlignment = Element.ALIGN_TOP;
                bottom2.HorizontalAlignment = Element.ALIGN_LEFT;
                tablebottom.AddCell(bottom2);

                var bottom3 = new PdfPCell(new Phrase("Ficha de Compensação", fntTableFont6));
                bottom3.Border = Rectangle.NO_BORDER;
                bottom3.PaddingTop = 0f;
                bottom3.VerticalAlignment = Element.ALIGN_TOP;
                bottom3.HorizontalAlignment = Element.ALIGN_LEFT;
                tablebottom.AddCell(bottom3);


                var bottom4 = new PdfPCell(cellcodbar);
                bottom4.Border = Rectangle.NO_BORDER;
                bottom4.PaddingTop = 10f;
                bottom4.VerticalAlignment = Element.ALIGN_TOP;
                bottom4.HorizontalAlignment = Element.ALIGN_LEFT;
                tablebottom.AddCell(bottom4);

                doc.Add(tablebottom);

                //Chunk linebreak1 = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());
                var linebreak1 = new Chunk(new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1));

                doc.Add(linebreak1);

                ///#################################################################################################

                doc.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}