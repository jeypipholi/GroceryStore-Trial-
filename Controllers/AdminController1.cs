using GroceryStore.Data;
using GroceryStore.Models;
using GroceryStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext dbContext;

        

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext _dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            dbContext = _dbContext;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string email, string password, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }

            

            // Create the user
            var user = new IdentityUser { Email = email, UserName = email ,PasswordHash=password};
            var result = await _userManager.CreateAsync(user, password);
            
            await dbContext.SaveChangesAsync();

            if (result.Succeeded)
            {
                // Assign the user to the selected role
                await _userManager.AddToRoleAsync(user, role);
                return RedirectToAction("UserList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }


        public async Task<IActionResult> UserList()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new Dictionary<string, string>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles[user.Id] = roles.FirstOrDefault() ?? "No Role";
            }

            ViewBag.UserRoles = userRoles;
            return View(users);
        }
    }
}
