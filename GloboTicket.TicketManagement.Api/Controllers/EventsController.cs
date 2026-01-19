using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas a eventos.
    /// Fornece endpoints para listar, obter detalhes, criar, atualizar e deletar eventos.
    /// </summary>
    public class EventsController : Controller
    {
        // Instância do MediatR para enviar comandos e consultas.
        private readonly IMediator mediator;

        /// <summary>
        /// Construtor que recebe o IMediator via injeção de dependência.
        /// </summary>
        /// <param name="mediator">Instância do MediatR.</param>
        public EventsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retorna a lista de todos os eventos cadastrados.
        /// </summary>
        /// <returns>Lista de eventos (EventListVm).</returns>
        [HttpGet(Name = "GetEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var events = await mediator.Send(new GetEventListQuery());
            return Ok(events);
        }

        /// <summary>
        /// Retorna os detalhes de um evento específico pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do evento.</param>
        /// <returns>Detalhes do evento (EventDetailVm).</returns>
        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
        {
            var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
            return Ok(await mediator.Send(getEventDetailQuery));
        }

        /// <summary>
        /// Cria um novo evento.
        /// </summary>
        /// <param name="createEventCommand">Comando contendo os dados do novo evento.</param>
        /// <returns>ID do evento criado.</returns>
        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> AddEvent([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await mediator.Send(createEventCommand);
            return Ok(id);
        }

        /// <summary>
        /// Atualiza um evento existente.
        /// </summary>
        /// <param name="updateEventCommand">Comando contendo os dados atualizados do evento.</param>
        /// <returns>NoContent se a atualização for bem-sucedida.</returns>
        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommand updateEventCommand)
        {
            await mediator.Send(updateEventCommand);
            return NoContent();
        }

        /// <summary>
        /// Remove um evento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do evento a ser removido.</param>
        /// <returns>NoContent se a remoção for bem-sucedida.</returns>
        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            await mediator.Send(new DeleteEventCommand() { EventId = id });
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        public async Task<IActionResult> ExportEvents()
        {
            var fileDto = await mediator.Send(new GetEventsExportQuery());

            // Use the correct property name: FileName instead of EventExportFileName
            return File(fileDto.Data, fileDto.ContentType, fileDto.FileName);
        }
    }
}