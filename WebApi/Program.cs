using BussinesLogic.Data;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostserver = CreateHostBuilder(args).Build();
            using (var ambiente = hostserver.Services.CreateScope())
            {
                var services = ambiente.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>(); 

                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var context = services.GetRequiredService<FitnessFoodContext>();
                    context.Database.Migrate();
                    SeedUser.InsertData(context, userManager).Wait();
                }
                catch (Exception e)
                {
                    var logging = loggerFactory.CreateLogger<Program>();
                    logging.LogError(e, "Ocurrio un error en la migracion");
                }
            }
            hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
