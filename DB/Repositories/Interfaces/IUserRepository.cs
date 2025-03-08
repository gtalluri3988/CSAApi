
using DB.EFModel;
using DB.Entity;

namespace DB.Repositories.Interfaces
{
    public interface IUserRepository 
    {
        Users GetUserByUsernameAsync(string email,bool includeInactive=false);
        void LogAuthAttempt(string username, string ip, string response, DateTime? jwtExpiryDate, bool isOnline);
        Task<UserDTO> GetByIdAsync(int id);
        Task<bool> CheckPassword(string Password);
        int? RoleForUser(int userId);
        Task<IEnumerable<UserDTO>> GetUserListAsync();
        Task<UserDTO> SaveUserAsync(UserDTO user);
        Task UpdateUserAsync(int userId, UserDTO user);

        Task UpdateAsync(int id, UserDTO dto);

    }
    
}
