using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    /// <summary>
    /// Query utilizada para solicitar a lista de categorias.
    /// Faz parte do padrão CQRS, onde queries são usadas para leitura de dados.
    /// </summary>
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
        // Não possui propriedades, pois retorna todas as categorias.
    }
}
