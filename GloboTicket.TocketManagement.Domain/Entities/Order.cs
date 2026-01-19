using GloboTicket.TocketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TocketManagement.Domain.Entities
{
    /// <summary>
    /// Representa um pedido de ingressos para eventos.
    /// Herda propriedades de auditoria de AuditableEntity.
    /// </summary>
    public class Order : AuditableEntity
        {
            public Guid OrderId { get; set; }
            public Guid UserId { get; set; }
            public int OrderTotal { get; set; }
            public DateTime OrderPlaced{ get; set; }
            public bool OrderPaid { get; set; }
    }
}
