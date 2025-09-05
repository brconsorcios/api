using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrConsorcio.Api.Models;
using Microsoft.Extensions.Options;
using BrConsorcio.Api.Services;
using BrConsorcio.Api.Helpers;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrConsorcio.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    
    public class PagamentosController : Controller
    {
        private readonly PagConsorcio _pagConsorcio;
        private readonly IBrConsorcio _brConsorcio;
        public PagamentosController(IOptions<PagConsorcio> pagConsorcio, IBrConsorcio brConsorcio)
        {
            _pagConsorcio = pagConsorcio.Value;
            _brConsorcio = brConsorcio;
        }

        [HttpPost]
        [Route("Boleto")]
        public async Task<IActionResult> Boleto([FromBody]IndicacaoPgtoBoletoModel Boleto)
        {
            try
            {
                if (!Boleto.check_termo.Value)
                {
                    ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário aceitar os termos de uso!");
                    return BadRequest(ModelState);
                }

                // var retorno = await _brConsorcio.EmitirBoleto(Boleto.id);
                var BenIndicacao = await _brConsorcio.ObterIndicacao(Boleto.id);

                BenIndicacao.id_forma_recebimento = "BB";

                ///Modifica dados bancarios#####################################################################################

                //IndicacaoPgtoDeposito deposito = new IndicacaoPgtoDeposito();

                //deposito.id = BenIndicacao.id_pessoa.Value;

                //if (Boleto.check_dadosbancarios.Value)
                //{

                //    if (string.IsNullOrWhiteSpace(Boleto.nome_banco))
                //    {
                //        ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário informar o Banco!");
                //    }
                //    if (string.IsNullOrWhiteSpace(Boleto.agencia))
                //    {
                //        ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário informar a Agência!");
                //    }
                //    if (string.IsNullOrWhiteSpace(Boleto.numero_conta))
                //    {
                //        ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário informar a Conta!");

                //    }
                //    if (!ModelState.IsValid)
                //    {
                //        return BadRequest(ModelState);
                //    }



                //    // deposito.id = BenIndicacao.indicacao.id_pessoa.Value;
                //    deposito.tipo_conta = Boleto.tipo_conta;
                //    deposito.nome_banco = Boleto.nome_banco;
                //    deposito.agencia = Boleto.agencia;
                //    deposito.numero_conta = Boleto.numero_conta;
                //    deposito.exibirconta = true;
                //}
                //else
                //{
                //    deposito.exibirconta = false;
                //}


                //var RespostaDeposito = await _brConsorcio.InformarDadosBancarios(deposito);

                //if (RespostaDeposito.erros != null)
                //{
                //    foreach (KeyValuePair<string, string[]> kvp in RespostaDeposito.erros)
                //    {
                //        if (kvp.Value.Length > 0)
                //        {
                //            ModelState.AddModelError(kvp.Key, kvp.Value[0]);
                //        }
                //    }
                //}
                if (BenIndicacao.id_documento is null)
                {
                    var resposta = await _brConsorcio.SalvarPropostaDaCompra(Boleto.id);

                    // ***********************************************************************
                    if (resposta is null)
                    {
                        ModelState.AddModelError("indicacao.id_forma_recebimento", "Não foi possível gravar a proposta na opção boleto bancário. Tente outra vez, se o erro persistir entre em contato.");
                    }
                    else
                    {
                        if (resposta.erros is null)
                        {
                            /* 1.9. Enviar e-mail ao comprador ao finalizar uma compra online. 
                            //Atualiza a indicacao
                            BenIndicacao = resposta.Objeto;

                            string body = string.Concat("Sua compra foi realizada com sucesso: ",Boleto.id," - ", BenIndicacao.id_bem," - ",BenIndicacao.nm_bem," - ",BenIndicacao.nm_plano_venda);
                            //enviar por email a nova senha.
                            await _emailService.Enviar(string.Concat("Compra realizada com sucesso: ", Boleto.id), body, new MimeKit.MailboxAddress("ttpassarella@stefanini.com"));
                            */
                            return Ok(resposta.Objeto.id_documento);
                        }
                        else
                        {
                            string msgs = string.Empty;

                            foreach (KeyValuePair<string, string[]> kvp in resposta.erros)
                            {

                                if (kvp.Value.Length > 0 && kvp.Value[0].ToUpper() != "fn_VeSNValidaRenda".ToUpper())
                                {
                                    ModelState.AddModelError(kvp.Key, kvp.Value[0]);
                                    msgs = msgs + " " + kvp.Value[0] + "; ";
                                }
                            }
                            // ** [RETORNO] Pagina de msg para o cliente
                            //  EnviaEmailConfirmacaoErro(resposta.objeto, msgs);

                        }
                    }
                }
                else
                {
                    // ***********************************************************************
                    // ** [API] BOLETO
                    // ***********************************************************************

                    var respostaMudarStatusDePagamento = await _brConsorcio.MudarStatusDePagamentoBB(BenIndicacao);

                    if (respostaMudarStatusDePagamento != null)
                    {
                        if (respostaMudarStatusDePagamento.erros != null)
                        {
                            foreach (KeyValuePair<string, string[]> kvp in respostaMudarStatusDePagamento.erros)
                            {
                                if (kvp.Value.Length > 0)
                                    ModelState.AddModelError(kvp.Key, kvp.Value[0]);
                                //TempData[Alerts.ERROS] = String.Format("{0}<br />", kvp.Value[0]);
                            }
                        }
                        else
                        {
                            return Ok(BenIndicacao.id_documento);

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("indicacao.id_forma_recebimento", "Não foi possível realizar esta transação com boleto bancário. O serviço não disponivel no momento.");
                    }


                }



                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        // POST api/values
        [HttpPost]
        [Route("Cartao")]
        public async Task<IActionResult> Post([FromBody]IndicacaoPgtoCartaoModel CartaoCredito)
        {
            if (!CartaoCredito.check_termo.Value)
            {
                ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário aceitar os termos de uso!");
                return BadRequest(ModelState);
            }



            var BenIndicacao = await _brConsorcio.ObterIndicacao(CartaoCredito.id);


            ///Modifica dados bancarios#####################################################################################
            //var deposito = new IndicacaoPgtoDeposito();

            //deposito.id = BenIndicacao.id_pessoa.Value;

            //if (CartaoCredito.check_dadosbancarios.Value)
            //{
            //    if (string.IsNullOrWhiteSpace(CartaoCredito.nome_banco))
            //    {
            //        ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário informar o Banco!");
            //    }
            //    if (string.IsNullOrWhiteSpace(CartaoCredito.agencia))
            //    {
            //        ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário informar a Agência!");
            //    }
            //    if (string.IsNullOrWhiteSpace(CartaoCredito.numero_conta))
            //    {
            //        ModelState.AddModelError("indicacao.id_forma_recebimento", "É necessário informar a Conta!");

            //    }
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }



            //    deposito.tipo_conta = CartaoCredito.tipo_conta;
            //    deposito.nome_banco = CartaoCredito.nome_banco;
            //    deposito.agencia = CartaoCredito.agencia;
            //    deposito.numero_conta = CartaoCredito.numero_conta;
            //    deposito.exibirconta = true;
            //}
            //else
            //{
            //    deposito.exibirconta = false;
            //}

            //var RespostaDeposito = await _brConsorcio.InformarDadosBancarios(deposito);

            //if (RespostaDeposito.erros != null)
            //{
            //    foreach (KeyValuePair<string, string[]> kvp in RespostaDeposito.erros)
            //    {
            //        if (kvp.Value.Length > 0)
            //        {
            //            ModelState.AddModelError(kvp.Key, kvp.Value[0]);
            //        }
            //    }
            //}


            //Validar formulário Cartão de crédito
            if (ModelState.IsValid)
            {

                // Monta indicação com cartão de crédito
                var indicacao = new Indicaco();
                indicacao.status = 4; //vendida

                //define que o pagamento pelo cliente
                CartaoCredito.check_pgto = true;

                PagamentoHelper.PeparaCC(ref CartaoCredito);


                var resposta = await _brConsorcio.SalvarPropostaDaCompra(CartaoCredito.id);



                // Verifica se salvou a proposta
                if (resposta is null)
                {
                    ModelState.AddModelError("indicacao.id_forma_recebimento", "Não foi possível gravar a proposta na opção Cartão de Crédito. Tente outra vez, se o erro persistir entre em contato.");
                }
                else
                {

                    // Contem erros ao salvar a proposta
                    if (resposta.erros is null)
                    {
                        // ***********************************************************************
                        // ** [API] CARTOESDECREDITO
                        // ** Ao retornar do SuperPay verifica o status da situação da transação.
                        // ** Caso esteja ok redireciona para o resumo da compra
                        // ** caso contrário ira retornar para a página de pagamento com os erros.
                        // ***********************************************************************
                        #region === CARTOESDECREDITO ===

                        var respostaindicacao = await _brConsorcio.SalvarCartaoPagConsorcio(CartaoCredito, _pagConsorcio.Key);

                        if (respostaindicacao is null)
                        {
                            ModelState.AddModelError("indicacao.id_forma_recebimento", "Não foi possível realizar esta transação com cartão de crédito. O serviço não disponivel no momento, por favor escolha a opção Boleto Bancário.");
                        }
                        else
                        {
                            if (respostaindicacao.erros is null)
                            {
                                if (PagamentoHelper.VerificaRetornoStatusSuperPay(respostaindicacao.Objeto.statuspgto))
                                    ModelState.AddModelError("indicacao.id_forma_recebimento", $"A transação foi recusada ({respostaindicacao.Objeto.StatusPagamento()}). Por favor, utilize outro Cartão de Crédito ou escolha outra forma de pagamento.");

                                else
                                    // [SUCESSO] 
                                    return Ok(resposta.Objeto.id_documento);

                            }
                            else
                            {
                                //deu erro
                                foreach (KeyValuePair<string, string[]> kvp in respostaindicacao.erros)
                                {
                                    if (kvp.Value.Length > 0)
                                        ModelState.AddModelError(kvp.Key, kvp.Value[0]);
                                }
                            }
                        }

                        #endregion

                    }
                    else
                    {
                        var msgs = string.Empty;
                        // [ERRO] Erros ao inserir a proposta
                        foreach (KeyValuePair<string, string[]> kvp in resposta.erros)
                        {
                            if (kvp.Value.Length > 0)
                            {
                                ModelState.AddModelError(kvp.Key, kvp.Value[0]);
                                msgs = msgs + " " + kvp.Value[0] + "; ";
                            }
                        }
                        // ** [RETORNO] Pagina de msg para o cliente
                        //  EnviaEmailConfirmacaoErro(resposta.Objeto, msgs);

                    }


                }


            }


            return BadRequest(ModelState);
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
}
