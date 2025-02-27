using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Entities;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Models;
using BusinessLogic.Models.Users;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommunityRepository _communityRepository;
        public CommunityService(IUserRepository userRepository,ICommunityRepository communityRepository)
        {
            _userRepository = userRepository;
            _communityRepository = communityRepository;
        }
       

        public async Task<List<CommunityObject>> GetCommunityList()
        {
            var CommunityList =await _communityRepository.GetCommunityListAsync();
            return CommunityList?.Select(item => new CommunityObject
            {
                Id = item?.Id ?? 0,  // Default to 0 if null
                CommunityId = item?.CommunityId ?? string.Empty,  // Default to empty string
                CommunityName = item?.CommunityName ?? "Unknown",
                City = item?.CityName ?? "N/A",
                State = item?.StateId ?? 0,
                Address = item?.Address ?? "No Address",
                NoOfResidentParkingLot = item?.NoOfParkingLot ?? 0,
                NoOfUnits = item?.NoOfUnits ?? 0,
                PICEmail = item?.PICEmail ?? string.Empty,
                PICPhone = item?.PICMobile ?? string.Empty,
                PICName = item?.PICName ?? "No Contact"
            }).ToList() ?? new List<CommunityObject>(); // Return empty list if `CommunityList` is null

        }

        public async Task<List<CommunityTypeDto>> GetCommunityTypeList()
        {
            var CommunityList = await _communityRepository.GetCommunityTypeAsync();
            return CommunityList?.Select(item => new CommunityTypeDto
            {
                Id = item?.Id ?? 0,  // Default to 0 if null
                Name = item?.Name ?? string.Empty,  
                
            }).ToList() ?? new List<CommunityTypeDto>(); 

        }

    }
}
