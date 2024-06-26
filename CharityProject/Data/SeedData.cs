using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using CharityProject.Models;

namespace CharityProject.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            string[] roleNames = { "Admin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@123";

            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            if (!context.Posts.Any())
            {
                var posts = new[]
                {
                    new Post { Title = "Post 1", Body = "This is the body of post 1.", DonationGoal = 1000 },
                    new Post { Title = "Post 2", Body = "This is the body of post 2.", DonationGoal = 2000 },
                    new Post { Title = "Post 3", Body = "This is the body of post 3.", DonationGoal = 3000 },
                    new Post { Title = "Post 4", Body = "This is the body of post 4.", DonationGoal = 4000 },
                    new Post { Title = "Post 5", Body = "This is the body of post 5.", DonationGoal = 5000 }
                };

                context.Posts.AddRange(posts);
                await context.SaveChangesAsync();
            }
        }
    }
}
