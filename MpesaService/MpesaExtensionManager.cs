using Microsoft.Extensions.DependencyInjection;
using MpesaService.Services;

namespace MpesaService
{
    public static class MpesaExtensionManager
    {
        public static IServiceCollection AddMpesaService(this IServiceCollection services)
        {
            services.AddHttpClient("Mpesa", c =>
             {

             });
            //}).ConfigurePrimaryHttpMessageHandler(h =>
            //{

            //    var handler = new HttpClientHandler
            //    {
            //        AllowAutoRedirect = false,
            //        ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true,
            //        SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12|SslProtocols.Tls13,


            //    };
            //    return handler;
            //});

            services.AddTransient<IMpesaClientService, MpesaClientService>();
            services.AddTransient<IMpesa, Mpesa>();
            return services;
        }
    }
}
