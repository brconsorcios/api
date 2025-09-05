using BrConsorcio.Api.Models;
using BrConsorcio.Api.Models.AnaliseCredito;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public class SelectHelper
    {

        public static SelectList SelectUf(string selected)
        {

            if (string.IsNullOrEmpty(selected))
            {
                selected = "";
            }

            var collection = new Dictionary<string, string>();
            collection.Add("", "Selecione");
            collection.Add("AM", "Amazônas");
            collection.Add("AC", "Acre");
            collection.Add("AL", "Alagoas");
            collection.Add("AP", "Amapá");
            collection.Add("BA", "Bahia");
            collection.Add("CE", "Ceará");
            collection.Add("DF", "Distrito Federal");
            collection.Add("ES", "Espírito Santo");
            collection.Add("GO", "Goiás");
            collection.Add("MA", "Maranhão");
            collection.Add("MT", "Mato Grosso");
            collection.Add("MS", "Mato Grosso do Sul");
            collection.Add("MG", "Minas Gerais");
            collection.Add("PA", "Pará");
            collection.Add("PB", "Paraíba");
            collection.Add("PR", "Paraná");
            collection.Add("PE", "Pernambuco");
            collection.Add("PI", "Piauí");
            collection.Add("RJ", "Rio de Janeiro");
            collection.Add("RN", "Rio Grande do Norte");
            collection.Add("RS", "Rio Grande do Sul");
            collection.Add("RO", "Rondônia");
            collection.Add("RR", "Roraima");
            collection.Add("SC", "Santa Catarina");
            collection.Add("SP", "São Paulo");
            collection.Add("SE", "Sergipe");
            collection.Add("TO", "Tocantins");

            return new SelectList(collection, "Key", "Value", selected.GetHashCode());
        }

        public async Task<SelectList> SelectCidade(string UF, string selected)
        {
            Exp_WebAPI _exp_webapi = new Exp_WebAPI();

            if (string.IsNullOrEmpty(selected))
            {
                selected = "";
            }

            var collection = new Dictionary<string, string>();
            collection.Add("", "Selecione");

            string UrlApi = _exp_webapi.WebBrApi;
            var http = new HttpHelpers(UrlApi, "", "");
            var dados = await http.Get<Dictionary<string, string>>("GetCidades?uf=" + UF, false);

            foreach (var registro in dados)
            {
                collection.Add(registro.Key.ToUpper(), registro.Value);
            }

            return new SelectList(collection, "Key", "Value", selected.GetHashCode());
        }
        
        public static SelectList SelectGruposProfissionais(string profissao, string selected, string _exp_webapi)
        {

            //Exp_WebAPI _exp_webapi = new Exp_WebAPI();
            if (string.IsNullOrEmpty(selected))
            {
                selected = "";
            }

            var collection = new Dictionary<string, string>();
            collection.Add("", "Selecione");

            string UrlApi = _exp_webapi;
            var http = new HttpHelpers(UrlApi, "", "");
            var dados = http.Get<Dictionary<string, string>>("GetGrupoProfissoes?profissao=" + profissao, false);

            foreach (var registro in dados.Result)
            {
                collection.Add(registro.Key, registro.Value);
            }

            return new SelectList(collection, "Key", "Value", selected.GetHashCode());
        }
    }
}
