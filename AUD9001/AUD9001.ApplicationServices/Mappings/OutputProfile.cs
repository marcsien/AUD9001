using AUD9001.ApplicationServices.API.Domain.Models;
using AUD9001.ApplicationServices.API.Domain.Output;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Mappings
{
    public class OutputProfile : Profile
    {
        public OutputProfile()
        {
            this.CreateMap<AUD9001.DataAccess.Entities.Output, Output>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ProcessID, y => y.MapFrom(z => z.Process.Id));

            this.CreateMap<AddOutputRequest, AUD9001.DataAccess.Entities.Output>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
