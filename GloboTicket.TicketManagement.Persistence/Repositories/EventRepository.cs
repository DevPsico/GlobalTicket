using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Repositório específico para a entidade Event, responsável por operações de acesso a dados relacionadas a eventos.
// Herda métodos genéricos do BaseRepository<Event> e implementa a interface IEventRepository para métodos personalizados.
namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    /// <summary>
    /// Repositório de eventos que centraliza o acesso e manipulação de dados da entidade Event.
    /// Permite operações CRUD genéricas e métodos específicos, como verificar unicidade de título e data.
    /// </summary>
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        /// <summary>
        /// Construtor que recebe o contexto do banco de dados e repassa para o repositório base.
        /// </summary>
        /// <param name="dbContext">Instância do contexto do banco de dados.</param>
        public EventRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Verifica se já existe um evento com o mesmo título e data.
        /// Útil para garantir que não haja eventos duplicados no sistema.
        /// </summary>
        /// <param name="title">Título do evento a ser verificado.</param>
        /// <param name="date">Data do evento a ser verificado.</param>
        /// <returns>Retorna true se já existir um evento com o mesmo título e data, caso contrário false.</returns>
        public Task<bool> IsEventTitleAndDateUnique(string title, DateTime date)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(title) && e.Date.Date.Equals(date.Date));

            return Task.FromResult(matches);
        }
    }
}