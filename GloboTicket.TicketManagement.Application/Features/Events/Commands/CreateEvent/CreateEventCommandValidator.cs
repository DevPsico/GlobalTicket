using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} obrigatório.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} não pode exceder 50 caracteres");

            RuleFor(p => p.Date).NotEmpty().WithMessage("{PropertyName} obrigatório.").NotNull().GreaterThan(DateTime.Now);

            RuleFor(p => p.Price).NotEmpty().WithMessage("{PropertyName} obrigatório.").GreaterThan(0);

            RuleFor(e => e).MustAsync(EventNameAndDateUnique).WithMessage("Já existe um evento com o mesmo nome nesta data.");

        }

        /// <summary>
        /// Verifica se já existe um evento com o mesmo nome e data.
        /// </summary>
        private async Task<bool> EventNameAndDateUnique(CreateEventCommand command, CancellationToken cancellationToken)
        {
            // Exemplo: consulta ao repositório para verificar duplicidade
            var existingEvents = await _eventRepository.ListAllAsync();
            return !existingEvents.Any(e => e.Name == command.Name && e.Date.Date == command.Date.Date);
        }
    }
}
