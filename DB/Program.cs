using BusinessLogic.Interfaces.Repositories;
using DB.EFModel;
using DB.Repositories;
using DB.Repositories.Interfaces;
using DB.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();
            return services;
        }
    }
}
