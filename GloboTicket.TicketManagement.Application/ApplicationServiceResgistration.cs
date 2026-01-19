using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application
{
    /// <summary>
    /// Classe estática responsável por registrar os serviços da camada Application
    /// na injeção de dependência do projeto.
    /// </summary>
    public static class ApplicationServiceResgistration
    {
        /// <summary>
        /// Método de extensão para IServiceCollection que adiciona e configura
        /// os serviços necessários da camada Application, como AutoMapper e MediatR.
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            /// Registra todos os perfis de mapeamento do AutoMapper encontrados nos assemblies do domínio atual.
            // O AutoMapper é utilizado para converter objetos entre diferentes tipos, como entidades e ViewModels.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Registra todos os handlers do MediatR encontrados nos assemblies do domínio atual.
            // O MediatR é usado para implementar o padrão CQRS, facilitando a separação entre comandos e queries.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // Retorna a coleção de serviços para permitir encadeamento de métodos.
            return services;
        }
    }
}