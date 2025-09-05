using System;
using System.Net;
using System.Net.Http;

namespace exp.dados.Servicos.RdStation
{
    public class RdStationApiClient
    {
        public const string BASE_ADDRESS = @"https://www.rdstation.com.br/api/";
        public const string CONVERSION_URL = BASE_ADDRESS + "1.3/conversions";
        private readonly HttpClient _httpClient;

        public RdStationApiClient(HttpClient client = default)
        {
            _httpClient = client ?? new HttpClient { BaseAddress = new Uri(BASE_ADDRESS) };
        }

        public bool EnviarLead(Lead lead)
        {
            var response = _httpClient.PostAsJsonAsync(CONVERSION_URL, lead).Result;
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }
    }
}