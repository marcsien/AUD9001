using AUD9001.ApplicationServices.API.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Mappings
{
    public class ManagementReviewProfile : Profile
    {
        public ManagementReviewProfile()
        {
            this.CreateMap<AUD9001.DataAccess.Entities.ManagementReview, ManagementReview>()
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date));
        }
    }
}
