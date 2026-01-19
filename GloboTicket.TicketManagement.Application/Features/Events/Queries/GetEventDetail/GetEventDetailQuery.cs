using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Query utilizada para solicitar os detalhes de um evento específico.
    /// Faz parte do padrão CQRS, onde queries são usadas para leitura de dados.
    /// </summary>
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
