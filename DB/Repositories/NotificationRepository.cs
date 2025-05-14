using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class NotificationRepository : RepositoryBase<Notifications, NotificationDTO>, INotificationRepository
    {
        public NotificationRepository(CSADbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }

        public async Task<IEnumerable<NotificationDTO>> GetNotificationByResidentIdAsync(int residentId)
        {
            var Notifications = await _context.Notifications.Include(c => c.Resident).Where(x=>x.ResidentId== residentId).ToListAsync();
            return _mapper.Map<IEnumerable<NotificationDTO>>(Notifications);
        }
    }
}
