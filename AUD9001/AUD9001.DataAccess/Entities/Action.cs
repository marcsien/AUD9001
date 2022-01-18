using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Action  : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ResponsiblePersonId { get; set; }

        public bool IsFinished { get; set; }
        public RecommendedAction RecommendedAction { get; set; }
    }
}
