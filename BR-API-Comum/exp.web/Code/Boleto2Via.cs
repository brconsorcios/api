using System;
using System.Web.Hosting;
using exp.core;

namespace exp.web.Code
{
    public static class Boleto2Via
    {
        public static string Emitir(int id)
        {
            var boletocnp = AcessoWebService.EmitirBoleto2Via(id);


            if (boletocnp != null)
            {
                var sacadoCnpjCpf = "";

                //Boleto em PDF##############################################
                var sacado = string.Empty;

                if (boletocnp.Sacado != null)
                {
                    sacado = boletocnp.Sacado.Split(new[] { "   ", "\n" }, StringSplitOptions.None)[0].Trim();

                    var descSacado = boletocnp.Sacado.Replace("\r\n", "#");
                    var vetSacado = descSacado.Split('#');
                    foreach (var dsDocumento in vetSacado)
                        if (dsDocumento.IndexOf("CPF:") > 0)
                            sacadoCnpjCpf = dsDocumento.Substring(dsDocumento.IndexOf("CPF:"));
                }
                else
                {
                    sacado = boletocnp.NM_Sacado;
                }


                var PrimeiroNomeSacado = sacado.PrimeiroNome();
                var IniciaisDoNomeSacado = sacado.LetrasIniciaisDoNome();


                var novoboleto = new GerarBoletoPdf();

                //string _BancoCodigo = "399";
                //string _BancoCodigoDV = "9";
                //if (boletocnp.NM_Banco_Reduzido != null)
                //{
                //    if (boletocnp.NM_Banco_Reduzido.ToUpper().Contains("BANESE"))
                //    {
                //        _BancoCodigo = "047";
                //        _BancoCodigoDV = "7";
                //    }
                //}

                var _BancoCodigo = "399";
                var _BancoCodigoDV = "9";

                if (boletocnp.NM_Banco_Reduzido != null)
                {
                    if (boletocnp.NM_Banco_Reduzido.ToUpper().Contains("BANESE"))
                    {
                        _BancoCodigo = "047";
                        _BancoCodigoDV = "7";
                    }
                    else if (boletocnp.NM_Banco_Reduzido.ToUpper().Contains("CAIXA"))
                    {
                        _BancoCodigo = "104";
                        _BancoCodigoDV = "0";
                    }
                    else if (boletocnp.NM_Banco_Reduzido.ToUpper().Contains("BRADESCO"))
                    {
                        _BancoCodigo = "237";
                        _BancoCodigoDV = "2";
                    }

                    boletocnp.CD_Banco = _BancoCodigo + "-" + _BancoCodigoDV;
                }

                var datavencimento = Convert.ToDateTime(boletocnp.DT_Vencimento).ToString("dd/MM/yyyy");

                novoboleto.nome_do_banco = boletocnp.NM_Banco_Reduzido; // "Bradesco";
                novoboleto.no_do_banco = _BancoCodigo + "-" + _BancoCodigoDV;
                novoboleto.path_imagens =
                    HostingEnvironment.MapPath("~/content/imagesboleto/"); //Server.MapPath("~/content/imagesboleto/");
                novoboleto.path_do_pdf =
                    HostingEnvironment.MapPath("~/content/boletos2via/"); //Server.MapPath("~/content/boletos/");
                novoboleto.logomarca =
                    boletocnp.CD_Banco +
                    ".jpg"; //"/bradesco_color.jpg";//"/hsbc_color.jpg"  "/bradesco_color.jpg" "/banese_color.jpg"
                novoboleto.background_imgem = "/br-loader.jpg";
                novoboleto.none_do_pdf = "boleto_2Via" + id + ".pdf"; //DateTime.Now.Ticks
                novoboleto.agencia_cod_cedente = boletocnp.Agencia_Cedente; // "7130/28223-4";
                novoboleto.vencimento = datavencimento;
                novoboleto.especie_doc = boletocnp.Especie_Documento; // "PARC.CONS";
                novoboleto.sacado =
                    PrimeiroNomeSacado + " - " +
                    sacadoCnpjCpf; //@"CIA de trabalhos dos amigos do Gustavo Ltda";//"EXPERTU AGENCIA DE INTERNET LTDA ME";
                novoboleto.sacador_avalista = " - ";
                //novoboleto.valor_do_documento = boletocnp.VL_Documento.Replace(".", ",");
                //novoboleto.outros_acrescimos = boletocnp.VL_Outros_Acrescimos.Replace(".", ",");
                //novoboleto.mora_multa = boletocnp.VL_Multa.Replace(".", ",");
                //novoboleto.outras_deducoes = boletocnp.VL_Outras_Deducoes.Replace(".", ",");
                //novoboleto.desconto_abatimentos = boletocnp.VL_Desconto.Replace(".", ",");
                //novoboleto.valor_cobrado = boletocnp.VL_Cobrado.Replace(".", ",");

                #region Foi removido para segunda via do boleto

                //if (Funcao.IsDecimal(boletocnp.VL_Outros_Acrescimos))
                //{
                //    decimal Outros_Acrescimos = Convert.ToDecimal(boletocnp.VL_Outros_Acrescimos.Replace(".", ","));
                //    if (Outros_Acrescimos > 0)
                //    {
                //        novoboleto.outros_acrescimos = Outros_Acrescimos.ToString("#,#.00#;(#,#.00#)");// "200,12";
                //    }
                //    else
                //    {
                //        novoboleto.outros_acrescimos = "-";
                //    }
                //}
                //else
                //{
                //    novoboleto.outros_acrescimos = boletocnp.VL_Outros_Acrescimos;// " - ";
                //}


                //if (Funcao.IsDecimal(boletocnp.VL_Multa))
                //{
                //    decimal VLMulta = Convert.ToDecimal(boletocnp.VL_Multa.Replace(".", ","));
                //    if (VLMulta > 0)
                //    {
                //        novoboleto.mora_multa = VLMulta.ToString("#,#.00#;(#,#.00#)");// "200,12";
                //    }
                //    else
                //    {
                //        novoboleto.mora_multa = "-";
                //    }
                //}
                //else
                //{
                //    novoboleto.mora_multa = boletocnp.VL_Multa;// "0,00";
                //}

                //if (Funcao.IsDecimal(boletocnp.VL_Outras_Deducoes))
                //{
                //    decimal Outras_Deducoes = Convert.ToDecimal(boletocnp.VL_Outras_Deducoes.Replace(".", ","));
                //    if (Outras_Deducoes > 0)
                //    {
                //        novoboleto.outras_deducoes = Outras_Deducoes.ToString("#,#.00#;(#,#.00#)");// "200,12";
                //    }
                //    else
                //    {
                //        novoboleto.outras_deducoes = "-";
                //    }
                //}

                //else
                //{
                //    novoboleto.outras_deducoes = boletocnp.VL_Outras_Deducoes;//"0,00";
                //}
                //if (Funcao.IsDecimal(boletocnp.VL_Desconto))
                //{
                //    decimal VLDesconto = Convert.ToDecimal(boletocnp.VL_Desconto.Replace(".", ","));
                //    if (VLDesconto > 0)
                //    {
                //        novoboleto.desconto_abatimentos = VLDesconto.ToString("#,#.00#;(#,#.00#)");// "200,12";
                //    }
                //    else
                //    {
                //        novoboleto.desconto_abatimentos = "-";
                //    }
                //}
                //else
                //{
                //    novoboleto.desconto_abatimentos = boletocnp.VL_Desconto;/// "0,00";
                //}

                //Foi retirado para segunda via do boleto
                //Valor do documento é igual o valor cobrado
                //if (Funcao.IsDecimal(boletocnp.VL_Documento))
                //{
                //    decimal vlrdoc = Convert.ToDecimal(boletocnp.VL_Documento.Replace(".", ","));
                //    novoboleto.valor_do_documento = vlrdoc.ToString("#,#.00#;(#,#.00#)");// "200,12";
                //}
                //else
                //{
                //    novoboleto.valor_do_documento = boletocnp.VL_Documento;// "200,12";
                //}

                #endregion

                novoboleto.outros_acrescimos = "-";
                novoboleto.mora_multa = "-";
                novoboleto.outras_deducoes = "-";
                novoboleto.desconto_abatimentos = "-";

                if (Funcao.IsDecimal(boletocnp.VL_Cobrado))
                {
                    var VLCobrado = Convert.ToDecimal(boletocnp.VL_Cobrado.Replace(".", ","));

                    if (VLCobrado > 0)
                    {
                        novoboleto.valor_cobrado = VLCobrado.ToString("#,#.00#;(#,#.00#)"); // "200,12";
                        novoboleto.valor_do_documento = VLCobrado.ToString("#,#.00#;(#,#.00#)"); // "200,12";
                    }
                    else
                    {
                        novoboleto.valor_cobrado = "-";
                        novoboleto.valor_do_documento = "-"; // "200,12";
                    }
                }
                else
                {
                    novoboleto.valor_cobrado = boletocnp.VL_Cobrado; //"200,12";
                    novoboleto.valor_do_documento = boletocnp.VL_Cobrado; // "200,12";
                }


                novoboleto.instrucoes =
                    boletocnp.Mensagem_Compensacao; // "NÃO RECEBER APÓS O VENCIMENTO\nLinha2\nLinha3";
                novoboleto.quantidade = " - ";
                novoboleto.especie = boletocnp.Especie_Moeda; // "R$";
                novoboleto.carteira = boletocnp.NO_Carteira_Impressa_Boleto; // "CE";
                novoboleto.data_processamento =
                    Convert.ToDateTime(boletocnp.DT_Documento)
                        .ToString("dd/MM/yyyy"); // DateTime.Now.ToString("dd/MM/yyyy");

                novoboleto.nosso_numero = boletocnp.Nosso_Numero; //"198/00000004-4";
                novoboleto.demonstrativo = boletocnp.Mensagem_Recibo; //@"
                //Grupo/Cota: 00521/0025
                //Detalhes dos recebimentos:
                //Histórico                       Valor       Multa       Juros       Devido      Receber     Pel     Assembléia      Vencimento
                //001-0 RECBTO. PARCELA       1.255,556        0,00        0,00     1.255,56     1,285,56     007     28/10/2014      28/10/2014";
                novoboleto.no_do_documento = boletocnp.NO_Documento; //"0800000016";
                novoboleto.no_divitavel =
                    boletocnp.Linha_Digitavel; //"34191.98001 00000.430405 04328.223203 7 62380000015000";
                novoboleto.codigo_de_barras = boletocnp.CD_Barra; //"39993623000000177014363132000005001835330142";
                novoboleto.local_de_pagamento =
                    "Pagável em qualquer Banco até o vencimento"; //boletocnp.NM_Local_Pagto;//"Pagavel em qualquer banco até o vencimento";//"PAGAVEL EM QUALQUER BANCO PARTICIPANTE DO COMPENSACAO NACIONAL ATE O VENCIMENTO."; 
                novoboleto.cedente = boletocnp.NM_Cedente; //"BR CONSÓRCIOS ADM. DE CONSÓRCIOS LTDA";
                novoboleto.CD_Inscricao_Nacional = boletocnp.CD_Inscricao_Nacional; //CNPJ: 14.723.388/0001-63
                novoboleto.data_do_documento = Convert.ToDateTime(boletocnp.DT_Documento).ToString("dd/MM/yyyy");
                novoboleto.aceite = boletocnp.SN_Aceite; //"N";


                if (novoboleto.executar())
                    return novoboleto.none_do_pdf + ";" + PrimeiroNomeSacado + ";" + IniciaisDoNomeSacado + ";" +
                           novoboleto.valor_cobrado + ";" + datavencimento + "";

                return string.Empty;
                //else
                //{
                //    if (System.IO.File.Exists(novoboleto.path_do_pdf + novoboleto.none_do_pdf))
                //    {
                //        return novoboleto.none_do_pdf;
                //    }
                //    else
                //    {

                //        return string.Empty;
                //    }
                //}
            }

            return string.Empty;
        }
    }
}