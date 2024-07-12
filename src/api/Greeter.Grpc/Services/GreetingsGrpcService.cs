using Greeter.Domain.Interfaces.Repositories.Greetings;
using Grpc.Core;

namespace Greeter.Grpc.Services
{
    public class GreetingsGrpcService : Greeter.GreeterBase, IGreetingsGrpcService
    {
        private readonly IGreetingsRepository _greetingsRepository;

        public GreetingsGrpcService(IGreetingsRepository greetingsRepository)
        {
            _greetingsRepository = greetingsRepository;
        }

        // Quando for feita uma requisi��o via bloomRPC, o c�digo ir� rodar essa fun��o, chamando a SayHelloAsync sem par�metros
        public override async Task<HelloReply> SayHelloAsync(Empty request, ServerCallContext context)
        {
            return await SayHelloAsync();
        }

        // Quando for feita uma requisi��o via web, o c�digo ir� rodar essa fun��o diretamente, sem precisar dos par�metros request e context
        public async Task<HelloReply> SayHelloAsync()
        {
            await Task.Delay(1000);

            var message = await _greetingsRepository.FindGreetingsMessageAsync();
            message = $"{message} | This message was proccessed by the gRPC service layer!";

            return new HelloReply()
            {
                Message = message
            };
        }
    }
}