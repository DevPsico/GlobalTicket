using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    /// <summary>
    /// Handler responsável por processar o comando de criação de evento.
    /// Realiza o mapeamento do comando para a entidade e salva no repositório.
    /// </summary>
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Construtor recebe as dependências via injeção (mapper e repositório).
        /// </summary>
        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }

        /// <summary>
        /// Executa a lógica de criação do evento.
        /// </summary>
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // Mapeia o comando para a entidade Event
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            // Salva o evento no repositório
            @event = await _eventRepository.AddAsync(@event);

            // Envia um email de notificação sobre a criação do evento
            var email = new Email() { To = "ericsonsergio19844@gmail.com", Body = $"O evento foi criado com sucesso.", 
                Subject = "Novo Evento Criado" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                // Logar o erro
            }

            // Retorna o ID do evento criado
            return @event.EventId;
        }
    }
}
