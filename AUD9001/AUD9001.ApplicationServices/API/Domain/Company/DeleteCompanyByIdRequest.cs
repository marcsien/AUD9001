using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.Company
{
    public class DeleteCompanyByIdRequest : RequestBase<DeleteCompanyByIdResponse>
    {
        public int CompanyId { get; set; }
    }
}
