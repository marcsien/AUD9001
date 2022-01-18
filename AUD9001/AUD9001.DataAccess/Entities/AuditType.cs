using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AUD9001.DataAccess.Entities
{
    public class AuditType : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime DeleteDate { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public List<Audit> Audits { get; set; }

    }
}
