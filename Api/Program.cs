using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Text;
using YourNamespace.Services;
using DB;
using DB.EFModel;
using Api.Helpers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
builder.Services.AddDbContext<CSADbContext>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Scoped);
// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"], // Ensure this matches `iss` in token
            ValidAudience = jwtSettings["Audience"], // Ensure this matches `aud` in token
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
        };
    });

builder.Services.AddBusinessLogic().AddDBProject(builder.Configuration);
// Register Services
//builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<IFacilityService, FacilityService>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IResidentService, ResidentService>();
builder.Services.AddScoped<IPasswordPolicyService, PasswordPolicyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IRoleMenuPermissionService, RoleMenuPermissionService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IResidentAccessHistoryService, ResidentAccessHistoryService>();
builder.Services.AddScoped<IResidentUploadHistoryService, ResidentUploadHistoryService>();


//builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Keys"))
    .SetApplicationName("MyApp");
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSA API", Version = "v1" });

    // Enable the Authorize button
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer {your-token}'"
    });

    // Apply the security globally
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<CSADbContext>(options =>
    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Log to Console
    .WriteTo.File("Logs/app_log.txt", rollingInterval: RollingInterval.Day) // Log to File
    .CreateLogger();

// Use Serilog instead of default logging
builder.Host.UseSerilog();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()  // Allows all origins
                  .AllowAnyMethod()  // Allows all HTTP methods (GET, POST, etc.)
                  .AllowAnyHeader(); // Allows all headers
        });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
