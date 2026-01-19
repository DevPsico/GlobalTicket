using FluentValidation;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    /// <summary>
    /// Validador para o comando de criação de categoria.
    /// Define as regras de validação para os dados da categoria.
    /// </summary>
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome da categoria obrigatório.")
                .MaximumLength(50).WithMessage("Nome da catgeoria limitado a 50.");
        }
    }
}