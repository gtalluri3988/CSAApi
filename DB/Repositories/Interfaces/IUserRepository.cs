
using DB.EFModel;


namespace DB.Repositories.Interfaces
{
    public interface IUserRepository 
    {
        Users GetUserByUsernameAsync(string email,bool includeInactive=false);
        void LogAuthAttempt(string username, string ip, string response, DateTime? jwtExpiryDate, bool isOnline);
    }
    
}
