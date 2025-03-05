﻿using BusinessLogic.Interfaces;
using DB.Entity;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FacilityService : IFacilityService
    {

        private readonly IFacilityRepository _facilityRepository;

        public FacilityService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<IEnumerable<FacilityDTO>> GetAllFacilityAsync()
        {
            return await _facilityRepository.GetAllAsync();
        }

        public async Task<FacilityDTO> GetFacilityByIdAsync(int id)
        {
            return await _facilityRepository.GetByIdAsync(id);
        }

        public async Task<FacilityDTO> CreateFacilityAsync(FacilityDTO dto)
        {
            return await _facilityRepository.AddAsync(dto);
        }

        public async Task UpdateFacilityAsync(int id, FacilityDTO dto)
        {
            await _facilityRepository.UpdateAsync(id, dto);
        }

        public async Task DeleteFacilityAsync(int id)
        {
            await _facilityRepository.DeleteAsync(id);
        }
    }
}
