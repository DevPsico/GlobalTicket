using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    /// <summary>
    /// Query utilizada para solicitar a lista de categorias com seus eventos.
    /// Permite incluir ou não eventos históricos.
    /// </summary>
    public class GetCategoriesListWithEventQuery : IRequest<List<CategoryEventListVm>>
    {
        /// <summary>
        /// Indica se deve incluir eventos históricos na consulta.
        /// </summary>
        public bool IncludeHistory { get; set; }
    }
}
