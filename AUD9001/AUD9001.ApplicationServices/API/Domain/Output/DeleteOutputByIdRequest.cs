using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.Output
{
    public class DeleteOutputByIdRequest : RequestBase<DeleteOutputByIdResponse>
    {
        public int OutputId { get; set; }
    }
}
