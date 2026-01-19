using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    /// <summary>
    /// Exceção lançada quando um recurso não é encontrado no sistema.
    /// Utilizada para informar que um objeto buscado não existe.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Construtor que recebe o nome do recurso e a chave de busca, gerando uma mensagem personalizada.
        /// </summary>
        public NotFoundException(string name, object key) : base($"{name} ({key}) is not found.")
        {
        }
       
    }
}
