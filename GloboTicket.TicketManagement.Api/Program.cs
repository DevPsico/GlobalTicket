// Arquivo principal de inicialização da aplicação Web API.
// Responsável por criar e configurar o builder, registrar os serviços, configurar o pipeline, resetar o banco de dados e iniciar o servidor.
using GloboTicket.TicketManagement.Api;

var builder = WebApplication.CreateBuilder(args); // Cria o builder para configurar a aplicação e ler argumentos de inicialização.
var app = builder.ConfigureServices().ConfigurePipeline();// Configura os serviços (DI, controllers, CORS) e o pipeline de requisições.

await app.ResetDatabaseAsync();// Reseta o banco de dados, útil para cenários de desenvolvimento e testes automatizados.

app.Run();// Inicia a aplicação e começa a escutar requisições HTTP.
