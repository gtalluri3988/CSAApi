using DB.EFModel;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DB.Repositories.Services
{
    public class CommunityRepository: RepositoryBase<UserRepository>, ICommunityRepository
    {
        public CommunityRepository(CSADbContext context) : base(context) { }
        public async Task<List<Community>?> GetCommunityListAsync()
        {
            return await _context.Community.ToListAsync();
        }
        public async Task<List<CommunityType>> GetCommunityTypeAsync()
        {
            return await _context.CommunityType.ToListAsync();
        }
    }
}
