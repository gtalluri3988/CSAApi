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
            services.AddAutoMapper(typeof(PasswordPolicyProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(RoleProfile));
            services.AddAutoMapper(typeof(RoleMenuPermission));
            services.AddAutoMapper(typeof(MenuProfile));
            services.AddAutoMapper(typeof(ContentProfile));
            services.AddAutoMapper(typeof(CardProfile));
            services.AddAutoMapper(typeof(PaymentProfile));
            services.AddAutoMapper(typeof(EventProfile));
            services.AddAutoMapper(typeof(ResidentAccessHistoryProfile));
            services.AddAutoMapper(typeof(ResidentUploadHistoryProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IComplaintRepository, ComplaintRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<IPasswordPolicyRepository, PasswordPolicyRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IResidentAccessHistoryRepository, ResidentAccessHistoryRepository>();
            services.AddScoped<IResidentUploadHistoryRepository, ResidentUploadHistoryRepository>();
            return services;
        }
    }
}
