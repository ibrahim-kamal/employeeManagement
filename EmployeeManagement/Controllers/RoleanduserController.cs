using EmployeeManagement.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    //[AllowAnonymous]
    public class RoleanduserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<EmployeeManagement.Models.ApplicationUser> usermanager;

        public RoleanduserController(RoleManager<IdentityRole> roleManager , UserManager<EmployeeManagement.Models.ApplicationUser> _usermanager)
        {
            this.roleManager = roleManager;
            this.usermanager = _usermanager;
        }

        //[Authorize(Roles = "systemAdminsitrator")] // user or systemAdminsitrator
        //[Authorize(Roles = "systemAdminsitrator")][Authorize(Roles = "user")] // user and systemAdminsitrator
        public async Task<String> all()
        {
            String _user = "";

            foreach (var user in usermanager.Users)
            {
                _user += user.Id + " : " + user.Email + "\n";
            }
            return _user;
        }

        [Authorize(Roles = "systemAdminsitrator")]
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


        public async Task<String> editUser()
        {
            var userId = "850c8d44-8f82-4c2e-b39f-e51583f6be11";
            var usr = await usermanager.FindByIdAsync(userId);
            usr.Email = "superAdmin@gmail.com";
            await usermanager.UpdateAsync(usr);
            return "edit";
        }



        public async Task<String> deleteRole()
        {
            var role = await roleManager.FindByNameAsync("admin");
            await roleManager.DeleteAsync(role);
            return "delete";
        }

        public async Task<String> deleteUser()
        {
            var userId = "9e6927c8-a0a0-4076-889a-0407e24f58af";
            var usr = await usermanager.FindByIdAsync(userId);
            usr.Email = "superAdmin@gmail.com";
            await usermanager.DeleteAsync(usr);
            return "delete";
        }
    }
}
