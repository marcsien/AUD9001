using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AUD9001.ApplicationServices.API.Domain
{
    public class DeleteProcessByIdRequest : RequestBase<DeleteProcessByIdResponse>
    {
        public int ProcessId { get; set; }
    }
}
