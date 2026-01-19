using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    /// <summary>
    /// DTO utilizado para transportar dados de eventos associados a uma categoria.
    /// Evita expor diretamente a entidade do domínio.
    /// </summary>
    public class CategoryEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Artist { get; set; }
        public DateTime Date {  get; set; }
        public Guid CategoryId { get; set; }

    }
}
