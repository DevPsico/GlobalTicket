using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Handler responsável por processar a GetEventDetailQuery.
    /// Recupera os detalhes do evento solicitado, normalmente usando um repositório,
    /// e retorna um ViewModel com as informações.
    /// </summary>
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {

        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        // Dependências (repositório, mapper, etc.) são injetadas via construtor.
        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            // Implementação da lógica para buscar e retornar os detalhes do evento.

            // Busca o evento pelo ID informado na requisição
            var @event = await _eventRepository.GetByIdAsync(request.Id);

            // Mapeia a entidade Event para o ViewModel EventDetailVm
            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

            // Busca a categoria relacionada ao evento
            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

            // Mapeia a entidade Category para o DTO CategoryDto e atribui ao ViewModel
            eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

            // Retorna o ViewModel com os dados completos do evento
            return eventDetailDto;
        }
    }
}
