using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{

    /// <summary>
    /// Handler responsável por processar a GetCategoriesListWithEventQuery.
    /// Recupera as categorias com seus eventos do repositório,
    /// e retorna uma lista de ViewModels para exibição.
    /// </summary>
    public class GetCategoriesListWithEventQueryHandler : IRequestHandler<GetCategoriesListWithEventQuery,
        List<CategoryEventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Construtor recebe as dependências via injeção (mapper e repositório).
        /// </summary>
        public GetCategoriesListWithEventQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Método que executa a lógica de busca das categorias com eventos e faz o mapeamento para ViewModels.
        /// </summary>
        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventQuery request, CancellationToken cancellationToken)
        {
            // Busca as categorias com eventos, podendo incluir históricos
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

            // Mapeia a lista de entidades para a lista de ViewModels
            return _mapper.Map<List<CategoryEventListVm>>(list);
        }
    }
}
