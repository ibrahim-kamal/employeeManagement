using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EmployeeManagement.Security
{
    public class IssuperAdmin : AuthorizationHandler<ManageRoleAndClaimRequirement>
    {

        

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageRoleAndClaimRequirement requirement)
        {

            Console.WriteLine("IssuperAdmin");

            context.Succeed(requirement);
            return Task.CompletedTask;

        }
    }
}
