using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ShopCar;
using System.IO;


namespace DataAccessLayer
{
   public class DesignTimeDbContextFactory : 
        IDesignTimeDbContextFactory<AppDBContent>
   {
        public AppDBContent CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDBContent>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDBContent(builder.Options);
        }
    }
 }