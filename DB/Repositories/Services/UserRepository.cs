using Microsoft.EntityFrameworkCore;
using DB.EFModel;
using BusinessLogic.Interfaces.Repositories;

namespace DB.Repositories
{
    public class UserRepository : RepositoryBase<UserRepository>, IUserRepository
    {
        public UserRepository(CSADbContext context) : base(context) { }
        public async Task<Users?> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            }
            catch (Exception ex)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            }
        }
        public Users GetUserByUsernameAsync(string username, bool includeInactive = false)
        {
            return SelectUserAsUserObject(
                QueryUsers(includeInactive).Where(x => x.UserName == username.ToLower())
                ).FirstOrDefault();
        }
        private IQueryable<Users> SelectUserAsUserObject(IQueryable<EFModel.Users> query)
        {
            return query.Select(u => new Users
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.Name,
                LastName = u.Name,
                UserName = u.UserName,
            });
        }
        private IQueryable<EFModel.Users> QueryUsers(bool includeInactive)
        {
            return _context.Users;
        }
        public void LogAuthAttempt(string username, string ip, string response, DateTime? jwtExpiryDate, bool isOnline)
        {
            var loginHistory = new EFModel.LoginHistory
            {
                Date = DateTime.Now,
                Ip = ip,
                UserName= username,
                Response = response,
                RecaptchaScore="0",
                JwtTokenExpiryDate = jwtExpiryDate,
                Online = isOnline
            };
            _context.LoginHistory.Add(loginHistory);
            _context.SaveChanges();
        }


    }
}
