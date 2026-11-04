using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class StartUp
    {

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding AddDbContext to the service collection and configuring it to use SQL Server with the connection string from the configuration.
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //get connection string from appsettings.json file and use it to connect to the database.
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt =>
                {   //Additional options for SQL Server can be configured here. For example, we can enable retry on failure for transient errors.
                    //Enable retry on failure for transient errors.
                    //table name and schema name for migrations history table configured 
                    opt.MigrationsHistoryTable("EFMigrations", "EFCore");

                    opt.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                });
            });


            return services;
        }
    }
}
