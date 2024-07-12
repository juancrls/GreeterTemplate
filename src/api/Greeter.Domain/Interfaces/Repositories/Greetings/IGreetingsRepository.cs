namespace Greeter.Domain.Interfaces.Repositories.Greetings
{
    public interface IGreetingsRepository
    {
        // Utilize sempre o prefixo Find para métodos que vão até o banco de dados

        /// <summary>
        /// Busca uma string no banco de dados
        /// </summary>
        /// <returns>string com mensagem de saudação</returns>
        public Task<string> FindGreetingsMessageAsync();
    }
}