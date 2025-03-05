using DB.Repositories;
using DB.EFModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DB.Repositories.Interfaces;
using DB.Profiles;

namespace DB
{
    public static class Program
    {
        public static IServiceCollection AddDBProject(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddRepository().AddDbContext<CSADbContext>(option => option.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection")));
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VisitorProfile));
            services.AddAutoMapper(typeof(FacilityProfile));
            services.AddAutoMapper(typeof(ComplaintProfile));
            services.AddAutoMapper(typeof(CommunityProfile));
            services.AddAutoMapper(typeof(ResidentProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IComplaintRepository, ComplaintRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            return services;
        }
    }
}
