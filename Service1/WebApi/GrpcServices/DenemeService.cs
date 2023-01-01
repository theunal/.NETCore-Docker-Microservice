using DenemeService.Deneme.Proto;
using Grpc.Core;

namespace WebApi.GrpcServices
{
    public class DenemeService : Deneme.DenemeBase
    {
        public async override Task<GetDenemeResponse> GetDeneme(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            return await Task.FromResult(new GetDenemeResponse
            {
                Data = "deneme data. service 1"
            });
        }
    }
}
