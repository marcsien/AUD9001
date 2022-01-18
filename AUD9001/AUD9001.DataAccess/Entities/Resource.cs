using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Resource : EntityBase
    {
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime DeleteDate { get; set; }

        public Process Process { get; set; }
        public ResourceType Type { get; set; }


    }
}