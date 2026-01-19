using System;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    /// <summary>
    /// Exceção lançada quando ocorre uma requisição inválida.
    /// Utilizada para sinalizar erros de validação ou dados incorretos enviados pelo cliente.
    /// </summary>
    public class BadRequestExceptions : Exception
    {
        /// <summary>
        /// Construtor que recebe a mensagem de erro da requisição.
        /// </summary>
        public BadRequestExceptions(string message) : base(message)
        {
        }
    }
}
