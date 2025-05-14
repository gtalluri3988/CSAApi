
using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DB.Repositories
{
    public class DropdownRepository : RepositoryBase<DropDownDTO, DropdownItem>, IDropdownRepository
    {
        public DropdownRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }
        public async Task<List<DropdownItem>?> GetDropdownDataAsync(string inputType)
        {

            if (inputType == DropDown.State.ToString())
            {
                return _context.State.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.VehicleType.ToString())
            {
                return _context.VehicleType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.PaymentType.ToString())
            {
                return _context.PaymentType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.VisitorAccessType.ToString())
            {
                return _context.VisitorAccessType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.ComplaintStatus.ToString())
            {
                return _context.ComplaintStatus.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.CommunityType.ToString())
            {
                return _context.CommunityType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.ChargesType.ToString())
            {
                return _context.ChargesType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.Status.ToString())
            {
                return new()
                {
                    new DropdownItem { Id = 1, Name = "Active" },
                    new DropdownItem { Id = 0, Name = "Inactive" }
                };

            }
            else if (inputType == DropDown.Role.ToString())
            {
                return _context.Roles.Where(x=>x.Name!= "ResidentUser").Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.Menu.ToString())
            {
                return _context.Menu.Where(x=>x.ParentId=="0").Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.FacilityType.ToString())
            {
                return _context.FacilityType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.ComplaintType.ToString())
            {
                return _context.ComplaintType.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            else if (inputType == DropDown.PaymentStatus.ToString())
            {
                return _context.PaymentStatus.Select(item => new DropdownItem
                {
                    Id = item.Id,
                    Name = item.Name ?? string.Empty,
                }).ToList() ?? new List<DropdownItem>();
            }
            return new List<DropdownItem>();

        }
    }


   

}
