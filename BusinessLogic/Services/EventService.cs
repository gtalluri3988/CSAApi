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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            return await   _eventRepository.GetAllAsync();
        }

        public async Task<EventDTO> GetEventByIdAsync(int id)
        {
            return await  _eventRepository.GetByIdAsync(id);
        }

        public async Task<EventDTO> SaveEventAsync(EventDTO dto)
        {
            return await _eventRepository.AddAsync(dto);
        }

        public async Task UpdateEventAsync(int id, EventDTO dto)
        {
            await _eventRepository.UpdateAsync(id, dto);
        }
    }
}
