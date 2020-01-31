using MpesaService.ServiceModels;
using System.Threading.Tasks;

namespace MpesaService.Services
{
    public interface IMpesa
    {
        Task<B2CModelResponse> B2C(B2CModel model);
        string GenerateBase64(string input);
        Task<AuthToken> GetToken();
        Task<LipaNaMpesaResponse> InitiateStkPush(LipaNaMpesaModelPost lipaNaMpesaModel);
        Task<RegisterUrlResponse> RegisterUrl(RegisterUrl register);
        string Totime();
    }
}