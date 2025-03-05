using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;

namespace DB.Repositories
{
    public class FacilityRepository : RepositoryBase<Facility, FacilityDTO>, IFacilityRepository
    {
        public FacilityRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }

       
    }
}
