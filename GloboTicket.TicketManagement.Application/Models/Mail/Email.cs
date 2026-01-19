using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe que representa um e-mail a ser enviado pela aplicação.
// Contém as informações básicas necessárias para compor uma mensagem de e-mail.
namespace GloboTicket.TicketManagement.Application.Models.Mail
{
    /// <summary>
    /// Modelo de dados para envio de e-mails.
    /// Armazena o destinatário, o assunto e o corpo da mensagem.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Endereço de e-mail do destinatário.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Assunto do e-mail.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Corpo do e-mail (mensagem principal).
        /// </summary>
        public string Body { get; set; }
    }
}
