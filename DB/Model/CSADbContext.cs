using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.EFModel
{
    public class CSADbContext : DbContext
    {
        public CSADbContext(DbContextOptions<CSADbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<PasswordPolicy> PasswordPolicy { get; set; }
        public DbSet<CommunityType> CommunityType { get; set; }

        public DbSet<Community> Community { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }
        public DbSet<Resident> Resident { get; set; }
        public DbSet<ResidencePaymentDetails> ResidencePaymentDetails { get; set; }

        public DbSet<FacilityType> FacilityType { get; set; }
        public DbSet<VisitorAccessType> VisitorAccessType { get; set; }
        public DbSet<ComplaintStatus> ComplaintStatus { get; set; }
        public DbSet<Facility> Facility { get; set; }
        public DbSet<FacilityPhoto> FacilityPhoto { get; set; }
        public DbSet<ResidentAccessHistory> ResidentAccessHistory { get; set; }
        public DbSet<VisitorAccessDetails> VisitorAccessDetails { get; set; }
        public DbSet<ComplaintDetail> ComplaintDetail { get; set; }

        public DbSet<ContentManagement> ContentManagement { get; set; }
        public DbSet<ContentPicture> ContentPicture { get; set; }
        public DbSet<ChargesType> ChargesType { get; set; }
        public DbSet<VisitorParkingCharge> VisitorParkingCharge { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "System"; // Replace with actual user
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "System"; // Replace with actual user
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
