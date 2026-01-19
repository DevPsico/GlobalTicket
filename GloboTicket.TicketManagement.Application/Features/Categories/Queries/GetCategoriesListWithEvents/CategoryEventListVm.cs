using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    /// <summary>
    /// ViewModel utilizado para exibir uma categoria junto com seus eventos.
    /// Contém uma coleção de eventos associados à categoria.
    /// </summary>
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto>? Events { get; set; }
    }
}
