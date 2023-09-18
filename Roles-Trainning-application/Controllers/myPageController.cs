using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roles_Trainning_application.Models;

namespace Roles_Trainning_application.Controllers
{
    public class myPageController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public myPageController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            var roles = _roleManager.Roles.ToList();

            if (roles.Count == 0)
            {
                return View(); // Return the view without any roles if none are registered.
            }

            var userRoles = roles.Select(r => new UserRole { RoleName = r.Name }).ToList();
            return View(userRoles);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRole model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = model.RoleName };
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index"); // Redirect to a page that lists all roles.
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
