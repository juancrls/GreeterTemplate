using Greeter.Grpc;
using Microsoft.AspNetCore.Mvc;

namespace Greeter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsGrpcController : ControllerBase
    {
        private readonly IGreetingsGrpcService _greetingsGrpcService;

        public GreetingsGrpcController(IGreetingsGrpcService greetingsGrpcService)
        {
            _greetingsGrpcService = greetingsGrpcService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(HelloReply))]
        public async Task<HelloReply> Get()
        {
            return await _greetingsGrpcService.SayHelloAsync();
        }
    }
}