using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRotaApi.Models;
using WebRotaApi.Resources;

namespace WebRotaApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberResource>();
            CreateMap<Organisation, OrganisationResource>()
                            .ForMember(or => or.Members, o => o.MapFrom(org => org.Members.Select(om => om.Member).ToList()));
        }
    }
}
