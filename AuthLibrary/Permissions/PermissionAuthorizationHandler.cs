using AuthLibrary.Constants.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Permissions
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {   
        //Default constructor
        public PermissionAuthorizationHandler() { }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            //Do evaluation on user context check if the have a claim
            if(context.User is null)
            {   //This means you have not yet loggedin
                await Task.CompletedTask;
            }
            var permissions = context.User.Claims
                .Where(claim => claim.Type == AppClaim.Permission &&
                claim.Value == requirement.Permission &&
                claim.Issuer == AppClaim.Issuer);

            ///If the is any that meet criteria 
            if (permissions.Any()) {
                //we mark our context as succees it passed the requirement 
                context.Succeed(requirement);
                //task completed
                await Task.CompletedTask;
            }
           
        }
    }
}
