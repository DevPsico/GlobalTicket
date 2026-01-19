using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    /// <summary>
    /// Exceção lançada quando ocorre erro de validação nos dados.
    /// Pode ser utilizada tanto para validações do .NET quanto do FluentValidation.
    /// </summary>
    public class ValidationException : Exception
    {
        // Armazena o resultado da validação do FluentValidation, se utilizado.
        private FluentValidation.Results.ValidationResult validationResult;

        /// <summary>
        /// Lista de mensagens de erro de validação.
        /// </summary>
        public List<string> ValidationErrors { get; set; }

        /// <summary>
        /// Construtor para validações usando System.ComponentModel.DataAnnotations.
        /// Extrai mensagens de erro e membros inválidos.
        /// </summary>
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            if (validationResult != null)
            {
                if (!string.IsNullOrEmpty(validationResult.ErrorMessage))
                {
                    ValidationErrors.Add(validationResult.ErrorMessage);
                }
                if (validationResult.MemberNames != null)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        ValidationErrors.Add(memberName);
                    }
                }
            }
        }

        /// <summary>
        /// Construtor para validações usando FluentValidation.
        /// Permite armazenar o resultado completo da validação.
        /// </summary>
        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            this.validationResult = validationResult;
        }
    }
}
