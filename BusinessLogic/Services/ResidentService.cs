﻿using BusinessLogic.Interfaces;
using DB.Entity;
using DB.Repositories;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ResidentService : IResidentService
    {
        
        private readonly IResidentRepository _residentRepository;
        
        public ResidentService(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
            
        }
        public async Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityAsync(int communityId)
        {
            return await _residentRepository.GetAllResidentsByCommunityIdAsync(communityId);
        }

        public async Task<ResidentDTO> GetResidentsByResidentIdAsync(int residentId)
        {
            return await _residentRepository.GetResidentsByResidentIdAsync(residentId);
        }

        public async Task<ResidentDTO> CreateResidentAsync(ResidentDTO dto)
        {
            return await _residentRepository.SaveResidentAsync(dto);
        }

        public async Task UpdateResidentAsync(int id, ResidentDTO dto)
        {
            await _residentRepository.UpdateResidenAsync(id, dto);
        }
        public async Task<ResidentDTO> GetResidentsByNRICAsync(string nric,int communityId)
        {
            return await _residentRepository.GetResidentsByNRICAsync(nric, communityId);
        }

        public async Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityDropdownAsync(int communityId, string Type)
        {
            return await _residentRepository.GetResidentsDropdownsAsync(communityId,Type);
        }

        public async Task<ResidentDTO> GetResidentsNameandContactByAddresses(string roadNo, string blockNo, string level, string houseNo)
        {
            return await _residentRepository.GetResidentsNameandContactByAddresses(roadNo, blockNo, level, houseNo);
        }
        public async Task<IEnumerable<ResidentDTO>> SearchResidentsByCommunityIdAsync(ResidentDTO search)
        {
            return await _residentRepository.SearchResidentsByCommunityIdAsync(search);
        }

    }
}
