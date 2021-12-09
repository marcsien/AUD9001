using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Resources : EntityBase
    {
        [Required]
        public DateTime AdditionDate { get; set; }
        public DateTime DeleteDate { get; set; }
        
        public List<Resource> ResourceList { get; set; }

        public int ProcessId { get; set; }
    }
}
