using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.Input
{
    public class UpdateInputRequest : RequestBase<UpdateInputResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProcessID { get; set; }
    }
}
