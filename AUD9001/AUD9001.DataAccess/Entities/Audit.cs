using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AUD9001.DataAccess.Entities
{
    public class Audit : EntityBase
    {
        [Required]
        public int AuditNumber { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime DeleteDate { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public AuditType AuditType { get; set; }

        public Audit ParentAudit { get; set; }

        [Required]
        public Process Process { get; set; }
    }
}
