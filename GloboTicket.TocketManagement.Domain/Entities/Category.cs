using GloboTicket.TocketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TocketManagement.Domain.Entities
{
    /// <summary>
    /// Representa uma categoria para classificar eventos.
    /// Herda propriedades de auditoria de AuditableEntity.
    /// </summary>
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } 
        public ICollection<Event>? Events { get; set; }
        public Category() { }
        public Category(string name)
        {
            SetName(name);
        }

        /// <summary>
        /// Define o nome da categoria, validando tamanho e preenchimento.
        /// </summary>
        /// <param name="name">Nome a ser definido.</param>
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome da categoria não pode ser vazio.");
            if (name.Length > 50)
                throw new ArgumentException("Nome da categoria limitado a 50.");
            Name = name;
        }
    }
}
