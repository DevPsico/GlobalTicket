using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    /// <summary>
    /// Query utilizada para solicitar a lista de eventos.
    /// Faz parte do padrão CQRS, onde queries são usadas para leitura de dados.
    /// </summary>
    public class GetEventListQuery : IRequest<List<EventListVm>>
    {
        // Não possui propriedades, pois retorna todos os eventos.
    }
}
