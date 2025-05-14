using DB.EFModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace DB.EFModel
{


    public class CSADbContextFactory : IDesignTimeDbContextFactory<CSADbContext>
    {
        public CSADbContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CSADbContext>();
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new CSADbContext(optionsBuilder.Options);
        }
    }
}
