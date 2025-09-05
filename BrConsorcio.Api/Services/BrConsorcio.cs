using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace BrConsorcio.Api.Services
{
    public class BrConsorcio : IBrConsorcio
    {
        #region Variaveis
        private HttpHelpers http;

        private readonly BrConsorcioConfig _brConsorcioConfig;


        #endregion

        #region Construtor
        public BrConsorcio(IOptions<BrConsorcioConfig> brConsorcioConfig)
        {
            _brConsorcioConfig = brConsorcioConfig.Value;
            http = new HttpHelpers(_brConsorcioConfig.Url, _brConsorcioConfig.Usuario, _brConsorcioConfig.Senha);
        }
        #endregion
        
        #region Métodos
        public async Task<BuscaCepModel> BuscaCep(string cep)
        {
            return await http.Get<BuscaCepModel>($"{_brConsorcioConfig.ApiPasta}BuscaCep/?cep={cep}", true);
        }

        public async Task<ClienteModel> BuscaCliente(string cpfcnpj)
        {
            return await http.Get<ClienteModel>($"{_brConsorcioConfig.ApiPasta}pessoa/{cpfcnpj}", true);
        }
        public async Task<ClienteModel> BuscaClienteId(int id)
        {
            return await http.Get<ClienteModel>($"{_brConsorcioConfig.ApiPasta}cliente/{id}", true);
        }
        public async Task<ClienteConfirmarModel> ConfirmarCliente(string cpfcnpj, string tipo, DateTime? dtNascimento = null)
        {
            return await http.Get<ClienteConfirmarModel>($"{_brConsorcioConfig.ApiPasta}ClienteConfirmar/?cpfcnpj={cpfcnpj}&tipo={tipo}&dt={dtNascimento}", true);
        }

        //public async Task<string> ObterProposta(int id)
        //{
        //    return await http.Get<string>($"{_brConsorcioConfig.ApiPasta}EmitirPropostadaCompra/?id={id}");
        //}
        public async Task<string> ObterContrato(int id)
        {
            var result = await http.Post<string, HttpResposta<string>>($"{_brConsorcioConfig.ApiPasta}EmitirContratodaCompra/?id={id}", null);
            if (result.erros is null)
                return result.Objeto;
            else
                return string.Empty;
        }

        public async Task<string> ObterBoleto(int id)
        {
            var result = await http.Post<string, HttpResposta<string>>($"{_brConsorcioConfig.ApiPasta}EmitirBoletodaCompra/?id={id}", null);
            if (result.erros is null)
                return result.Objeto;
            else
                return string.Empty;
        }

        public async Task<List<Plano>> Simulacao(SimulacaoModel simulacao)
        {
            int paginaatual = 1;
            List<Plano> bens = new List<Plano>();
            var model = new PaginacaoApi<Plano>();

            var firstloop = true;
            while (model.HasNextPage || firstloop)
            {
                firstloop = false;
                model = await http.Get<PaginacaoApi<Plano>>($"{_brConsorcioConfig.ApiPasta}benssimulacao/?id={simulacao.TipoConsorcio}&tipo={simulacao.TipoSimulacao}&vmin={simulacao.ValorMin}&vmax={simulacao.ValorMax}&pagina={paginaatual++}", true);
                bens.AddRange(model.objeto);
            }

            return bens;
        }

        public async Task<HttpResposta<Indicaco>> Indicacao(Indicaco indicacao)
        {
            Log.Information("{p} {e}-> {m}", "BrConsorcio".PadRight(30), "Indicacao".PadRight(30), $"Início");
            // 0: "Cliente não finalizou";
            // 1: "Quero Comprar pela Internet";
            // 2: "Quero Receber uma visita";
            // 3: "Quero Receber uma ligação";
            // 4: "Quero Receber um E-mail";
            // 5: "Fale Conosco";
            // 6: "Ligamos para você";
            // 7: "Email ou Telefone - Meu Patrimônio";
            // 8: "Agenda - Meu Patrimônio";
            // 9: "Fale Fácil";
            // 10:"Compra Rápida";
            Log.Information("{p} {e}-> {m}", "BrConsorcio".PadRight(30), "Indicacao".PadRight(30), $"Chamando a url {_brConsorcioConfig.ApiPasta}indicacoes/{indicacao}");
            var resposta = await http.Post<Indicaco, HttpResposta<Indicaco>>($"{_brConsorcioConfig.ApiPasta}indicacoes/", indicacao);
            Log.Information("{p} {e}-> {m}", "BrConsorcio".PadRight(30), "Indicacao".PadRight(30), $"retorno da url {_brConsorcioConfig.ApiPasta}indicacoes/{indicacao} -> {resposta}");

            return resposta;
        }

        public async Task<HttpResposta<string>> EmitirBoleto(int idIndicacao)
        {
            var resposta = await http.Post<string, HttpResposta<string>>($"{_brConsorcioConfig.ApiPasta}EmitirBoletodaCompra/", idIndicacao.ToString());

            return resposta;
        }


        public async Task<Bem> BuscarBem(int idbem, short pzComercializacao, int idPlanoVenda, int idTaxaPlano)
        {
            Log.Information("{p} {e}-> {m}", "BrConsorcio".PadRight(30), "BuscarBem".PadRight(30), $"Início : {_brConsorcioConfig.ApiPasta}bemescolhido/{idbem}-{pzComercializacao}-{idPlanoVenda}-{idTaxaPlano}");
             
            var bem = await http.Get<Bem>($"{_brConsorcioConfig.ApiPasta}bemescolhido/{idbem}-{pzComercializacao}-{idPlanoVenda}-{idTaxaPlano}", true);

            if (bem != null)
                if (bem.id_bem != null)
                    bem.Taxas = await http.Get<BemTaxas>($"{_brConsorcioConfig.ApiPasta}benstaxas/?id_plano_venda={bem.id_plano_venda}&id_taxa_plano={bem.id_taxa_plano}&id_bem={bem.id_bem}&Regiao_Fiscal={bem.id_regiao_fiscal}", true);


            return bem;

        }

        public async Task<HttpResposta<ClienteModel>> CadastrarCliente(ClienteModel cliente)
        {
            string comentario = string.Empty; // Será utilizado no comentário da indicação abaixo.
            try
            {
                //  #region gravando ou atualizando dados do cliente

                var resposta = new HttpResposta<ClienteModel>();
              

                if (cliente.id_pessoa > 0)
                {
                    resposta = await http.Put<ClienteModel, HttpResposta<ClienteModel>>($"{_brConsorcioConfig.ApiPasta}pessoa/?id={cliente.id}", cliente);
                }
                else
                {
                    resposta = await http.Post<ClienteModel, HttpResposta<ClienteModel>>($"{_brConsorcioConfig.ApiPasta}pessoa/", cliente);
                }
            
                return resposta;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<HttpResposta<ClienteModel>> BuscarCliente(ClienteModel cliente)
        {         
            try
            {
                var resposta = new HttpResposta<ClienteModel>();

                resposta = await http.Post<ClienteModel, HttpResposta<ClienteModel>>($"{_brConsorcioConfig.ApiPasta}PessoaCadastradaProvider/", cliente);

                return resposta;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<Indicaco> ObterIndicacao(int id)
        {
            return await http.Get<Indicaco>($"{_brConsorcioConfig.ApiPasta}indicacoes/{id}", true);
        }

        public async Task<HttpResposta<IndicacaoPgtoDeposito>> InformarDadosBancarios(IndicacaoPgtoDeposito Deposito)
        {
            var RespostaDeposito = new HttpResposta<IndicacaoPgtoDeposito>();
            Dictionary<string, string[]> msgerros = new Dictionary<string, string[]>();
            //msgerros.Add("cat", new string[] {"2"});
            //Valida dados da conta bancária
            if (Deposito.exibirconta)
                if (string.IsNullOrEmpty(Deposito.nome_banco) || string.IsNullOrEmpty(Deposito.agencia) || string.IsNullOrEmpty(Deposito.numero_conta))
                    msgerros.Add("check_termo", new string[] { "* Informe os dados bancários corretamente!" });

            var putCliente = await http.Post<IndicacaoPgtoDeposito, HttpResposta<ClienteModel>>($"{_brConsorcioConfig.ApiPasta}depositarnobanco/{Deposito.id}", Deposito);

            if (putCliente != null)
            {
                if (putCliente.erros != null)
                    msgerros.Add("indicacao", new string[] { "Não foi possível realizar a operação no momento" });
            }
            else
            {
                msgerros.Add("indicacao", new string[] { "Não foi possível realizar a operação no momento" });
            }

            RespostaDeposito.Objeto = Deposito;
            RespostaDeposito.erros = msgerros;

            return RespostaDeposito;
        }

        public async Task<HttpResposta<Indicaco>> SalvarCartaoPagConsorcio(IndicacaoPgtoCartaoModel Cartao, string pagConsorciokey)
        {
            return await http.Post<IndicacaoPgtoCartaoModel, HttpResposta<Indicaco>>($"{_brConsorcioConfig.ApiPasta}cartoespagconsorcio/?id={pagConsorciokey}", Cartao);
        }

        public async Task<HttpResposta<Indicaco>> SalvarPropostaDaCompra(int id)
        {
            try
            {
                var indicacao = new Indicaco();
                return await http.Post<Indicaco, HttpResposta<Indicaco>>($"{_brConsorcioConfig.ApiPasta}proposta/{id}", indicacao);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return null;
            }
        }

        public async Task<IEnumerable<Assembleia>> ObterAssembleias()
        {
            return await http.Get<IEnumerable<Assembleia>>($"{_brConsorcioConfig.ApiPasta}assembleias/",true);
        }

        public async Task<HttpResposta<Indicaco>> MudarStatusDePagamentoBB(Indicaco indicacao)
        {
            indicacao.id_forma_recebimento = "BB";
            //0: "NÃO FINALIZADAS";
            //1: "NOVAS";
            indicacao.status = 4; // vendido com boleto bancário
            return await http.Put<Indicaco, HttpResposta<Indicaco>>($"{_brConsorcioConfig.ApiPasta}indicacoes/?id={indicacao.id}", indicacao);
        }

        public async Task<HttpResposta<string>> EmitirBoletoSegundaVia(string grupo, string cota, string identificador)
        {
            Log.Information("{p} {e}-> {m}", "BrConsorcio".PadRight(30), "EmitirBoletoSegundavia".PadRight(30), $"Início do endpoint (grupo: {grupo} , cota: {cota} , Identificador:{identificador}");

            TransitoBoleto transito = new TransitoBoleto();
            transito.cd_grupo = grupo;
            transito.cd_cota = cota;
            transito.id_identificador = identificador;
            Log.Information("{p} {e}-> {m}", "BrConsorcio".PadRight(30), "EmitirBoletoSegundavia".PadRight(30), $"chamando url {_brConsorcioConfig.ApiPasta} EmitirBoletoSegundaVia/");

            var result = await http.Post<TransitoBoleto, HttpResposta<string>>($"{_brConsorcioConfig.ApiPasta}EmitirBoletoSegundaVia/", transito);
            return result;
        }
        #endregion
    }
}
