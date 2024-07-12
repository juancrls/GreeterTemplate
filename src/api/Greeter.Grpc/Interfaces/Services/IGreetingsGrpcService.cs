using Greeter.Grpc;
using Grpc.Core;

public interface IGreetingsGrpcService
{
    /// <summary>
    /// // M�todo criado para chamadas via GRPC nativo
    /// </summary>
    Task<HelloReply> SayHelloAsync(Empty request, ServerCallContext context);

    /// <summary>
    /// // M�todo criado para chamadas via GRPC-Web
    /// </summary>
    Task<HelloReply> SayHelloAsync();
}