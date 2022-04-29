using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } // plain password !! only for template purpose !!
        public string Email { get; set; }

        public byte[] Salt { get; set; }
        public Role Role { get; set; }
        
        public Process Process { get; set; }
    }
}
