using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Document : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DocVersion> DocVersions { get; set; }
        public Process Process { get; set; }
    }
}
