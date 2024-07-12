using Greeter.Domain.Interfaces.Services.Greetings;
using Microsoft.AspNetCore.Mvc;

namespace Greeter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : ControllerBase
    {
        private readonly ILogger<GreetingsController> _logger;
        private readonly IGreetingsService _greetingsService;

        public GreetingsController(ILogger<GreetingsController> logger, IGreetingsService greetingsService)
        {
            _logger = logger;
            _greetingsService = greetingsService;
        }

        [HttpGet(Name = "rest")]
        [ProducesResponseType(200, Type = typeof(string))]
        public Task<string> Get()
        {
            return _greetingsService.GetGreetingsMessageAsync();
        }
    }
}