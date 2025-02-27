using DB.EFModel;

namespace DB.Repositories.Interfaces
{
    public interface ICommunityRepository
    {
        Task<List<Community>?> GetCommunityListAsync();
        Task<List<CommunityType>> GetCommunityTypeAsync();
    }
}
