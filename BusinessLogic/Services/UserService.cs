using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Entities;
using BusinessLogic.Models;
using BusinessLogic.Models.Users;
using DB.Entity;
using DB.Repositories;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IResidentRepository _residentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserRepository userRepository, IResidentRepository residentRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _residentRepository = residentRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public IUser Authenticate(string email, string password,int RoleId, out AuthenticationError error)
        {
            try
            {
                (var user, error) = DoAuthenticate(email, password, RoleId);
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
        private  (IUser user, AuthenticationError error) DoAuthenticate(string email, string password,int RoleId)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return (null, AuthenticationError.Other("Password or Email is empty"));
            }
            email = email.ToLower();
            var host = string.Empty;
            if (RoleId == 0)
            {
                var useObj1 = _userRepository.GetUserByUsernameAsync(email, includeInactive: true);
                UserObject userObject = new UserObject();
                if (useObj1 != null)
                {
                    userObject.Id = useObj1.Id;
                    userObject.Email = useObj1?.Email?.Trim() ?? "";
                    userObject.UserName = useObj1?.UserName?.Trim() ?? "";
                    userObject.FirstName = useObj1?.FirstName?.Trim() ?? "";
                    userObject.LastName = useObj1?.LastName?.Trim() ?? "";
                    userObject.CommunityId = useObj1.CommunityId == null ? 0 : useObj1.CommunityId.Value;
                    userObject.RoleId = useObj1.RoleId == null ? 0 : useObj1.RoleId.Value;
                }
                var user = new User(userObject, this);
                return (user, AuthenticationError.Other("Invalid Username and Password"));
            }
            else
            {
                var useObj1 =_residentRepository.GetResidentsByEmailPasswordAsync(email,password);
                UserObject userObject = new UserObject();
                if (useObj1 != null)
                {
                    userObject.Id = useObj1.Id;
                    userObject.Email = useObj1?.Email?.Trim() ?? "";
                    userObject.UserName = useObj1?.Email?.Trim() ?? "";
                    userObject.FirstName = useObj1?.Name?.Trim() ?? "";
                    userObject.LastName = useObj1?.NRIC?.Trim() ?? "";
                    userObject.CommunityId = useObj1.CommunityId;
                    userObject.RoleId = useObj1.RoleId;
                }
                var user = new User(userObject, this);
                return (user, AuthenticationError.Other("Invalid Username and Password"));
            }
        }
        public async Task<bool> CheckPassword(string password,int roleId)
        {
           return await _userRepository.CheckPassword(password, roleId);
            
        }

        public void LogAuthAttempt(string username, string ip, string response, DateTime? jwtExpiryDate, bool isOnline)
        {
            _userRepository.LogAuthAttempt(username, ip, response, jwtExpiryDate, isOnline);
        }

        public IUser GetByUsername(string userName)
        {
            var useObj = _userRepository.GetUserByUsernameAsync(userName, includeInactive: true);
            UserObject userObject = new UserObject();
            if (useObj != null)
            {
                userObject.Id = useObj.Id;
                userObject.Email = useObj?.Email?.Trim() ?? "";
                userObject.UserName = useObj?.UserName?.Trim() ?? "";
                userObject.FirstName = useObj?.FirstName?.Trim() ?? "";
                userObject.LastName = useObj?.LastName?.Trim() ?? "";
            }
            return new User(userObject, this);
        }
        public string RoleForUser(int userId)
        {
            string role = string.Empty;
            var roleId=_userRepository.RoleForUser(userId);
            if(roleId != null)
            {
                if(Enum.IsDefined(typeof(Roles), roleId))
                {
                   return Enum.GetName(typeof(Roles), roleId);
                }
            }
            return role;
        }
        //public async Task<RoleDTO> RoleIdUser(int userId)
        //{
        //    var roleId = await _userRepository.GetRoleAsync(userId);
        //    if (roleId == null)
        //    {
        //        throw new KeyNotFoundException($"No role found for user with ID {userId}");
        //    }
        //    return roleId;
        //}
        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User.Identity?.Name;
        }

        public List<string> GetUserRoles()
        {
            return _httpContextAccessor.HttpContext?.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList() ?? new List<string>();
        }

        public Task<IEnumerable<UserDTO>> GetUserListAsync()
        {
            return _userRepository.GetUserListAsync();
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO dto)
        {
            try
            {
                return await _userRepository.SaveUserAsync(dto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // Return only the error message
            }
            
        }

        public async Task UpdateUserAsync(int id, UserDTO dto)
        {
            await _userRepository.UpdateUserAsync(id, dto);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

    }
}
