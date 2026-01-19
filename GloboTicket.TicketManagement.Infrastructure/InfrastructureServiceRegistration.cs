using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Infrastructure.FileExport;
using GloboTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe estática responsável por registrar os serviços de infraestrutura no container de injeção de dependência.
// Centraliza a configuração de serviços como envio de e-mail, facilitando a organização e manutenção do projeto.
namespace GloboTicket.TicketManagement.Infrastructure
{
    /// <summary>
    /// Classe utilitária para registrar serviços de infraestrutura, como configurações de e-mail e provedores externos.
    /// </summary>
    public static class InfrastructureServiceRegistration
    {
        /// <summary>
        /// Método de extensão que adiciona e configura os serviços de infraestrutura no container de injeção de dependência.
        /// </summary>
        /// <param name="services">Coleção de serviços da aplicação (IServiceCollection).</param>
        /// <param name="configuration">Configurações da aplicação, usada para obter seções como EmailSettings.</param>
        /// <returns>A própria coleção de serviços, permitindo encadeamento de métodos.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            // Configura as opções de e-mail, mapeando a seção "EmailSettings" do appsettings.json para a classe EmailSettings.
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            // Registra o serviço de envio de e-mail, permitindo a injeção de IEmailService.
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}