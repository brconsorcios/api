using Newtonsoft.Json;

namespace exp.dados.Servicos.RdStation
{
    public class LeadIndicacao : Lead
    {
        public LeadIndicacao(string tokenRdStation, string identificador, string email) : base(tokenRdStation,
            identificador, email)
        {
        }

        [JsonProperty("CPF")] public string Cpf { get; set; }

        [JsonProperty("Mensagem")] public string Mensagem { get; set; }
    }
}