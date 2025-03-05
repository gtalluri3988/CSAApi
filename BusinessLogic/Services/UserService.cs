using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Entities;
using BusinessLogic.Models.Users;
using DB.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUser _user;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public IUser Authenticate(string email, string password, out AuthenticationError error)
        {
            try
            {
                (var user, error) = DoAuthenticate(email, password);
                if (user != null)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                error = AuthenticationError.Other("Exception: " + ex.Message);
            }
            return null;
        }
        private (IUser user, AuthenticationError error) DoAuthenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return (null, AuthenticationError.Other("Password or Email is empty"));
            }
            email = email.ToLower();
            var host = string.Empty;
            var userObj = _userRepository.GetUserByUsernameAsync(email, includeInactive: true);
            IUser user = null;
            if (userObj != null)
            {
                user = new User(new UserObject
                {
                    Id = userObj.Id,
                    Email = userObj?.Email?.Trim() ?? "",
                    UserName = userObj?.UserName?.Trim() ?? "",
                    FirstName = userObj?.FirstName?.Trim() ?? "",
                    LastName = userObj?.LastName?.Trim() ?? ""
                });
            }
            
            return (user, AuthenticationError.Other("Invalid Username and Password"));
        }
        public void LogAuthAttempt(string username, string ip, string response, DateTime? jwtExpiryDate, bool isOnline)
        {
            _userRepository.LogAuthAttempt(username, ip, response, jwtExpiryDate, isOnline);
        }



        public IUser GetByUsername(string userName)
        {
            var found = _userRepository.GetUserByUsernameAsync(userName);

            return null;
        }

    }
}
