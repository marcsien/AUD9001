using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Process : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        public User ProcessLider { get; set; }
        public User ProcessDeputyLiderId { get; set; }
        
        public List<Resource> Resources { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Output> Outputs { get; set; }
        public List<Target> Targets { get; set; }
        public List<ProcessRequirement> Requirements { get; set; }

        [Required]
        public Company Company { get; set; }
        public List<Document> Documents { get; set; }
        public List<InterestedPerson> InterestedPeople { get; set; }
        public List<Audit> Audits { get; set; }
    }
}
