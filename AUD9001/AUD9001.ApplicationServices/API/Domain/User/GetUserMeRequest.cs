using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.User
{
    public class GetUserMeRequest : RequestBase<GetUserMeResponse>
    {
       public string Login { get; set; }
    }
}
