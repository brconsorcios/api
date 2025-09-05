using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public class HttpResposta<T>
    {

        public T Objeto { get; set; }
        public Dictionary<string, string[]> erros { get; set; }
    }

    public class HttpHelpers
    {
        string _address;
        string _addlogin;
        string _addPass;

        public HttpHelpers(string address, string addlogin, string addPass)
        {
            _address = address;
            _addlogin = addlogin;
            _addPass = addPass;
        }

        public async Task<T> Get<T>(string uri, bool v) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //if (Aut.Value)
                    //{
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_addlogin}:{_addPass}")));
                    client.DefaultRequestHeaders.Authorization = authValue;
                    //}

                    //---------------
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);
                    Log.Information("{p} {e}-> {m}", "HttpHelpers".PadRight(30), "Get".PadRight(30), $"chamando a uri: {uri}");

                    var response = await client.GetAsync(uri);
                    Log.Information("{p} {e}-> {m}", "HttpHelpers".PadRight(30), "Get".PadRight(30), $"retorno da uri: {uri} : {response}");


                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                    {


                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                    }




                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Log.Error("{p} {e}-> {m}", "HttpHelpers".PadRight(30), "Get".PadRight(30), $"retorno da uri: {uri} Exception: {ex.StackTrace}");

                throw ex;
            }
        }
        public async Task<string> Post<T, TOut>(string uri, T content, AuthenticationHeaderValue authenticationHeaderValue) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(120);

                    client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);

                    var serializedItem = JsonConvert.SerializeObject(content);
                    var result =  await client.PostAsync(uri, new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                    return result.Content.ReadAsStringAsync().Result;
                 }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
        public async Task<string> Post<T, TOut>(string uri, T content, string authorization) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(120);

                    var authValue = new AuthenticationHeaderValue(authorization);

                    client.DefaultRequestHeaders.Authorization = authValue;
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);

                    var serializedItem = JsonConvert.SerializeObject(content);
                    var result = await client.PostAsync(uri, new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                    return result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<TOut> Post<T, TOut>(string uri, T content) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.Timeout = TimeSpan.FromSeconds(120);

                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes($"{_addlogin}:{_addPass}")));
                    client.DefaultRequestHeaders.Authorization = authValue;
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);

                    var serializedItem = JsonConvert.SerializeObject(content);
                    Log.Information("{p} {e}-> {m}", "httphelpers".PadRight(30), "Post".PadRight(30), $"Início do endpoint (baseadress: {client.BaseAddress} , uri: {uri} , content: {serializedItem} ");

                    var response = await client.PostAsync(uri, new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                    Log.Information("{p} {e}-> {m}", "httphelpers".PadRight(30), "Post".PadRight(30), $"response {JsonConvert.SerializeObject(response)}");



                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                    {

                        return JsonConvert.DeserializeObject<TOut>(response.Content.ReadAsStringAsync().Result);
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {

                        return JsonConvert.DeserializeObject<TOut>(response.Content.ReadAsStringAsync().Result);
                    }

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default(TOut);
                    }

                    response.EnsureSuccessStatusCode();
                    return default(TOut);

                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<TOut> Put<T, TOut>(string uri, T content) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_addlogin}:{_addPass}")));
                    client.DefaultRequestHeaders.Authorization = authValue;
                    client.BaseAddress = new Uri(_address);

                    var myContent = JsonConvert.SerializeObject(content);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await client.PutAsync(uri, byteContent);
                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return JsonConvert.DeserializeObject<TOut>(response.Content.ReadAsStringAsync().Result);

                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return JsonConvert.DeserializeObject<TOut>(response.Content.ReadAsStringAsync().Result);
                    }
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default(TOut);
                    }

                    // response.EnsureSuccessStatusCode();

                    return default(TOut);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<TOut> Put<T, TOut>(string uri, T content, bool v) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_addlogin}:{_addPass}")));
                    client.DefaultRequestHeaders.Authorization = authValue;
                    client.BaseAddress = new Uri(_address);

                    var myContent = JsonConvert.SerializeObject(content);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await client.PutAsync(uri, byteContent);
                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return JsonConvert.DeserializeObject<TOut>(response.Content.ReadAsStringAsync().Result);

                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return JsonConvert.DeserializeObject<TOut>(response.Content.ReadAsStringAsync().Result);
                    }
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default(TOut);
                    }

                    // response.EnsureSuccessStatusCode();

                    return default(TOut);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }


        //public bool Del(string uri, bool? Aut = false)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {

        //            if (Aut.Value)
        //            {
        //                string authInfo = _addlogin + ":" + _addPass;
        //                authInfo = Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo));
        //                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
        //            }
        //            //---------------
        //            client.DefaultRequestHeaders.ExpectContinue = false;
        //            client.BaseAddress = new Uri(_address);
        //            HttpResponseMessage response = client.DeleteAsync(uri).Result;
        //            if (response.StatusCode == HttpStatusCode.NotFound)
        //            {
        //                return false;//null
        //            }

        //            response.EnsureSuccessStatusCode();

        //            //return response.Content.ReadAsAsync<T>().Result;
        //            return true;
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// EXEMPLOS  
        /// </summary>

        //var http = new HttpHelpers("www.seusite.com");
        //http.Get<IEnumerable<Empresa>>("/api/getempresas");

        //var http = new HttpHelpers("www.seusite.com");
        //http.Get<Empresa>("/api/getempresa/5");

        //var request = new Request();
        //request.Nome = "teste";
        //var empresa = http.Post<Empresa, Request>("/api/postempresa", request);

    }
}
