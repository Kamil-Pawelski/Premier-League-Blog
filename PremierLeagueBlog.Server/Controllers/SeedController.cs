using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeagueBlog.Server.Data;
using PremierLeagueBlog.Server.Data.Models;

namespace PremierLeagueBlog.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [Controller]
    public class SeedController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public SeedController(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> CreateDefaultUsers()
        {
            string role_RegisteredUser = "RegisteredUser";
            string role_Administrator = "Administrator";

            if (await _roleManager.FindByNameAsync(role_RegisteredUser) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));
            }

            if (await _roleManager.FindByNameAsync(role_Administrator) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }

            var addedUserList = new List<IdentityUser>();

            var email_Admin = "admin@email.com";

            if (await _userManager.FindByNameAsync(email_Admin) == null)
            {
                var user_Admin = new IdentityUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_Admin,
                    Email = email_Admin,
                };


                await _userManager.CreateAsync(user_Admin,
                    _configuration["DefaultPasswords:Administrator"]!);

                await _userManager.AddToRoleAsync(user_Admin, role_RegisteredUser);
                await _userManager.AddToRoleAsync(user_Admin, role_Administrator);

                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;

                addedUserList.Add(user_Admin);
            }
            var email_User = "user@email.com";
            if (await _userManager.FindByEmailAsync(email_User) == null)
            {
                var user_User = new IdentityUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_User,
                    Email = email_User,
                };

                await _userManager.CreateAsync(user_User,
                    _configuration["DefaultPasswords:RegisteredUser"]!);

                await _userManager.AddToRoleAsync(user_User,
                    role_RegisteredUser);
                user_User.EmailConfirmed = true;
                user_User.LockoutEnabled = false;

                addedUserList.Add(user_User);
            }

            if (addedUserList.Count > 0)
            {
                await _context.SaveChangesAsync();
            }

            return new JsonResult(new
            {
                Count = addedUserList.Count,
                Users = addedUserList
            });

        }
    }
}
