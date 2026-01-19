using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TocketManagement.Domain.Common
{
    /// <summary>
    /// Classe base para entidades que precisam de informações de auditoria.
    /// Inclui propriedades para rastrear datas e usuários de criação e modificação.
    /// </summary>
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
