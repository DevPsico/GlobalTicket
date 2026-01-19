using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    /// <summary>
    /// Comando para deletar um evento existente.
    /// Contém o identificador do evento a ser removido.
    /// </summary>
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
