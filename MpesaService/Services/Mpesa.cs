using Microsoft.Extensions.Options;
using MpesaService.ServiceModels;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MpesaService.Services
{
    internal class Mpesa : IMpesa
    {
        private readonly IMpesaClientService _mpesaClient;
        private readonly Credentials _credentials;


        public Mpesa(IMpesaClientService mpesaClient, IOptions<Credentials> credentials)
        {
            _mpesaClient = mpesaClient;
            _credentials = credentials.Value;
        }
        public string GenerateBase64(string input)
        {
            ReadOnlySpan<byte> bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
        public string Totime()
        {
            return DateTime.UtcNow.AddHours(3).ToString("yyyyMMddHHmmss");
        }

        public Task<AuthToken> GetToken()
        {
            return _mpesaClient.PostAsync<AuthToken>("https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials", HttpMethod.Get, string.Format("Basic {0}", GenerateBase64(string.Format("{0}:{1}", _credentials.ConsumerKey, _credentials.ConsumerSecret))));
        }
        public async Task<LipaNaMpesaResponse> InitiateStkPush(LipaNaMpesaModelPost lipaNaMpesaModel)
        {
            var token = await GetToken();
            if (token == null)
            {
                return null;
            }
            return await _mpesaClient.PostAsync<LipaNaMpesaResponse>("https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest", HttpMethod.Post, string.Format("Bearer {0}", token.access_token), lipaNaMpesaModel);
        }
        public async Task<RegisterUrlResponse> RegisterUrl(RegisterUrl register)
        {
            var token = await GetToken();
            if (token == null)
                return null;
            return await _mpesaClient.PostAsync<RegisterUrlResponse>("https://sandbox.safaricom.co.ke/mpesa/c2b/v1/registerurl", HttpMethod.Post, string.Format("Bearer {0}", token.access_token), register);
        }
        public async Task<B2CModelResponse> B2C(B2CModel model)
        {

            var token = await GetToken();
            if (token == null)
                return null;
            return await _mpesaClient.PostAsync<B2CModelResponse>("https://sandbox.safaricom.co.ke/mpesa/b2c/v1/paymentrequest", HttpMethod.Post, string.Format("Bearer {0}", token.access_token), model);
        }

    }
}
