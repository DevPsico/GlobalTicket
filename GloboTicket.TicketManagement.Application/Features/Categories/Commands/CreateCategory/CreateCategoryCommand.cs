using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    /// <summary>
    /// Comando para criar uma nova categoria.
    /// Utilizado para transportar os dados necessários para a criação de uma categoria.
    /// Implementa IRequest para integração com o MediatR.
    /// </summary>
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>, IBaseRequest
    {
        /// <summary>
        /// Nome da categoria a ser criada.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
