using MoviesFind.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesFind.Services.Common
{
    public abstract class HttpBaseService
    {
        private readonly JsonSerializer _serializer;

        protected HttpBaseService()
        {
            _serializer = new JsonSerializer();
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
            return httpClient;
        }

        private void CheckInternetConnection()
        {
            //if (CrossConnectivity.IsSupported && !CrossConnectivity.Current.IsConnected)
            //{
            //    throw new NoInternetConnectionException();
            //}
        }

        private string PairsParamsFromDictionary(Dictionary<string, string> data)
        {
            var pairs = data
                .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}")
                .OrderBy(s => s);
            return String.Join("&", pairs);
        }

        private async Task<HttpResponse<T>> HandleResponse<T>(HttpResponseMessage response) where T : new()
        {
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var data = _serializer.Deserialize<T>(json);
                    return new HttpResponse<T>
                    {
                        IsSuccessful = true,
                        Data = data
                    };
                }
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            var errorContent = await response.Content.ReadAsStringAsync();

            return new HttpResponse<T>
            {
                IsSuccessful = false,
                ErrorMessage = $"{response.ReasonPhrase}, {errorContent}"
            };
        }

        protected async Task<HttpResponse<T>> GetAsync<T>(Uri url, Dictionary<string, string> parameters = null)
            where T : new()
        {
            using (var httpClient = CreateHttpClient())
            {
                try
                {
                    CheckInternetConnection();

                    parameters?.Add("appid", ConstantHelper.ApiKey);
                    parameters?.Add("units", "metric");

                    var uri = parameters != null
                        ? new Uri($"{url.AbsoluteUri}?{PairsParamsFromDictionary(parameters)}")
                        : url;

                    var result = await httpClient.GetAsync(uri);

                    return await HandleResponse<T>(result);
                }
                catch (Exception ex)
                {
                    return new HttpResponse<T>()
                    {
                        IsSuccessful = false,
                        ErrorMessage = ex.Message
                    };
                }
            }
        }
    }
}
