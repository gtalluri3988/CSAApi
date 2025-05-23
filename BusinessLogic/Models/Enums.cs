using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public enum Roles
    {
        [Display(Name = "System Admin")]
        SystemAdmin = 2,
        [Display(Name = "Community Admin")]
        CommunityAdmin =4,
        [Display(Name = "Resident User")]
        ResidentUser = 5,
        [Display(Name = "Resident User Admin")]
        ResidentUserAdmin =6,

    }
}
