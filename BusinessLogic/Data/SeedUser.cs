using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Data
{
    public class SeedUser
    {
        public static async Task InsertData(FitnessFoodContext fitnessFoodContext, UserManager<User> userManager)
        {

            if (!userManager.Users.Any())
            {
                var usuario = new User
                {
                    Name = "Jerson",
                    lastname = "Soto",
                    UserName = "ramirez",
                    Email = "jersonramirez97@gmail.com",
                    Addres = new Addres
                    {
                        Street = "Sucre 245",
                        City = "Lima",
                        Department = "Lima",
                    }
                };
                await userManager.CreateAsync(usuario, "JersonR2025$");


            }
        }
    }
}
