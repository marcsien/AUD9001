using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUD9001.ApplicationServices.API.Domain.Models;

namespace AUD9001.ApplicationServices.API.Domain
{
    public class GetObservationsResponse : ResponseBase<List<Observation>>
    {
    }
}
