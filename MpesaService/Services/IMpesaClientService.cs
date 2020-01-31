using System.Net.Http;
using System.Threading.Tasks;

namespace MpesaService.Services
{
    public interface IMpesaClientService
    {
        Task<M> PostAsync<M>(string requestpath, HttpMethod method, string token, object payload = null);
    }
}