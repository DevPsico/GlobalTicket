using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    /// <summary>
    /// ViewModel utilizado para listar eventos na aplicação.
    /// Contém apenas as informações necessárias para exibição em listas,
    /// evitando expor todos os detalhes da entidade do domínio.
    /// </summary>
    public class EventListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
