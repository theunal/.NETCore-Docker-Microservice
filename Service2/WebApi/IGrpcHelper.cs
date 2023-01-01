using DenemeService.Deneme.Proto;
using Grpc.Net.Client;

namespace WebApi
{
    public interface IGrpcHelper
    {
        Deneme.DenemeClient GetDenemeClient();
    }

    public class GrpcHelper : IGrpcHelper
    {
        public IConfiguration Configuration { get; }

        GrpcChannel denemeChannel;
        public GrpcHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            bool isDockerActive = bool.Parse(configuration["IsDockerActive"]!);

            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            denemeChannel = GrpcChannel.ForAddress(isDockerActive is true ?
                Configuration["ServiceUrls:DockerService1Url"]! : Configuration["ServiceUrls:Service1Url"]!, 
                new GrpcChannelOptions { HttpHandler = httpHandler });
        }

        public Deneme.DenemeClient GetDenemeClient() => new(denemeChannel);
    }
}