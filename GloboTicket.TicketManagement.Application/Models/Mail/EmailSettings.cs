using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe que armazena as configurações necessárias para o envio de e-mails pela aplicação.
// Normalmente utilizada para mapear dados do arquivo de configuração (appsettings.json), como chave da API e remetente.
namespace GloboTicket.TicketManagement.Application.Models.Mail
{
    /// <summary>
    /// Representa as configurações de envio de e-mail.
    /// Contém informações como chave da API, endereço e nome do remetente.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Chave da API do serviço de e-mail (ex: SendGrid).
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// Endereço de e-mail do remetente.
        /// </summary>
        public string FromAddress { get; set; } = string.Empty;

        /// <summary>
        /// Nome do remetente que aparecerá nos e-mails enviados.
        /// </summary>
        public string FromName {  get; set; } = string.Empty;
    }
}
