using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class DocVersion : EntityBase
    {
        public string Version { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public User UserCreated { get; set; }
        public Document Document { get; set; }
        public Attachment Attachment { get; set; }
    }
}
