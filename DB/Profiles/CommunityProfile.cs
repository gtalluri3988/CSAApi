using AutoMapper;
using DB.EFModel;
using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Profiles
{
    public class CommunityProfile : Profile
    {
        public CommunityProfile()
        {
            CreateMap<CommunityDTO, Community>()
                .ForMember(dest => dest.State, opt => opt.Ignore());

            CreateMap<CommunityDTO, Community>()
                .ForMember(dest => dest.State, opt => opt.Ignore());
            CreateMap<Community, CommunityDTO>();
            CreateMap<CommunityDTO, Community>();
        }
    }
}
