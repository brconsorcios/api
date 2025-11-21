using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace exp.dados
{
    public class GerarPropostaHTML
    {
        public indicaco indicacao { get; set; }
        public site site { get; set; }
        public SiteLayout Layout { get; set; }

        public StringBuilder html()
        {

            string administradora = "{NOME_ADMINISTRADORA}";
            string cnpj = "{CNPJ_ADMINISTRADORA}";
            string txtgrupo = string.Empty;

            string tipoCliente = "F";
            Boolean exibirConta = false;


            StringBuilder HTML = new System.Text.StringBuilder();
            HTML.Append("<br />");
            HTML.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTitulos + "\"><font color=\"" + Layout.CorFontTitulos + "\" face=\"Arial Narrow\" size=\"1\"> <strong>DADOS DA ADMINISTRADORA</strong> </font></td>");
            HTML.Append("  </tr>");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTabela + "\"><!--01--> ");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\"> ");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>CNPJ:</strong> </font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + cnpj + "</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Razão Social:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + administradora + "</font>");
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\"> ");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Endereço:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">{ENDERECO_ADMINISTRADORA}</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Bairro:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">{BAIRRO_ADMINISTRADORA}</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Cidade / Estado:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">{CIDADE/ESTADO ADMINISTRADORA}</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>CEP:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">{CEP ADMINISTRADORA}</font>");
            HTML.Append("          </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      </td><!--01-->");
            HTML.Append("  </tr> ");
            HTML.Append("</table>");
            HTML.Append("<br />");
            HTML.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTitulos + "\"><font color=\"" + Layout.CorFontTitulos + "\" face=\"Arial\" size=\"1\"> <strong>DADOS DE IDENTIFICAÇÂO DO PROPONENTE</strong> </font></td>");
            HTML.Append("  </tr>");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTabela + "\"><!--02-->");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Nome/Razão:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "{NOME}" + "</font>");

            if (tipoCliente == "F")
            {
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Sexo:</strong></font> ");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "{SEXO}" + "</font>");

                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Estado Civil:</strong></font> ");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "{ESTADO CIVIL}" + "</font>");
            }


            HTML.Append("          </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>CPF/CNPJ:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "{CPF/CNPJ}" + "</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>RG/I.E:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "{RG/IE}" + "</font>");
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Data Nascimento/Fundação:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[DATA NASC/FUND]" + "</font>");
            if (tipoCliente == "F")
            {
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong> Profissão:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[PROFISSAO]" + "</font>");
            }
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Endereço:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[ENDEREÇO]" + "</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Complemento:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[COMPLEMENTO]" + "</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Bairro:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[BAIRRO]" + "</font>");
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Cidade:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[CIDADE]" + "</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>UF:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[UF]" + "</font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Cep:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[CEP]" + "</font>");
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>E-mail:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[E-mail]" + "</font>");
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Telefone:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[TELEFONE]" + "</font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Celular:</strong></font> ");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[CELULAR]" + "</font> ");
            HTML.Append("        </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      </td><!--02-->");
            HTML.Append("  </tr>");
            HTML.Append("</table>");
            HTML.Append("<br />");

            if (tipoCliente == "J")
            {
                HTML.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">   ");
                HTML.Append("  <tr>");
                HTML.Append("    <td bgcolor=\"" + Layout.CorFndTitulos + "\"><font color=\"" + Layout.CorFontTitulos + "\" face=\"Arial\" size=\"1\"> <strong>OUTROS DADOS PESSOA JURÍDICA</strong></font></td>  ");
                HTML.Append("  </tr>");
                HTML.Append("  <tr>");
                HTML.Append("    <td bgcolor=\"" + Layout.CorFndTabela + "\"><!--03-->");
                HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\"> ");
                HTML.Append("        <tr>");
                HTML.Append("          <td>");

                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Nome do Sócio Majoritário</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[SOCIO]" + "</font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>CPF:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[CPF]" + "</font><br />");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Data de Nascimento:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[DATA NASC. SOCIO]" + "</font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Sexo:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[SEXO]" + "</font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Estado Civil:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[ESTADO CIVIL]" + "</font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Celular:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[CELULAR]" + "</font>");
                HTML.Append("           </td>");
                HTML.Append("        </tr>");
                HTML.Append("      </table>");
                //HTML.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\"> ");
                //HTML.Append("        <tr>");
                //HTML.Append("          <td>");
                //HTML.Append("           <font color=\"" + CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Data de Nascimento:</strong></font> ");
                //HTML.Append("           <font color=\"" + CorFontValor + "\" face=\"Arial\" size=\"1\">01/01/1970</font> ");
                //HTML.Append("           <font color=\"" + CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>CPF:</strong></font> ");
                //HTML.Append("           <font color=\"" + CorFontValor + "\" face=\"Arial\" size=\"1\">20527394164654</font> ");
                //HTML.Append("           <font color=\"" + CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Sexo:</strong></font> ");
                //HTML.Append("           <font color=\"" + CorFontValor + "\" face=\"Arial\" size=\"1\">M</font>");
                //HTML.Append("           </td>");
                //HTML.Append("        </tr>");
                //HTML.Append("      </table>");
                HTML.Append("        ");
                HTML.Append("      <!--03--></td>");
                HTML.Append("  </tr> ");
                HTML.Append("</table>");
                HTML.Append("<br />");
            }
            HTML.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">   ");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTitulos + "\"><font color=\"" + Layout.CorFontTitulos + "\" face=\"Arial\" size=\"1\"> <strong>CARACTERÍSTICAS DO PLANO</strong></font></td>      ");
            HTML.Append("  </tr>");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTabela + "\">");
            HTML.Append("       <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\"> ");
            HTML.Append("        <tr>");
            HTML.Append("          <td>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Nº de participantes:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.qt_participante + "</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Prazo do grupo:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.pz_comercializacao + " meses</font>");
            if (indicacao.st_grupo == "A")
            {
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Prazo reduzido:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.meses_restante + " meses</font>");

            }
            HTML.Append("           <br /><font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Taxa de Administração:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.pe_ta_plano + " %</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Fundo de Reserva:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.pe_fr_plano + " %</font>");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Seguro Prestamista:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.pe_sg + " %</font>");
            HTML.Append("           </td>");
            HTML.Append("        </tr>");
            HTML.Append("      </table>");
            HTML.Append("      <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">Grupo formado com valores de crédito e taxa de administração diferenciados.</font>");
            HTML.Append("     </td> ");
            HTML.Append("  </tr> ");
            HTML.Append("</table>");
            HTML.Append("<br />");
            HTML.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">   ");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTitulos + "\"><font color=\"" + Layout.CorFontTitulos + "\" face=\"Arial\" size=\"1\"> <strong>CARACTERÍSTICAS DO OBJETO DO CONTRATO</strong></font></td>        ");
            HTML.Append("  </tr>");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTabela + "\">");
            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Bem:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.nm_bem + " </font><br />");

            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Valor do bem na Adesão:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">R$ " + indicacao.vl_bem.Value.ToString("#,#.00;(#,#.00)") + " </font><br />");

            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Valor da parcela na Adesão:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">R$ " + indicacao.vl_parcela.Value.ToString("#,#.00;(#,#.00)") + " </font><br />");

            HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Indice de atualização do crédito:</strong></font>");
            HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + indicacao.indice_reajuste + " </font>");

            HTML.Append("    </td>");
            HTML.Append("  </tr>");
            HTML.Append("</table>");


            HTML.Append("<br />");
            HTML.Append("<table width=\"100%\" bordercolor=\"" + Layout.CorFndTitulos + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\">   ");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTitulos + "\"><font color=\"" + Layout.CorFontTitulos + "\" face=\"Arial\" size=\"1\"> <strong>CONTA DEPÓSITO</strong></font></td>        ");
            HTML.Append("  </tr>");
            HTML.Append("  <tr>");
            HTML.Append("    <td bgcolor=\"" + Layout.CorFndTabela + "\">");

            if (exibirConta)
            {
                string conta = "Conta Exemplo - Banco Exemplo";
                var parts = conta.Split('-').ToList().Select(x => x.Trim()).ToList();
                string tipo_conta = parts?[0];
                string nome_banco = parts?[1];
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">Autorizo o depósito de eventuais recursos remanescentes após o encerramento do grupo, conforme contrato, na conta abaixo:</font><br />");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Tipo da conta:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + tipo_conta + " </font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Banco:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + nome_banco + " </font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Agência:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[Agência]" + " </font>");
                HTML.Append("           <font color=\"" + Layout.CorFontCampo + "\" face=\"Arial\" size=\"1\"><strong>Conta Corrente:</strong></font>");
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">" + "[Conta]" + " </font>");
            }
            else
            {
                HTML.Append("           <font color=\"" + Layout.CorFontValor + "\" face=\"Arial\" size=\"1\">Não quero informar meus dados bancários.</font>");

            }
            HTML.Append("    </td>");
            HTML.Append("  </tr>");
            HTML.Append("</table>");

            return HTML;
        }
    }
}