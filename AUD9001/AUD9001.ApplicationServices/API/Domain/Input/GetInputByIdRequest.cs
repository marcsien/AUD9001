using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.Input
{
    public class GetInputByIdRequest : RequestBase<GetInputByIdResponse>
    {
        public int InputId { get; set; }
    }
}
