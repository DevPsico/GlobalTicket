using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    /// <summary>
    /// Comando para criar um novo evento.
    /// Utilizado para transportar os dados necessários para a criação de um evento.
    /// </summary>
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date {  get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Retorna uma string com as principais informações do evento.
        /// Útil para logs e depuração.
        /// </summary>
        public override string ToString()
        {
            return $"Event Name: {Name}; Price {Price}; By {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
