using Microsoft.EntityFrameworkCore;
using DB.EFModel;
using DB.Repositories.Interfaces;
using AutoMapper;
using DB.Entity;
using Microsoft.AspNetCore.Http;

namespace DB.Repositories
{
    public class UserRepository : RepositoryBase<Users, UserDTO>, IUserRepository
    {
        public UserRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }
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
                CommunityId=u.CommunityId,
                RoleId=u.RoleId,

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
                UserName = username,
                Response = response,
                RecaptchaScore = "0",
                JwtTokenExpiryDate = jwtExpiryDate,
                Online = isOnline
            };
            _context.LoginHistory.Add(loginHistory);
            _context.SaveChanges();
        }

        public async Task<bool> CheckPassword(string Password,int roleId)
        {
            if (roleId == 0)
            {
                var user = await _context.Users.Where(x => x.Password == Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    throw new Exception("Invalid username or password");
                }
                if (user != null)
                    return true;
                else
                    return false;
            }
            else
            {
                var user = await _context.Resident.Where(x => x.Password == Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    throw new Exception("Invalid username or password");
                }
                if (user != null)
                    return true;
                else
                    return false;
            }

        }

        public int? RoleForUser(int userId)
        {
            return _context.Users.Where(x => x.Id == userId).Select(x => x.RoleId).FirstOrDefault();
        }

        //public async Task<RoleDTO?> GetRoleAsync(int userId) // Nullable return type
        //{
        //    return await _context.Users
        //        .Where(c => c.Id == userId) // Filter first for efficiency
        //        .Select(c => new RoleDTO
        //        {
        //            Id = c.Id,
        //            Name = c.Name ?? "" // Ensure Name is not null
        //        })
        //        .FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<UserDTO>> GetUserListAsync()
        {
            return await _context.Users
                .Select(c => new UserDTO
                {
                    Id = c.Id,
                    RoleName = c.Role == null ? "" : c.Role.Name,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    RoleId = c.RoleId,
                    Status = c.Status,
                    Email = c.Email,
                    LastLogin = c.LastLogin,
                    UserName = c.UserName,
                    BadLoginAttempt = c.BadLoginAttempt,
                    PasswordExpiryDate = c.PasswordExpiryDate,
                    Password = c.Password,
                    PicturePath = c.PicturePath,
                    Name = c.Name,

                })
                .ToListAsync();

        }

        public async Task<UserDTO> SaveUserAsync(UserDTO user)
        {
            if (userExist(user.UserName))
            {
                throw new Exception("User Already Exist with Same UserName");
            }
            var entity = _mapper.Map<EFModel.Users>(user);
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        private bool userExist(string? userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public async Task UpdateUserAsync(int userId, UserDTO user)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);
            if (entity != null)
            {
                entity.Name = user.Name;
                entity.Email = user.Email;
                entity.Password = user.Password;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.RoleId = user.RoleId;
                entity.Status = user.Status;
                entity.UpdatedDate = DateTime.Now;
                entity.UserName = user.UserName;
                entity.CommunityId=user.CommunityId;
                entity.Name = user.FirstName + " " + user.LastName;
            }
            await _context.SaveChangesAsync();
        }


    }
}
