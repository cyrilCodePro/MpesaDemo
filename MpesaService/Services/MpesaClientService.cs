using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MpesaService.Services
{
    public class MpesaClientService : IMpesaClientService
    {
        private readonly IHttpClientFactory _clientFactory;


        public MpesaClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<M> PostAsync<M>(string requestpath, HttpMethod method, string token, object payload = null)
        {
            try
            {

                var request = new HttpRequestMessage(method, requestpath);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("ContentType", "application/json");

                if (token != null)
                {
                    request.Headers.Add("Authorization", token);

                }
                if (payload != null)
                {
                    request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                }
                var client = _clientFactory.CreateClient("Mpesa");
                var response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<M>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
