using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AUD9001.DataAccess.Entities
{
    public class ManagementReview : EntityBase

    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
