using AutoMapper;
using DB.EFModel;
using DB.Entity;

public class VisitorProfile : Profile
{
    public VisitorProfile()
    {

        CreateMap<VisitorAccessDetailsDTO, VisitorAccessDetails>()
                .ForMember(dest => dest.VisitorAccessType, opt => opt.Ignore());

        CreateMap<VisitorAccessDetailsDTO, VisitorAccessDetails>()
            .ForMember(dest => dest.VisitorAccessType, opt => opt.Ignore());


        CreateMap<VisitorAccessDetails, VisitorAccessDetailsDTO>();
        CreateMap<VisitorAccessDetailsDTO, VisitorAccessDetails>();
    }
}