using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    /// <summary>
    /// ViewModel utilizado para exibir informações básicas de uma categoria.
    /// Serve para transportar dados entre as camadas sem expor a entidade do domínio.
    /// </summary>
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
