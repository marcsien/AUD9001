using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain
{
    public class RequestBase<T> : IRequest<T>
    {
        public string userRole { get; set; }
    }
}
