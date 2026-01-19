using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Data Transfer Object (DTO) para categoria de evento.
    /// Utilizado para transportar dados de categoria entre as camadas da aplicação,
    /// evitando expor diretamente a entidade do domínio.
    /// </summary>
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
