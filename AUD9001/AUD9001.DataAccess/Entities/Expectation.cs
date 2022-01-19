using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Expectation : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public InterestedPerson InterestedPerson { get; set; }
        public Attachment Attachment { get; set; }
    }
}
