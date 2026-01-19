using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe responsável por implementar o serviço de envio de e-mails na aplicação.
// Utiliza o SendGrid como provedor de envio e lê as configurações de e-mail via injeção de dependência.
// Implementa a interface IEmailService, permitindo abstração e fácil troca de implementação.
namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
    /// <summary>
    /// Serviço de envio de e-mails usando o SendGrid.
    /// Implementa o contrato <see cref="IEmailService"/> e utiliza as configurações de <see cref="EmailSettings"/>.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Configurações de e-mail, como chave da API, remetente e nome do remetente.
        /// </summary>
        public EmailSettings _emailSettings { get; }

        /// <summary>
        /// Construtor que recebe as configurações de e-mail via injeção de dependência.
        /// </summary>
        /// <param name="emailSettings">Opções de configuração de e-mail.</param>
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        /// <summary>
        /// Envia um e-mail de forma assíncrona utilizando o SendGrid.
        /// </summary>
        /// <param name="email">Objeto contendo destinatário, assunto e corpo do e-mail.</param>
        /// <returns>Retorna true se o e-mail foi enviado com sucesso, caso contrário false.</returns>
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress(
                _emailSettings.FromAddress,
                _emailSettings.FromName
            );

            
            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);

            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
                response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
