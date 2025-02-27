using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Users
{
    public class User : IUser
    {
        private readonly UserObject _user;
        private readonly IUserService _userService;

        public User(UserObject userObject)
        {
            _user = userObject;
            //_userService = userService;
        }
        public int Id { get => _user.Id; }
        public UserObject Details { get => _user; }

        //public bool HasRole(Roles role) => Roles.CSAAdmin;
    }


}
