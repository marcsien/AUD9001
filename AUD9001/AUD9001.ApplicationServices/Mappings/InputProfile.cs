using AUD9001.ApplicationServices.API.Domain.Input;
using AUD9001.ApplicationServices.API.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Mappings
{
    public class InputProfile : Profile
    {
        public InputProfile()
        {
            this.CreateMap<AUD9001.DataAccess.Entities.Input, Input>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ProcessID, y => y.MapFrom(z => z.Process.Id));

            this.CreateMap<AddInputRequest, AUD9001.DataAccess.Entities.Input>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));

            this.CreateMap<UpdateInputRequest, AUD9001.DataAccess.Entities.Input>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
