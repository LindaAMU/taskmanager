using System.Text;
using System.Text.Json;

namespace TaskManager.Web.Services.HttpServices
{
    public class HttpService : IHttpService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string _url;

        public HttpService(IConfiguration configuration, HttpClient httpClient)
        {
            this._configuration = configuration;
            this._httpClient = httpClient;
            this._url = _configuration["BaseURL"];
        }

        public async Task<T> Get<T>(string uri)
        {
            HttpRequestMessage request = new(HttpMethod.Get, this._url + uri);
            try
            {
                return await SendRequest<T>(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            HttpRequestMessage request = new(HttpMethod.Post, this._url + uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            try
            {
                return await SendRequest<T>(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Patch<T>(string uri, object value)
        {
            HttpRequestMessage request = new(HttpMethod.Patch, this._url + uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            try
            {
                return await SendRequest<T>(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Delete<T>(string uri)
        {
            HttpRequestMessage request = new(HttpMethod.Delete, this._url + uri);
            try
            {
                return await SendRequest<T>(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            /* Se envía la consulta a la API */
            using HttpResponseMessage response = await this._httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                //TODO - Gestionar Errores
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
