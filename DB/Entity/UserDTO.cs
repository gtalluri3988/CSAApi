﻿using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Status { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string? RoleName { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string? UserName { get; set; }
        public string? PicturePath { get; set; }
        public Nullable<System.DateTime> PasswordExpiryDate { get; set; }
        public Nullable<int> BadLoginAttempt { get; set; }

        public Roles? Roles { get; set; }
    }
}
