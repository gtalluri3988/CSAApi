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
    public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {
            CreateMap<ComplaintDTO, ComplaintDetail>()
                .ForMember(dest => dest.ComplaintType, opt => opt.Ignore());

            CreateMap<ComplaintDTO, ComplaintDetail>()
                .ForMember(dest => dest.ComplaintType, opt => opt.Ignore());

            CreateMap<ComplaintDTO, ComplaintDetail>()
                .ForMember(dest => dest.ComplaintStatus, opt => opt.Ignore());

            CreateMap<ComplaintDTO, ComplaintDetail>()
                .ForMember(dest => dest.ComplaintStatus, opt => opt.Ignore());

            CreateMap<ComplaintDTO, ComplaintDetail>()
               .ForMember(dest => dest.Resident, opt => opt.Ignore());

            CreateMap<ComplaintDTO, ComplaintDetail>()
                .ForMember(dest => dest.Resident, opt => opt.Ignore());

            CreateMap<ComplaintDetail, ComplaintDTO>();
            CreateMap<ComplaintDTO, ComplaintDetail>();
        }
    }
}
