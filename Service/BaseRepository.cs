using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseRepository
    {
        private HttpClient httpClient = new HttpClient();
        //Change this line if you want to reference to another URL for VideoApp.Services
        // private const string BaseUri = "http://videofeeds.azurewebsites.net/api/"; //this needs to be changed to the URI of your Service URL
        private const string BaseUri = "http://localhost:59916/api/";
        public static string FullUrl(UriString parameters, string MethodName, string ControllerName)
        {
            List<string> returnParams = new List<string>();
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> param in parameters._Params)
                {
                    returnParams.Add(String.Format("{0}={1}", param.Key, param.Value));
                }
                var data = "?" + String.Join("&", returnParams.ToArray());
                return BaseUri + ControllerName + "/" + MethodName + data;
            }
            else
                return BaseUri + ControllerName + "/" + MethodName;

        }
        public static string FullDeleteUrl(string parameter, string MethodName, string ControllerName)
        {
            return BaseUri + ControllerName + "/" + MethodName + "/" + parameter;
        }
        public static string FullModifyUrl(string MethodName, string ControllerName)
        {
            return BaseUri + ControllerName + "/" + MethodName;
        }

        public BaseRepository()
        {
            HttpClientHandler handle = new HttpClientHandler();
            httpClient = new HttpClient(handle);
            httpClient.BaseAddress = new Uri(BaseUri);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36");
        }

        #region GetAsync
        protected async Task<T> GetAsync<T>([CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            return await GetAsync<T>(null, MethodName, ControllerName);
        }

        protected async Task<T> GetAsync<T>(UriString parameters, [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var result = await this.httpClient.GetAsync(FullUrl(parameters, MethodName, ControllerName));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }
        }

        protected async Task<HttpResponseMessage> GetAsync([CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            return await GetAsync(null, MethodName, ControllerName);

        }

        protected async Task<HttpResponseMessage> GetAsync(UriString parameters, [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var fullUrl = BaseUri + ControllerName + MethodName + parameters.ToString();
            var result = await this.httpClient.GetAsync(FullUrl(parameters, MethodName, ControllerName));
            return result;

        }

        #endregion

        #region PostAsync
        protected async Task<ResponseType> PostAsync<RequestType, ResponseType>(RequestType BodyParameters = default(RequestType), [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            return await PostAsync<RequestType, ResponseType>(null, BodyParameters, MethodName, ControllerName);
        }
        protected async Task<ResponseType> PostAsync<RequestType, ResponseType>(UriString UriParameters, RequestType BodyParameters = default(RequestType), [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(BodyParameters);
            var result = await this.httpClient.PostAsync(FullUrl(UriParameters, MethodName, ControllerName), new StringContent(json, Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseType>(await result.Content.ReadAsStringAsync());

            }
            else
            {
                return default(ResponseType);
            }
        }

        #endregion

        #region DeleteAsync
        protected async Task<ResponseType> DeleteAsync<ResponseType>([CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            return await DeleteAsync<ResponseType>(null, MethodName, ControllerName);

        }
        protected async Task<ResponseType> DeleteAsync<ResponseType>(string Parameter, [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var result = await this.httpClient.DeleteAsync(FullDeleteUrl(Parameter, MethodName, ControllerName));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseType>(await result.Content.ReadAsStringAsync());

            }
            else
            {
                return default(ResponseType);
            }
        }

        #endregion

        #region PutAsync

        protected async Task<ResponseType> PutAsync<RequestType, ResponseType>(RequestType BodyParameters = default(RequestType), [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(BodyParameters);
            var result = await this.httpClient.PutAsync(FullModifyUrl(MethodName, ControllerName), new StringContent(json, Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseType>(await result.Content.ReadAsStringAsync());

            }
            else
            {
                return default(ResponseType);
            }
        }
        #endregion

    }
    public class UriString
    {
        public Dictionary<string, string> _Params = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _Params.Add(key, value);
        }
    }


}
