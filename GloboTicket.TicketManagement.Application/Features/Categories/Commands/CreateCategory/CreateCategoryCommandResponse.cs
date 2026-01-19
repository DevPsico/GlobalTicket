using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Responses; // Add this using directive if BaseResponse is in this namespace

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    /// <summary>
    /// Resposta do comando de criação de categoria.
    /// Herda de BaseResponse para padronizar respostas.
    /// </summary>
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {

        }
        /// <summary>
        /// DTO da categoria criada, retornado em caso de sucesso.
        /// </summary>
        public CreateCategoryDto Category { get; set; } = default!;
    }
}
