using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> _userManager)
        {
            if(_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    DisplayName = "Ayman Nashat",
                    Email = "ayman.nashat41@gmail.com",
                    UserName = "ayman.nashat",
                    PhoneNumber = "01152287677"
                    
                };

                await _userManager.CreateAsync(user ,"Test@123");
            }
        }
    }
}
