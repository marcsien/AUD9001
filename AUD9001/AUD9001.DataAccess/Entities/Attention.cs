using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Attention : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RecommendedAction> RecommendedActions { get; set; }
        public string SpottedPerson { get; set; }
        public Audit Audit { get; set; }
    }

}
