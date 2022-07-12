using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain
{
    public class AddProcessRequest : RequestBase<AddProcessResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
    }
}
