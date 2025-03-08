using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class AdminRepository : RepositoryBase<Community, AdminDTO>, IAdminRepository
    {
        public AdminRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }









    }
}
