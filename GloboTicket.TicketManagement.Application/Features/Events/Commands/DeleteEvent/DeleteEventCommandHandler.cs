using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    /// <summary>
    /// Handler responsável por processar o comando de deleção de evento.
    /// Busca o evento pelo ID e remove do repositório.
    /// </summary>
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor recebe as dependências via injeção (mapper e repositório).
        /// </summary>
        public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Executa a lógica de deleção do evento.
        /// </summary>
        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            // Busca o evento pelo ID (opcional, pode ser usado para validação)
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

            // Remove o evento do repositório usando a instância do evento
            if (eventToDelete != null)
            {
                await _eventRepository.DeleteAsync(eventToDelete);
            }
        }
    }
}
