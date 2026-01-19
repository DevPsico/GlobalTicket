using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    /// <summary>
    /// Handler responsável por processar a GetEventListQuery.
    /// Recupera todos os eventos do repositório, ordena por data,
    /// e retorna uma lista de ViewModels para exibição.
    /// </summary>
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor recebe as dependências via injeção (repositório e mapper).
        /// </summary>
        public GetEventListQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Método que executa a lógica de busca e mapeamento dos eventos.
        /// </summary>
        public async Task<List<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            // Busca todos os eventos e ordena por data
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);

            // Mapeia a lista de entidades para a lista de ViewModels
            return _mapper.Map<List<EventListVm>>(allEvents);
        }
    }
}
