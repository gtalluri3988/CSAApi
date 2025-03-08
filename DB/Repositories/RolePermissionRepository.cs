using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class RolePermissionRepository : RepositoryBase<RoleMenuPermission, RoleMenuPermissionDTO>, IRolePermissionRepository
    {
        public RolePermissionRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }

        public async Task UpdateRolePermissionAsync(int PermissionId, RoleMenuPermissionDTO rolePermission)
        {
            var updateRolePermission = await _context.RoleMenuPermission
           .Where(x => x.RoleId == rolePermission.RoleId && x.SubMenuId == rolePermission.SubMenuId && x.MenuId == rolePermission.MenuId)
           .FirstOrDefaultAsync();
            if (updateRolePermission != null)
            {
                throw new Exception("Role permissions already added");
            }
            var entity = await _context.RoleMenuPermission.FirstOrDefaultAsync(c => c.Id == PermissionId);
            if (entity != null)
            {
                entity.MenuId = rolePermission.MenuId;
                entity.SubMenuId = rolePermission.SubMenuId;
                entity.RoleId = rolePermission.RoleId;
                entity.UpdatedDate = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<RoleMenuPermissionDTO>> GetAllMenuPermissionListAsync()
        {

            return await _context.RoleMenuPermission
                .Select(c => new RoleMenuPermissionDTO
                {
                    Id = c.Id,
                    MenuId = c.MenuId ?? 0,
                    SubMenuId = c.SubMenuId ?? 0,
                    RoleId = c.RoleId ?? 0,
                    SubMenuName = _context.Menu.Where(m => m.Id == c.SubMenuId).Select(m => m.Name).FirstOrDefault(),
                    MenuName = c.Menu != null ? c.Menu.Name : null,
                    RoleName = c.Role != null ? c.Role.Name : null,

                })
                .ToListAsync();
        }
        public async Task<RoleMenuPermissionDTO> SaveMenuRolePermission(RoleMenuPermissionDTO roleMenuPermission)
        {
            var rolePermission = await _context.RoleMenuPermission
            .Where(x => x.RoleId == roleMenuPermission.RoleId 
            && x.SubMenuId == roleMenuPermission.SubMenuId && x.MenuId == roleMenuPermission.MenuId)
            .FirstOrDefaultAsync();
            if (rolePermission != null)
            {
                throw new Exception("Role permissions already added");
            }
            var entity = _mapper.Map<RoleMenuPermission>(roleMenuPermission);
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<RoleMenuPermissionDTO>(rolePermission);
        }
    }
}
