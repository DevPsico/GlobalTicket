using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    /// <summary>
    /// Handler responsável por processar o comando de atualização de evento.
    /// Busca o evento pelo ID, aplica as alterações e salva no repositório.
    /// </summary>
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor recebe as dependências via injeção (mapper e repositório).
        /// </summary>
        public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Executa a lógica de atualização do evento.
        /// </summary>
        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            // Busca o evento existente pelo ID
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            // Mapeia as alterações do comando para a entidade existente
            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            // Salva as alterações no repositório
            await _eventRepository.UpdateAsync(eventToUpdate);
        }
            
    }
}
