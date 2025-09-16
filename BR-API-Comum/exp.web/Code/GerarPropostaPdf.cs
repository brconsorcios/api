using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using exp.core;
using exp.dados;
using System.Web.Hosting;

namespace exp.web.Code
{
    public class GerarPropostaPdf
    {
        public string path_do_pdf { get; set; }
        public string path_imagens { get; set; }
        //public string logomarca { get; set; }
        //public string ImgTitulo { get; set; }
        public string none_do_pdf { get; set; }
        public string NM_empresa { get; set; }

        public indicaco indicacao { get; set; }
        public cliente cliente { get; set; }
        public site site { get; set; }
        public SiteLayout Layout { get; set; }

        private BaseColor CorNoProposta { get; set; }
        private BaseColor CorFnd { get; set; }
        private BaseColor bgcolor { get; set; }

        public GerarPropostaPdf()
        {


            #region CORES
            ///CORES======================================================================
            //Cor do fundo base da tabela
            System.Drawing.Color _bgc = System.Drawing.ColorTranslator.FromHtml("#ECEDEF");
            bgcolor = new BaseColor(_bgc.R, _bgc.G, _bgc.B);
            //cor vermelha do número da proposta
            CorNoProposta = new BaseColor(190, 34, 47);
            ///CORES======================================================================
            #endregion
        }

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
            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20);
            try
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(path_do_pdf + none_do_pdf, FileMode.OpenOrCreate));

                Chunk linebreak1 = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());

                #region Imagens
                //imagens =============================================================================================
                Image logo = null;
                Image background = null;
                Image logoassociada = null;
                Image imgtopo = null;
                string siteUrl = Layout.UrlSite;

                if (!string.IsNullOrEmpty(Layout.logomarca))
                {
                    if (System.IO.File.Exists(path_imagens + Layout.logomarca))
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
                    if (System.IO.File.Exists(path_imagens + Layout.logomarca))
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
                System.Drawing.Color _cfn = System.Drawing.ColorTranslator.FromHtml(Layout.CorFndTabela);//
                CorFnd = new BaseColor(_cfn.R, _cfn.G, _cfn.B);
                #endregion

                //imagens =============================================================================================

                #region Fonts
                //fontes =============================================================================================
                Font fntTableFont12proposta = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, CorNoProposta);
                Font fntTableFont12 = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                Font fntTableFont16 = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                Font fntTableFont16blue = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLUE);

                System.Drawing.Color corFonteTitulo = System.Drawing.ColorTranslator.FromHtml(Layout.CorFndTitulos);//

                BaseFont goodBlackFont = BaseFont.CreateFont(HostingEnvironment.MapPath("~/content/font/GoodOSF-Black.ttf"), BaseFont.CP1252, BaseFont.EMBEDDED);
                Font fntTitulo = new Font(goodBlackFont, 15f, Font.NORMAL, new BaseColor(corFonteTitulo.R, corFonteTitulo.G, corFonteTitulo.B));

                BaseFont goodBookFont = BaseFont.CreateFont(HostingEnvironment.MapPath("~/content/font/GoodOSF-Book.ttf"), BaseFont.CP1252, BaseFont.EMBEDDED);
                Font fntTitulo2 = new Font(goodBookFont, 8.5f, Font.NORMAL, BaseColor.BLACK);
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

                string administradora = "BR CONSÓRCIOS ADMINISTRADORA DE CONSÓRCIOS LTDA";
                string cnpj = "14.723.388/0001-63";
                string txtgrupo = string.Empty;

                if (indicacao.id_site == 10)
                {
                    logoassociada = null;
                    administradora = "BMG BR ADMINISTRADORA DE CONSÓRCIOS LTDA";
                    cnpj = "75.770.164/0001-05";
                }
                if (indicacao.id_site == 7 || indicacao.id_site == 12)
                {
                    logoassociada = null;
                }
                //Logomarca do banco
                if (logo == null)
                {
                    PdfPCell tr1td1 = new PdfPCell(new Phrase(administradora, fntTableFont12));
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.BackgroundColor = CorFnd;
                    myTable.AddCell(tr1td1);
                }
                else
                {

                    PdfPCell tr1td1 = new PdfPCell(logo, true);
                    tr1td1.Image.ScaleToFitHeight = false;
                    tr1td1.BackgroundColor = CorFnd;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.Padding = 0f;
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    myTable.AddCell(tr1td1);
                }

                PdfPTable tr1td2_table = new PdfPTable(1);
                tr1td2_table.WidthPercentage = 100;
                tr1td2_table.HorizontalAlignment = 0;
                tr1td2_table.SpacingAfter = 0;
                tr1td2_table.SetWidths(new[] { 100 });

                PdfPCell tr1td2ln1 = new PdfPCell(new Phrase("PROPOSTA DE PARTICIPAÇÃO EM GRUPO DE CONSÓRCIO", fntTitulo));
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



                PdfPCell tr1td2ln2 = new PdfPCell(new Phrase("O Regulamento do Grupo de Consórcio encontra-se disponível no site " + siteUrl, fntTitulo2));
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

                PdfPCell tr1td2 = new PdfPCell(tr1td2_table);
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

                PdfPCell tr2td1 = new PdfPCell();
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
                PdfPTable tr2td2_table1 = new PdfPTable(2);
                tr2td2_table1.WidthPercentage = 100;
                tr2td2_table1.HorizontalAlignment = 0;
                tr2td2_table1.SpacingAfter = 0;

                tr2td2_table1.SetWidths(new[] { 50f, 50f });

                if (!string.IsNullOrEmpty(indicacao.cd_grupo))
                {
                    txtgrupo = "Grupo: ";
                }

                PdfPCell tr1table1td1 = new PdfPCell(new Phrase(txtgrupo + indicacao.cd_grupo + "", fntTableFont12proposta));
                tr1table1td1.Top = 6f;
                tr1table1td1.FixedHeight = 30f;
                tr1table1td1.PaddingLeft = 20f;
                tr1table1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr1table1td1.HorizontalAlignment = Element.ALIGN_LEFT;
                tr1table1td1.Border = Rectangle.NO_BORDER;
                tr2td2_table1.AddCell(tr1table1td1);

                PdfPCell tr1table1td2 = new PdfPCell(new Phrase("Nº Contrato:" + indicacao.id_documento + "", fntTableFont12proposta));
                tr1table1td2.Top = 6f;
                tr1table1td2.FixedHeight = 30f;
                tr1table1td2.PaddingRight = 20f;
                tr1table1td2.VerticalAlignment = Element.ALIGN_MIDDLE;
                tr1table1td2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tr1table1td2.Border = Rectangle.NO_BORDER;
                tr2td2_table1.AddCell(tr1table1td2);
                //------------------------------------------------------------------------------


                PdfPCell tr2td2 = new PdfPCell(tr2td2_table1);
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


                GerarPropostaHTML GerarHTML = new GerarPropostaHTML();
                GerarHTML.indicacao = indicacao;
                GerarHTML.cliente = cliente;
                GerarHTML.site = site;
                GerarHTML.Layout = Layout;
                StringBuilder HTML = GerarHTML.html();


                #region Converte HTML em PDF
                PdfPCell cellcodbar = new PdfPCell();
                cellcodbar.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellcodbar.Border = Rectangle.NO_BORDER;

                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(HTML.ToString()), null);
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




                PdfPTable myTableThermo = new PdfPTable(2);
                myTableThermo.WidthPercentage = 100;
                myTableThermo.HorizontalAlignment = 0;
                myTableThermo.SpacingAfter = 0;
                //myTableThermo.SpacingAfter = 20;
                //myTableThermo.SpacingBefore = 20;
                myTableThermo.SetWidths(new[] { 30, 70 });


                if (logo == null)
                {
                    PdfPCell tr1td1 = new PdfPCell(new Phrase("Associada a Br Consórcios", fntTableFont12));
                    tr1td1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tr1td1.Border = Rectangle.NO_BORDER;
                    tr1td1.BackgroundColor = CorFnd;
                    myTableThermo.AddCell(tr1td1);
                }
                else
                {

                    PdfPCell tr1td1 = new PdfPCell(logo, true);
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

                #region THERMO
                ///</tr1>==========================================================================
                StringBuilder THERMO = new System.Text.StringBuilder();

                bool grupo_mapfre = false;
                using (var db = new Entities01())
                {
                    grupo_mapfre = db.contratos.Any(x => x.grupo == indicacao.cd_grupo.Trim() && x.empresa_id == 13);
                }

                    THERMO.Append("<br />");
                THERMO.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">   ");
                THERMO.Append("  <tr>");
                THERMO.Append("    <td align=\"center\"><font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\"> <strong>TERMOS E CONDIÇÕES DA PROPOSTA DE PARTICIPAÇÃO EM GRUPO DE CONSÓRCIO</strong></font></td>        ");
                THERMO.Append("  </tr>");
                THERMO.Append("  <tr>");
                THERMO.Append("    <td><br />");
                THERMO.Append("         <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">");
                THERMO.Append("         <p align=\"justify\">O <strong><strong>PROPONENTE</strong></strong>, já nomeado e qualificado no quadro “Dados de Identificação do Proponente”, propõe-se a aderir a grupo de consórcio constituído e administrado por <strong>" + administradora + "</strong>., com a especificação e condições identificadas nos quadros “Características do Plano“ e “Características do Objeto do Contrato”, anterior, ao qual o Proponente pretende aderir, com assembleias mensais de contemplação a serem realizadas na sede da <strong>ADMINISTRADORA</strong> ou em locais a serem definidos por ela, mediante os seguintes termos e condições: </p>");
                THERMO.Append("         <br /><ol type=\"1\">");
                THERMO.Append("           <li  align=\"justify\">Aprovada a presente Proposta de Participação, a <strong>ADMINISTRADORA</strong> fará a inscrição do <strong><strong>PROPONENTE</strong></strong> em grupo de consórcio com plano e objeto contratual definidos no quadro “Características do Objeto do Contrato”.</li>");
                THERMO.Append("           <li  align=\"justify\">O <strong>PROPONENTE</strong> compromete-se a ler o Contrato de Participação e, SE NÃO CONCORDAR COM OS SEUS TERMOS E CONDIÇÕES, compromete-se a desistir da adesão no prazo de 7 (sete) dias, desde que não ocorra nesse período a assembleia de contemplação do grupo no qual for inscrita a cota do <strong>PROPONENTE</strong>.</li>");
                THERMO.Append("           <li align=\"justify\">Ratificada a inscrição do <strong>PROPONENTE</strong> ao grupo de consórcio, o mesmo obrigar-se-á ao pagamento das parcelas mensais do grupo em seus respectivos vencimentos, cujas datas poderão ser revistas trimestralmente pela <strong>ADMINISTRADORA</strong>, nos termos do Contrato de Participação que rege os objetivos do grupo.</li>");
                THERMO.Append("           <li align=\"justify\">O <strong>PROPONENTE</strong>, por esta proposta e na melhor forma de direito, outorga à <strong>ADMINISTRADORA</strong> procuração com poderes específicos para representá-lo, já na qualidade de CONSORCIADO, na assembleia de constituição do grupo e nas assembleias gerais ordinárias, ou assembleias mensais de contemplação, para defender seus interesses e direitos perante o grupo ou terceiros, podendo, para tanto, se necessário, constituir advogado com poderes da cláusula “ad judicia” para o foro em geral, com o fim de representá-lo ativa ou passivamente, em qualquer instância ou tribunal.</li>");
                if(grupo_mapfre)
                {
                    THERMO.Append("           <li align=\"justify\"<strong>SEGURO DE VIDA EM GRUPO.</strong> O PROPONENTE FICA CIENTE DE QUE A ADMINISTRADORA PODERÁ ESTIPULAR SEGURO DE VIDA EM GRUPO, CONTRATADO COM COMPANHIA SEGURADORA ESCOLHIDA POR ELA, INSCREVENDO COMO SEGURADOS OS PARTICIPANTES DO GRUPO, <span style=\"background - color: #FFFF00\">DESDE QUE SEJA DECLARADO PELO PROPONENTE</span>, COMO REQUISITOS PARA SER SEGURADO, <strong>QUE GOZA DE BOA SAÚDE, NÃO TEM DEFICIÊNCIA DE ÓRGÃOS, MEMBROS OU SENTIDOS, NAO SOFRE DE MOLÉSTIA GRAVE DESDE OS TRÊS ÚLTIMOS ANOS,</strong> ciente de que quaisquer omissões tornarão nulo o seguro de vida em grupo, nos termos dos artigos 765 e 766 do Código Civil e concorda com sua inclusão como Segurado, figurando como estipulante a <strong>ADMINISTRADORA</strong> e beneficiário o próprio grupo, observadas as seguintes condições para aceitação da inclusão como segurado:");
                    THERMO.Append("             <br />");
                    THERMO.Append("               <strong>A)</strong> ter mais de 14 (quatorze) anos e menos de 70 (setenta) anos na data da inclusão como aderente ao grupo de consórcio;");
                    THERMO.Append("               <br /><strong>B)</strong> a soma da idade do aderente com o prazo de vida do grupo de consórcio, na data de sua inclusão como participante do grupo, não pode ser superior a 80 (oitenta) anos.");
                    THERMO.Append("             <br/>");
                    THERMO.Append("           </li>");
                }
                else
                {
                    THERMO.Append("           <li align=\"justify\">CONTRATO DE SEGURO. O <strong>PROPONENTE</strong> FICA CIENTE DE QUE A <strong>ADMINISTRADORA</strong> PODERÁ ESTIPULAR SEGURO DE VIDA EM GRUPO OU SEGURO DE ACIDENTES PESSOAIS COLETIVOS, CONTRATADO COM COMPANHIA SEGURADORA ESCOLHIDA POR ELA, INSCREVENDO COMO SEGURADOS OS PARTICIPANTES DO GRUPO EM UMA DESSAS MODALIDADES, DE ACORDO COM OS LIMITES DE IDADE ESTABELECIDOS PELA SEGURADORA, NA SEGUINTE FORMA:");
                    THERMO.Append("             <br />");
                    THERMO.Append("               <strong>1.</strong> SEGURO DE VIDA EM GRUPO: podem fazer parte dessa modalidade de seguro os proponentes cuja soma de sua idade e prazo previsto de participação no grupo de consórcio resulte no limite máximo de 75 (setenta e cinco) anos.");
                    THERMO.Append("               <br /><strong>2.</strong> SEGURO DE ACIDENTES PESSOAIS EM GRUPO: podem fazer parte dessa modalidade de seguro os proponentes cuja soma de sua idade e prazo previsto de participação no grupo de consórcio resulte na faixa etária de 76 (setenta e seis) a 85 (oitenta e cinco) anos.");
                    THERMO.Append("             <br/>");
                    THERMO.Append("           </li>");
                }
                if (grupo_mapfre)
                {
                    THERMO.Append("           <li align=\"justify\">DECLARAÇÕES DO <strong>PROPONENTE</strong>:");
                    THERMO.Append("             <br />");
                    THERMO.Append("               <strong>A)</strong> O Proponente declara que concorda com sua inclusão como segurado no Contrato de Seguro, descrito no item 5, acima, e que <strong>GOZA DE BOA SAÚDE, NÃO TEM DEFICIÊNCIA DE ÓRGÃOS, MEMBROS OU SENTIDOS, E NAO SOFRE DE MOLÉSTIA GRAVE DESDE OS TRÊS ÚLTIMOS ANOS.</strong>");
                    THERMO.Append("               <br /><strong>B)</strong> O <strong>PROPONENTE</strong> DECLARA QUE TEM CONDIÇÕES FINANCEIRAS PARA ADERIR AO GRUPO DE CONSÓRCIO OBJETO DESTA PROPOSTA, E QUE TEM RENDIMENTOS SUFICIENTES PARA ASSUMIR OS COMPROMISSOS CONTRATUAIS DE PARTICIPAÇÃO NO GRUPO DE CONSÓRCIO, DISPONDO-SE A COMPROVÁ-LOS PERANTE A <strong>ADMINISTRADORA</strong>, SE NECESSÁRIOS PARA A APROVAÇÃO DE SUA ADESÃO, DECLARANDO DESDE JÁ QUE SEUS SALÁRIOS/FATURAMENTOS MENSAIS SÃO DE R$ <strong>" + cliente.vl_rendacapital.ToString("#,#.00;(#,#.00)") + "</strong>.");
                    THERMO.Append("               <br /><strong>C)</strong> O <strong>PROPONENTE</strong> ACEITA SER INCLUÍDO EM GRUPO DE CONSÓRCIO CUJAS ASSEMBLEIAS SEJAM REALIZADAS NA SEDE DA <strong>ADMINISTRADORA</strong> OU EM LOCAIS A SEREM DEFINIDOS POR ELA, AINDA QUE FORA DE SEU DOMICÍLIO, E QUE TAL FATO NÃO OBSTA SUA EFETIVA PARTICIPAÇÃO NO GRUPO DE CONSÓRCIO.");
                    THERMO.Append("             <br />");
                    THERMO.Append("           </li>");
                }
                else
                {
                    THERMO.Append("           <li align=\"justify\">DECLARAÇÕES DO <strong>PROPONENTE</strong>:");
                    THERMO.Append("             <br />");
                    THERMO.Append("               <strong>A)</strong> O <strong>PROPONENTE</strong> DECLARA QUE CONCORDA COM SUA INCLUSÃO COMO SEGURADO DE UMA DAS MODALIDADES DE CONTRATO DE SEGURO ESTIPULADAS NO ITEM 5 ACIMA, E QUE NÃO TEM RESTRIÇÕES DE SAÚDE E IDADE QUE O IMPEÇA DE SE TORNAR SEGURADO, CONFORME REQUISITOS EXIGIDOS PELA SEGURADORA.");
                    THERMO.Append("               <br /><strong>B)</strong> O <strong>PROPONENTE</strong> DECLARA QUE TEM CONDIÇÕES FINANCEIRAS PARA ADERIR AO GRUPO DE CONSÓRCIO OBJETO DESTA PROPOSTA, E QUE TEM RENDIMENTOS SUFICIENTES PARA ASSUMIR OS COMPROMISSOS CONTRATUAIS DE PARTICIPAÇÃO NO GRUPO DE CONSÓRCIO, DISPONDO-SE A COMPROVÁ-LOS PERANTE A <strong>ADMINISTRADORA</strong>, SE NECESSÁRIOS PARA A APROVAÇÃO DE SUA ADESÃO, DECLARANDO DESDE JÁ QUE SEUS SALÁRIOS/FATURAMENTOS MENSAIS SÃO DE R$ <strong>" + cliente.vl_rendacapital.ToString("#,#.00;(#,#.00)") + "</strong>.");
                    THERMO.Append("               <br /><strong>C)</strong> O <strong>PROPONENTE</strong> ACEITA SER INCLUÍDO EM GRUPO DE CONSÓRCIO CUJAS ASSEMBLEIAS SEJAM REALIZADAS NA SEDE DA <strong>ADMINISTRADORA</strong> OU EM LOCAIS A SEREM DEFINIDOS POR ELA, AINDA QUE FORA DE SEU DOMICÍLIO, E QUE TAL FATO NÃO OBSTA SUA EFETIVA PARTICIPAÇÃO NO GRUPO DE CONSÓRCIO.");
                    THERMO.Append("             <br />");
                    THERMO.Append("           </li>");
                }
                THERMO.Append("         </ol>");
                THERMO.Append("         <br /><p  align=\"justify\">COMO MANIFESTAÇÃO EXPRESSA DE SUA VONTADE E INTERESSE DE INGRESSAR EM GRUPO DE CONSÓRCIO ADMINISTRADO POR <strong>" + administradora + "</strong>., O <strong>PROPONENTE</strong> DECLARA QUE LEU E ACEITA TODOS OS SEUS TERMOS, BEM COMO ESTÁ DE ACORDO COM TODAS AS NORMAS QUE REGEM O FUNCIONAMENTO DO GRUPO DE CONSÓRCIO, OBRIGANDO-SE POR TODAS AS CLÁUSULAS E CONDIÇÕES DO CONTRATO DE PARTICIPAÇÃO QUE ENCONTRA-SE DISPONÍVEL NO SITE <strong>WWW." + site.login.ToUpper() + "</strong>, CIENTE DE QUE SUA ADESÃO AO GRUPO DE CONSÓRCIO SÓ SE EFETIVARÁ APÓS A APROVAÇÃO DESTA PROPOSTA PELA <strong>ADMINISTRADORA</strong>.</p>");
                THERMO.Append("         </font>");
                THERMO.Append("    </td>");
                THERMO.Append("  </tr>");
                THERMO.Append("</table>");
                #endregion

                #region Converte THERMO em PDF -----------

                PdfPCell cellcodbarthermo = new PdfPCell();
                cellcodbarthermo.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellcodbarthermo.Border = Rectangle.NO_BORDER;

                List<IElement> htmlarraylistthermo = HTMLWorker.ParseToList(new StringReader(THERMO.ToString()), null);
                for (int k = 0; k < htmlarraylistthermo.Count; k++)
                {
                    //doc.Add((IElement)htmlarraylist[k]);
                    cellcodbarthermo.AddElement((IElement)htmlarraylistthermo[k]);
                }
                ///AQUI==========================================================================
                PdfPCell tr3td1thermo = new PdfPCell(cellcodbarthermo);
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