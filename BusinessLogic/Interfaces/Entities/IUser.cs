using BusinessLogic.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Entities
{
    public interface IUser
    {
        int Id { get;  }
        UserObject Details { get; }

        //bool IsAdmin { get; set; }

        //bool HasRole { get; set; }
        
    }
}
