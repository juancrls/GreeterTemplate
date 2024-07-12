using Greeter.Domain.Interfaces.Repositories.Greetings;
using Greeter.Grpc.Services;
using Greeter.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IGreetingsRepository, GreetingsRepository>();
builder.Services.AddTransient<IGreetingsGrpcService, GreetingsGrpcService>();
builder.Services.AddGrpc();

builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();

app.UseGrpcWeb();
app.UseCors();

app.MapGrpcService<GreetingsGrpcService>().EnableGrpcWeb()
                                    .RequireCors("AllowAll");

app.MapControllers();

app.Run();