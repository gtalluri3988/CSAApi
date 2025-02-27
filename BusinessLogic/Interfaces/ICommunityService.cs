using BusinessLogic.Interfaces.Entities;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICommunityService
    {
        Task<List<CommunityObject>> GetCommunityList();
        Task<List<CommunityTypeDto>> GetCommunityTypeList();
    }
}
