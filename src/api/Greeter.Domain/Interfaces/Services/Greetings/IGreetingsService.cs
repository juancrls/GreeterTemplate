namespace Greeter.Domain.Interfaces.Services.Greetings
{
    public interface IGreetingsService
    {
        // Utilize sempre o prefixo Get para métodos que são do tipo GET

        /// <summary>
        /// Aplica regras de negócio aos dados que vem do banco
        /// </summary>
        /// <returns>string com mensagem de saudação formatada</returns>
        public Task<string> GetGreetingsMessageAsync();
    }
}