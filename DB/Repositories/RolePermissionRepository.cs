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
using System.Threading;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class RolePermissionRepository : RepositoryBase<RoleMenuPermission, RoleMenuPermissionDTO>, IRolePermissionRepository
    {
        public RolePermissionRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }

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

        public async Task<IEnumerable<MenuResponseDto>> GetRolesMenu(int roleId)
        {
            var menusWithSubmenus = await _context.Menu.Where(x=>x.ParentId=="0")
                                  .GroupJoin(_context.RoleMenuPermission.Where(mr => mr.RoleId == roleId),
                                   menu => menu.Id,
                                   menuRole => menuRole.MenuId,
                                   (menu, menuRoles) => new MenuResponseDto
                                   {
                                       MenuId = menu.Id,
                                       MenuName = menu.Name,

                                       Url = menu.Url,
                                       Submenus = menuRoles
                                        .Join(_context.Menu, // ✅ Join with SubMenu Table
                                         roleMenu => roleMenu.SubMenuId,
                                         submenu => submenu.Id,
                                         (roleMenu, submenu) => new SubmenuDto
                                         {
                                             SubmenuId = submenu.Id,
                                             SubmenuName = submenu.Name ?? "",
                                             Url = _context.Menu.Where(x=>x.Id== submenu.Id).Select(x=>x.Url).FirstOrDefault()
                                         })
                                        .ToList()
                                   })
                                   .ToListAsync();
            return menusWithSubmenus;

        }
    }
}
