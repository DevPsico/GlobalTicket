using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;

// Classe estática que centraliza métodos de extensão para configurar os serviços e o pipeline da aplicação Web API.
// Facilita a organização do código de inicialização, separando responsabilidades e tornando o Startup mais limpo.
namespace GloboTicket.TicketManagement.Api
{
    /// <summary>
    /// Classe utilitária para configurar os serviços, pipeline e banco de dados da aplicação.
    /// Contém métodos de extensão para o WebApplicationBuilder e WebApplication.
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Configura e registra todos os serviços necessários para a aplicação, como camadas de Application, Infrastructure e Persistence.
        /// Também adiciona controllers e configura a política de CORS.
        /// </summary>
        /// <param name="builder">Objeto responsável por construir a aplicação web.</param>
        /// <returns>Instância de WebApplication pronta para uso.</returns>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            // Configura CORS para permitir requisições de origens específicas e credenciais.
            builder.Services.AddCors(
                options => options.AddPolicy(
                    "open", policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ?? "https://localhost:7020",
                        builder.Configuration["BlazorUrl"] ??"https://localhost:7080"])
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(pol => true)
                    .AllowAnyHeader()
                    .AllowCredentials()));

            builder.Services.AddSwaggerGen();

            return builder.Build();

        }

        /// <summary>
        /// Configura o pipeline de execução da aplicação, adicionando CORS, redirecionamento HTTPS e mapeamento de controllers.
        /// </summary>
        /// <param name="app">Instância da aplicação web.</param>
        /// <returns>Instância da aplicação web configurada.</returns>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

        /// <summary>
        /// Método auxiliar para resetar o banco de dados durante o desenvolvimento.
        /// Exclui e recria o banco de dados usando as migrações.
        /// </summary>
        /// <param name="app">Instância da aplicação web.</param>
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GloboTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // Exceção ignorada propositalmente.
            }
        }
    }
}
