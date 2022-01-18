using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class RecommendedAction : EntityBase 
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string RecommendingPersonId { get; set; }

        public bool IsFinished { get; set; }

        public List<Action> Actions { get; set; }

        public Attension Attension { get; set; }

        public Inconsistency Inconsistency { get; set; }

        public Observation Observation { get; set; }
    }
}
