using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar operações relacionadas a categorias.
    /// Fornece endpoints para listar categorias, listar categorias com eventos e criar novas categorias.
    /// </summary>
    public class CategoryController : Controller
    {
        // Instância do MediatR para enviar comandos e consultas.
        private readonly IMediator mediator;

        /// <summary>
        /// Construtor que recebe o IMediator via injeção de dependência.
        /// </summary>
        /// <param name="mediator">Instância do MediatR.</param>
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retorna a lista de todas as categorias cadastradas.
        /// </summary>
        /// <returns>Lista de categorias (CategoryListVm).</returns>
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var categories = await mediator.Send(new GetCategoriesListQuery());
            return Ok(categories);
        }

        /// <summary>
        /// Retorna a lista de todas as categorias com seus eventos associados.
        /// Pode incluir ou não eventos históricos, conforme o parâmetro.
        /// </summary>
        /// <param name="includeHistory">Se true, inclui eventos passados; se false, apenas eventos futuros.</param>
        /// <returns>Lista de categorias com eventos (CategoryEventListVm).</returns>
        [HttpGet("allwithevents", Name = "GetAllCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var categories = await mediator.Send(new GetCategoriesListWithEventQuery() { IncludeHistory = includeHistory });
            return Ok(categories);
        }

        /// <summary>
        /// Cria uma nova categoria.
        /// </summary>
        /// <param name="createCategoryCommand">Comando contendo os dados da nova categoria.</param>
        /// <returns>Resposta com informações da categoria criada.</returns>
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> AddCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}