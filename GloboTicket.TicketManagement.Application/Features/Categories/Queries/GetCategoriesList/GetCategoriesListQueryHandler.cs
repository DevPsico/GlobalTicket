using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    /// <summary>
    /// Handler responsável por processar a GetCategoriesListQuery.
    /// Recupera todas as categorias do repositório, ordena por nome,
    /// e retorna uma lista de ViewModels para exibição.
    /// </summary>
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor recebe as dependências via injeção (repositório e mapper).
        /// </summary>
        public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Método que executa a lógica de busca e mapeamento das categorias.
        /// </summary>
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            // Busca todas as categorias e ordena por nome
            var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);

            // Mapeia a lista de entidades para a lista de ViewModels
            return _mapper.Map<List<CategoryListVm>>(allCategories);
        }
    }
}
