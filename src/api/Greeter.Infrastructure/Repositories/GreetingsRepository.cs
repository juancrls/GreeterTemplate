using Greeter.Domain.Interfaces.Repositories.Greetings;

namespace Greeter.Infrastructure.Repositories
{
    public class GreetingsRepository : IGreetingsRepository
    {
        public async Task<string> FindGreetingsMessageAsync()
        {
            await Task.Delay(1000);

            return "Hello!";
        }
    }
}