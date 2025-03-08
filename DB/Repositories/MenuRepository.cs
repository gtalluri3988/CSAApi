using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class MenuRepository : RepositoryBase<Menu, MenuDTO>, IMenuRepository
    {
        public MenuRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }

        public async Task UpdateRoleAsync(int roleId, RoleDTO role)
        {
            var entity = await _context.Roles.FirstOrDefaultAsync(c => c.Id == roleId);
            if (entity != null && role != null)
            {
                entity.Name = role.Name ?? "";
                entity.Status = role.Status;
                entity.UpdatedDate = DateTime.Now;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            { }
        }

        public async Task<IEnumerable<MenuDTO>> GetSubMenuList(int menuId)
        {
            string Parent=menuId.ToString();
            var SubMenuList = await _context.Menu.Where(x=>x.ParentId!="0").Where(x => x.ParentId == menuId.ToString()).ToListAsync();
            return _mapper.Map<List<MenuDTO>>(SubMenuList);


        }
    }
}
