using EmployeeManagement.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [AllowAnonymous]
    public class RoleanduserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<EmployeeManagement.Models.ApplicationUser> usermanager;

        public RoleanduserController(RoleManager<IdentityRole> roleManager , UserManager<EmployeeManagement.Models.ApplicationUser> _usermanager)
        {
            this.roleManager = roleManager;
            this.usermanager = _usermanager;
        }

        public async Task<String> all()
        {
            String _user = "";

            foreach (var user in usermanager.Users)
            {
                _user += user.Id + " : " + user.Email + "\n";
            }
            return _user;
        }
        public async Task<String> index(String roleName)
        {
            String _user= "";
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return "error ,No Role Name";
            }
            var users = await usermanager.GetUsersInRoleAsync(roleName);
            foreach (var user in users)
            {
                _user += user.Id + " : " + user.Email + "\n";
            }
            return _user;
        }
        public async Task<String> addUserToRole()
        {
            String userId = "08ae6a08-83f6-4579-a960-a2d589bc9e97";
            var user = await usermanager.FindByIdAsync(userId);
            await usermanager.AddToRoleAsync(user, "systemAdminsitrator");
            userId = "850c8d44-8f82-4c2e-b39f-e51583f6be11";
            user = await usermanager.FindByIdAsync(userId);
            await usermanager.AddToRoleAsync(user, "systemAdminsitrator");
            return "added";
        }
        public async Task<String> RomoveUsersInRole()
        {
            var userId = "850c8d44-8f82-4c2e-b39f-e51583f6be11";
            var user = await usermanager.FindByIdAsync(userId);
            if (await usermanager.IsInRoleAsync(user, "systemAdminsitrator")) { 
            
                await usermanager.RemoveFromRoleAsync(user, "systemAdminsitrator");
            }

            return "test";
        }


        public async Task<String> RemoveRole()
        {
            return "test";
        }
    }
}
