using EmployeeManagement.Migrations;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeManagement.Controllers
{
    public class ClaimController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<EmployeeManagement.Models.ApplicationUser> usermanager;



        ApplicationDbContext _context;
        public ClaimController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<EmployeeManagement.Models.ApplicationUser> _userManager)
        {
            this.roleManager = roleManager;
            this.usermanager = _userManager;
            this._context = context;
        }


        public async Task<String> addUserToClaim()
        {
            //String userId = "08ae6a08-83f6-4579-a960-a2d589bc9e97";
            String userId = "c5a9936a-40c0-4a2a-88ff-3b3e4d6076c5";
            var user = await usermanager.FindByIdAsync(userId);
            var havecreateRole = _context.identityUserClaims.Where(uc => uc.UserId == userId && uc.ClaimType == "createRole").FirstOrDefault();
            if (havecreateRole == null)
            {
                Claim createRole = new Claim("createRole", "Create Role");
                await usermanager.AddClaimAsync(user, createRole);
            }
            var haveEditRole = _context.identityUserClaims.Where(uc => uc.UserId == userId && uc.ClaimType == "EditRole").FirstOrDefault();
            if (haveEditRole == null)
            {

                Claim EditRole = new Claim("EditRole", "Edit Role");
                await usermanager.AddClaimAsync(user, EditRole);
            }
            //Claim ViewRole  = new Claim("ViewRole", "View Role");
            //Claim DeleteRole = new Claim("DeleteRole", "Delete Role");
            //await usermanager.AddClaimAsync(user,ViewRole);
            //await usermanager.AddClaimAsync(user,DeleteRole);

                return "added";
        }


        public async Task<String> getUserClaims()
        {
            var claim = "";
            //String userId = "08ae6a08-83f6-4579-a960-a2d589bc9e97";
            String userId = "c5a9936a-40c0-4a2a-88ff-3b3e4d6076c5";
            var user = await usermanager.FindByIdAsync(userId);
            var claims = await usermanager.GetClaimsAsync(user);
            foreach (var _cliam in claims)
            {
                claim += _cliam.Value + "\n";
            }
            return claim;
        }

        public async Task<String> removeUserClaims()
        {

            String userId = "08ae6a08-83f6-4579-a960-a2d589bc9e97";
            var user = await usermanager.FindByIdAsync(userId);
            var all = _context.identityUserClaims.ToList();
            //foreach (var item in all)
            //{
            //    Console.WriteLine(item.ClaimType);
            //}
            _context.identityUserClaims.RemoveRange(all);
            _context.SaveChanges();
            return "remove";
        }
    }
}
