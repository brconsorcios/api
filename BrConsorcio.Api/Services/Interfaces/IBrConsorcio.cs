using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services
{
    public interface IBrConsorcio
    {
        Task<List<Plano>> Simulacao(SimulacaoModel simulacao);

        Task<BuscaCepModel> BuscaCep(string cep);
        
        Task<ClienteModel> BuscaCliente(string cpf);
        Task<ClienteModel> BuscaClienteId(int id);

        Task<HttpResposta<Indicaco>> Indicacao(Indicaco indicacao);

        Task<Bem> BuscarBem(int idbem, short pzComercializacao, int idPlanoVenda, int idTaxaPlano);

        Task<HttpResposta<ClienteModel>> CadastrarCliente(ClienteModel cliente);

        Task<ClienteConfirmarModel> ConfirmarCliente(string cpfcnpj, string tipo, DateTime? dtNascimento = null);

        Task<HttpResposta<ClienteModel>> BuscarCliente(ClienteModel cliente);
        Task<HttpResposta<IndicacaoPgtoDeposito>> InformarDadosBancarios(IndicacaoPgtoDeposito Deposito);
        Task<HttpResposta<Indicaco>> SalvarCartaoPagConsorcio(IndicacaoPgtoCartaoModel Cartao, string pagConsorciokey);

        Task<HttpResposta<Indicaco>> SalvarPropostaDaCompra(int id);

        Task<Indicaco> ObterIndicacao(int id);

        Task<IEnumerable<Assembleia>> ObterAssembleias();

        Task<HttpResposta<string>> EmitirBoleto(int idIndicacao);
        Task<HttpResposta<Indicaco>> MudarStatusDePagamentoBB(Indicaco indicacao);

        Task<string> ObterContrato(int id);

        Task<string> ObterBoleto(int id);

        Task<HttpResposta<string>> EmitirBoletoSegundaVia(string grupo, string cota, string identificador);



    }
}
