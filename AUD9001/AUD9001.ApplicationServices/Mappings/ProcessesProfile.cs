using AUD9001.ApplicationServices.API.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Mappings
{
    public class ProcessesProfile : Profile
    {
        public ProcessesProfile()
        {
            this.CreateMap<AUD9001.DataAccess.Entities.Process, Process>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}