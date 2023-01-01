using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGrpcHelper grpcHelper;
        public ValuesController(IGrpcHelper grpcHelper)
        {
            this.grpcHelper = grpcHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await grpcHelper.GetDenemeClient()
                .GetDenemeAsync(new Google.Protobuf.WellKnownTypes.Empty { });
            return Ok(response);
        }
    }
}
