using GloboTicket.TocketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe de configuração para a entidade Event.
// Utiliza a interface IEntityTypeConfiguration<Event> para definir regras de mapeamento no Entity Framework Core.
// Aqui, é possível especificar restrições, tipos de dados, relacionamentos e outras configurações de banco de dados
// para a entidade Event.
namespace GloboTicket.TicketManagement.Persistence.Configurations
{
    /// <summary>
    /// Configurações específicas para a entidade <see cref="Event"/> no Entity Framework Core.
    /// Define restrições e propriedades do modelo de dados para persistência no banco.
    /// </summary>
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        /// <summary>
        /// Método chamado pelo EF Core para aplicar configurações à entidade Event.
        /// Aqui, a propriedade Name é obrigatória e limitada a 50 caracteres.
        /// </summary>
        /// <param name="builder">Construtor de propriedades e restrições para a entidade Event.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Event> builder)
        {
            // Define que o campo Name é obrigatório (não pode ser nulo) e tem no máximo 50 caracteres.
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
