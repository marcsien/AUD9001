using AUD9001.ApplicationServices.API.Domain.Company;
using AUD9001.ApplicationServices.API.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            this.CreateMap<AUD9001.DataAccess.Entities.Company, Company>()
                .ForMember(x => x.Id,y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Processes, y => y.MapFrom(z => z.Processes != null ? z.Processes.Select(x => x.Name) : new List<string>()));

            this.CreateMap<AddCompanyRequest, AUD9001.DataAccess.Entities.Company>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));

            this.CreateMap<UpdateCompanyRequest, AUD9001.DataAccess.Entities.Company>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
