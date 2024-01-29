using EmployeeManagement.Migrations;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            IList<IdentityRole> roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult create() {
            return View();
        }
        [AllowAnonymous]
        public async Task<string> edit()
        {
            var role = roleManager.Roles.Where(r => r.Id == "40f15e6c-a8b3-4731-8161-bf67088f10cd").First();
            role.Name = "systemAdminsitrator";

            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
            return "test";
        }
        [HttpPost]
        public async Task<IActionResult> create(CreateRole model) {
            if (ModelState.IsValid) { 
            
                IdentityRole identity = new IdentityRole
                {
                    Name = model.name
                }; 
                var result = await roleManager.CreateAsync(identity);
                if (result.Succeeded) { 
                    return RedirectToAction("Index", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
