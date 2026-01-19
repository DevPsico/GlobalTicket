using GloboTicket.TicketManagement.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Interface responsável por definir o contrato para serviços de envio de e-mail na aplicação.
// Permite abstrair a implementação do envio de e-mails, facilitando a troca de provedores e a realização de testes.
namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure
{
    /// <summary>
    /// Contrato para serviços de envio de e-mail.
    /// Implementações dessa interface devem fornecer a lógica para enviar e-mails usando o modelo Email.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Envia um e-mail de forma assíncrona.
        /// </summary>
        /// <param name="email">Objeto contendo destinatário, assunto e corpo do e-mail.</param>
        /// <returns>Retorna true se o e-mail foi enviado com sucesso, caso contrário false.</returns>
        Task<bool> SendEmail(Email email);
    }
}
