using AutoMapper;
using DB.EFModel;
using DB.Entity;


namespace DB.Profiles
{
    public class ResidentProfile : Profile
    {
        public ResidentProfile()
        {
            CreateMap<ResidentDTO, Resident>()
                .ForMember(dest => dest.State, opt => opt.Ignore());

            CreateMap<ResidentDTO, Resident>()
                .ForMember(dest => dest.State, opt => opt.Ignore());
            CreateMap<Resident, ResidentDTO>();
            CreateMap<ResidentDTO, Resident>();

        }
    }
}
