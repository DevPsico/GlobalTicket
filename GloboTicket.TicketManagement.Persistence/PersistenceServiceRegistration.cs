using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Persistence.Repositories;

namespace GloboTicket.TicketManagement.Persistence
{
    // Classe estática responsável por registrar os serviços de persistência no container de injeção de dependência.
    // Centraliza a configuração do acesso ao banco de dados e dos repositórios, facilitando a manutenção e organização do projeto.

    public static class PersistenceServiceRegistration
    {
        /// <summary>
        /// Método de extensão que adiciona e configura os serviços de persistência (banco de dados e repositórios)
        /// no container de injeção de dependência da aplicação.
        /// </summary>
        /// <param name="services">Coleção de serviços da aplicação (IServiceCollection).</param>
        /// <param name="configuration">Configurações da aplicação, usada para obter a string de conexão do banco.</param>
        /// <returns>A própria coleção de serviços, permitindo encadeamento de métodos.</returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o contexto do Entity Framework para usar SQL Server, lendo a string de conexão do arquivo de configuração.
            services.AddDbContext<GloboTicketDbContext>(options => options.UseSqlServer(configuration.
                GetConnectionString("GloboTicketTicketManagementConnectionString")));

            // Registra o repositório genérico para operações assíncronas.
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            // Registra os repositórios específicos para cada entidade.
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}