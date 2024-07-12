# Template REST | gRPC Native | gRPC Web

Este projeto é um template para uma aplicação que inclui uma API REST, gRPC nativo e gRPC-web. A estrutura do projeto é dividida em várias camadas para organizar e modularizar o código de maneira eficiente.

## Estrutura do Projeto

### Greeter.Api
Esta camada é responsável pela configuração da API REST e pelos controllers.

### Greeter.Application
Aqui são definidos os serviços utilizados pela API REST.

### Greeter.Domain
Esta camada contém as entidades, objetos de valor e interfaces da API REST.

### Greeter.Infrastructure
Nesta camada estão os repositórios e queries utilizados pela API REST e pelos serviços gRPC (web e nativo).

### Greeter.Tests
Camada dedicada aos testes da API REST e dos serviços gRPC (web e nativo).

### Greeter.Grpc
Camada responsável pela configuração do gRPC nativo e web, incluindo controllers, interfaces, protos e serviços.

## Instalação e Configuração

1. **Clone o repositório:**
   ```sh
   git clone <url-do-repositorio>
   ```
2. **Rodando o projeto**

    2.1 **Em REST**
    ```sh
    cd GreeterTemplate/src/api/Greeter.Api
    dotnet run
    ```
    2.2 **Em gRPC**
    ```sh
    cd GreeterTemplate/src/api/Greeter.Grpc
    dotnet run
    ```
3. **Executando testes**
    ```sh
    dotnet test
    ```

## Consumo da aplicação
#### **REST** - Para consumir em REST, é necessário rodar a aplicação e acessar a URL: https://localhost:5001/Greetings

#### **gRPC Native** - Para consumir em gRPC Nativo, é necessário rodar a aplicação e, por meio de um software como [BloomRPC](https://github.com/bloomrpc/bloomrpc/releases), será necessário adicionar a proto (localizada em Greeter.Grpc/Protos) e executar o método SayHelloAsync, na URL [localhost:5000](localhost:5000)

#### **gRPC-WEB** - Para consumir em gRPC-Web, é necessário rodar a aplicação e acessar a URL: https://localhost:5001/GreetingsGrpc

#
Para o método REST, o retorno esperado é:
```
{
    "message": "Hello! | This message was proccessed by the service layer!"
}
```

E para os métodos em gRPC, o retorno esperado é:
Para o método REST, o retorno esperado é:
```
{
    "message": "Hello! | This message was proccessed by the gRPC service layer!"
}
```

## Fluxo da aplicação

As camadas REST e gRPC consomem a camada Greeter.Infrastructure. Essa camada retorna dados brutos do banco. Esses dados são processados de forma individual nas camadas de serviço do REST e gRPC e então são retornados na controller. No caso do gRPC nativo, o consumo é feito direto no método, sem passar pela controller.

## Adicionando novos métodos em gRPC

Para adicionar novos métodos ou entidades em gRPC, será necessário alterar o arquivo .proto. Ao fazer as alterações, é necessário buildar o projeto para que as "classes" sejam geradas automaticamente pelo gRPC.

*Para isso a biblioteca Grpc.AspNetCore deve estar instalada. Ao clonar esse projeto todas as bibliotecas já vêm instaladas. 