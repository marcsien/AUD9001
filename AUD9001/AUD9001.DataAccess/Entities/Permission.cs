using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Permission : EntityBase
    {
        public string Name { get; set; }
        public List<Role> Roles { get; set; }
    }
}
