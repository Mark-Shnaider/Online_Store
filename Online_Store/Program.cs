using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Logic;
using Common.Contracts;
using Common.Models.Entities.Identity;

namespace Online_Store
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                        .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                //try
                //{
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                    var unitOfWork = services.GetRequiredService<IUnitOfWork>();
                    await SeedContextAsync.Seed(unitOfWork, loggerFactory, userManager, rolesManager);
                //}
                //catch (Exception ex)
                //{
                //    var logger = loggerFactory.CreateLogger<Program>();
                //    logger.LogError(ex, "An error occurred seeding the DB.");
                //}
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
