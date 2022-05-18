using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.User
{
    public class ValidateUserRequest : RequestBase<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
