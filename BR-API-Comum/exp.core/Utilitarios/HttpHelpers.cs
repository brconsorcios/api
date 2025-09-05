using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace exp.core.Utilitarios
{
    public class HttpHelpers
    {
        private readonly string _addlogin;
        private readonly string _addPass;
        private readonly string _address;

        public HttpHelpers(string address, string addlogin, string addPass)
        {
            _address = address;
            _addlogin = addlogin;
            _addPass = addPass;
        }

        public T Get<T>(string uri, bool? Aut = false) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (Aut.Value)
                    {
                        var authInfo = _addlogin + ":" + _addPass;
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                    }

                    //---------------
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);


                    var response = client.GetAsync(uri).Result;

                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                        return response.Content.ReadAsAsync<T>().Result;
                    // return response.Content.ReadAsStringAsync<T>().Result;
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                        return response.Content.ReadAsAsync<T>().Result;

                    if (response.StatusCode == HttpStatusCode.NotFound) return null;

                    // response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }


        public TOut Post<T, TOut>(string uri, T content, bool? Aut = false) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(120);
                    //http://forums.xamarin.com/discussion/5941/system-net-http-httpclient-timeout-seems-to-be-ignored

                    if (Aut.Value)
                    {
                        var authInfo = _addlogin + ":" + _addPass;
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                    }

                    //---------------
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);

                    var response = client.PostAsJsonAsync(uri, content).Result;

                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                        return response.Content.ReadAsAsync<TOut>().Result;

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                        return response.Content.ReadAsAsync<TOut>().Result;

                    if (response.StatusCode == HttpStatusCode.NotFound) return default;

                    response.EnsureSuccessStatusCode();
                    return default;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }


        public TOut Put<T, TOut>(string uri, T content, bool? Aut = false) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (Aut.Value)
                    {
                        var authInfo = _addlogin + ":" + _addPass;
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                    }

                    //---------------
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);
                    var response = client.PutAsJsonAsync(uri, content).Result;
                    if (response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.NoContent)
                        return response.Content.ReadAsAsync<TOut>().Result;
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                        return response.Content.ReadAsAsync<TOut>().Result;
                    if (response.StatusCode == HttpStatusCode.NotFound) return default;

                    // response.EnsureSuccessStatusCode();

                    return default;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }


        public bool Del(string uri, bool? Aut = false)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (Aut.Value)
                    {
                        var authInfo = _addlogin + ":" + _addPass;
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                    }

                    //---------------
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.BaseAddress = new Uri(_address);
                    var response = client.DeleteAsync(uri).Result;
                    if (response.StatusCode == HttpStatusCode.NotFound) return false; //null

                    response.EnsureSuccessStatusCode();

                    //return response.Content.ReadAsAsync<T>().Result;
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

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