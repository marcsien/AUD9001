using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AUD9001.DataAccess.Entities
{
    public class ProcessRequirement : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Attachment> Attachments { get; set; }
    }
}
