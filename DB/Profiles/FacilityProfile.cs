using AutoMapper;
using DB.EFModel;
using DB.Entity;


namespace DB.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            
            CreateMap<Facility, FacilityDTO>();
            CreateMap<FacilityDTO, Facility>();
        }
    }
}
