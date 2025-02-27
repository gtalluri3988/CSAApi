using BusinessLogic.Interfaces.Repositories;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DB.Repositories.Services
{
    public class DropdownRepository : RepositoryBase<UserRepository>, IDropdownRepository
    {
        public DropdownRepository(CSADbContext context) : base(context) { }
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


    enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }

}
