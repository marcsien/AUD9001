using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AUD9001.DataAccess.Entities
{
    public class Company : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string Address{ get; set; }
        public string Owner { get; set; }
        public List<Process> Processes { get; set; }
        public List<ManagementReview> ManagementReviews { get; set; }
    }
}
