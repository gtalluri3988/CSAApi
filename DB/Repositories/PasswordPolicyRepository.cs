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
    public class PasswordPolicyRepository : RepositoryBase<PasswordPolicy, PasswordPolicyDTO>, IPasswordPolicyRepository
    {
        public PasswordPolicyRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }


        public async Task<IEnumerable<PasswordPolicyDTO>> GetAllPasswordPolicyDetails()
        {
            var passwordPolicyData =await _context.PasswordPolicy
            .Select(p => new PasswordPolicyDTO { Id=p.Id,Status=p.Status, Code = p.Code, Value = p.Value })
            .ToListAsync();

            return passwordPolicyData;
        }
        public async Task<bool> SavePasswordPolicyAsync(List<PasswordPolicyDTO> policies)
        {
            try
            {
                
                foreach (var policy in policies)
                {
                    var existingPolicy = await _context.PasswordPolicy
                        .FirstOrDefaultAsync(p => p.Code == policy.Code);

                    if (existingPolicy != null)
                    {
                        // ✅ Update existing record
                        existingPolicy.Value = policy.Value;
                        _context.PasswordPolicy.Update(existingPolicy);
                    }
                    else
                    {
                        var entity = _mapper.Map<EFModel.PasswordPolicy>(policy);
                        // ✅ Insert new record
                        await _context.PasswordPolicy.AddAsync(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
