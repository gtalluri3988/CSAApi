using DB.EFModel;
using DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly CSADbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(CSADbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

    }
}
