using BoletoAvulsoService;
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services
{
    public class BoletoAvulso : IBoletoAvulso

    {
        private readonly Provider _provider;
        private readonly BoletoAvulsoServiceClient _BoletoAvulsoServiceClient;
        public BoletoAvulso(IOptions<Provider> Providerr)
        {
            _provider = Providerr.Value;
            //BasicHttpsBinding basicAuthBinding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
            //basicAuthBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            // Use double the default value
            //basicAuthBinding.MaxReceivedMessageSize = 65536 * 4;

            // EndpointAddress basicAuthEndpoint = new EndpointAddress(_provider.Ws_BoletoAvulso);
            // _BoletoAvulsoServiceClient = new BoletoAvulsoServiceClient(basicAuthBinding, basicAuthEndpoint);
            _BoletoAvulsoServiceClient = new BoletoAvulsoServiceClient();
            _BoletoAvulsoServiceClient.Endpoint.Address = new EndpointAddress(_provider.Ws_BoletoAvulso);
        }

        public Task<RetornoConsultarParcelas> ConsultarParcelas(string grupo, int cota, string cpfCnpj)
        {
            try
            {
                EntradaConsultarParcelas entradaConsultarParcelas = new EntradaConsultarParcelas();
                entradaConsultarParcelas.codigoGrupo = grupo;
                entradaConsultarParcelas.codigoCota = cota;
                entradaConsultarParcelas.cpfCnpj = cpfCnpj;
                entradaConsultarParcelas.dataBase = DateTime.Now;
                entradaConsultarParcelas.dataCompensacao = DateTime.Now;
                entradaConsultarParcelas.idUsuario = 60280;
                entradaConsultarParcelas.snUnificarParcelas = "N";
                
                
                var retorno = _BoletoAvulsoServiceClient.ConsultarParcelasAsync(entradaConsultarParcelas);
                return retorno;

            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public void Close()
        {
            _BoletoAvulsoServiceClient.CloseAsync();
        }
        
    }
}
