
using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;

namespace DB.Repositories
{
    public class DropdownRepository : RepositoryBase<DropDownDTO, DropdownItem>, IDropdownRepository
    {
        public DropdownRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }
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
            return new List<DropdownItem>();

        }
    }


   

}
