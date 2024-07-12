using Greeter.Domain.Interfaces.Repositories.Greetings;
using Greeter.Domain.Interfaces.Services.Greetings;

namespace Greeter.Application.Services
{
    public class GreetingsService : IGreetingsService
    {
        private readonly IGreetingsRepository _greetingsRepository;

        public GreetingsService(IGreetingsRepository greetingsRepository)
        {
            _greetingsRepository = greetingsRepository;
        }

        public async Task<string> GetGreetingsMessageAsync()
        {
            var message = await _greetingsRepository.FindGreetingsMessageAsync();
            message = $"{message} | This message was proccessed by the service layer!";

            return message;
        }
    }
}