using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EmployeeManagement.Security
{
    public class CanEditOnlyOtherAdminRolesAndClaimHandler : AuthorizationHandler<ManageRoleAndClaimRequirement>
    {

        

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageRoleAndClaimRequirement requirement)
        {

            Console.WriteLine("CanEditOnlyOtherAdminRolesAndClaimHandler");
            var authfilterContext = context.Resource as DefaultHttpContext;

            if (authfilterContext == null)
            {
                return Task.CompletedTask;
            }
            //Console.WriteLine("ClaimTypes.NameIdentifier");
            //Console.WriteLine(ClaimTypes.NameIdentifier);
            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;


            //Console.WriteLine("loggedInAdminId");
            //Console.WriteLine(loggedInAdminId);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            string adminIdBeingEdit = authfilterContext.HttpContext.Request.Query["userId"];




            //Console.WriteLine("adminIdBeingEdit");
            //Console.WriteLine(adminIdBeingEdit);

            //Console.WriteLine("loggedInAdminId");
            //Console.WriteLine(loggedInAdminId);


            Console.WriteLine(context.User.IsInRole("systemAdminsitrator"));
            Console.WriteLine(context.User.HasClaim(c => c.Type == "EditRole"));
            Console.WriteLine(adminIdBeingEdit.ToLower() != loggedInAdminId.ToLower());

            if (context.User.IsInRole("systemAdminsitrator") && context.User.HasClaim(c => c.Type == "EditRole") &&
                    adminIdBeingEdit.ToLower() != loggedInAdminId.ToLower()
                )
            {
                //Console.WriteLine("test");
                context.Succeed(requirement);
            }
            else {
                context.Fail();
            }
            return Task.CompletedTask;

        }
    }
}
