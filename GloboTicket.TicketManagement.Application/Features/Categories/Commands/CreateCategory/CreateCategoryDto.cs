using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    /// <summary>
    /// DTO utilizado para transportar dados da categoria criada.
    /// Evita expor diretamente a entidade do domínio.
    /// </summary>
    public class CreateCategoryDto
    {
        /// <summary>
        /// Identificador único da categoria.
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Nome da categoria.
        /// </summary>
        public string Name { get; set; }
    }
}
