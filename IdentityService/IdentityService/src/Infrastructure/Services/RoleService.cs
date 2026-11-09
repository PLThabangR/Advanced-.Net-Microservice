
using Application.features.Roles;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using ResponseWrapper.Models.Requests.Identity;
using ResponseWrapper.Wrappers;
//the compiler get confused between the namespace and class name since they are the same in our packages
using AppResponse = ResponseWrapper.Wrappers.ResponseWrapper;
//Constants
using Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Mapster;
using ResponseWrapper.Models.Responses.Identity;

namespace Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        //We need contract from Idetity and user service
        private readonly RoleManager<ApplicationRole>  roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleService(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IResponseWrapper> CreateRoleAsync(CreateRoleRequest createRole)
        {//Check if role name exists
            var roleInDb = await roleManager.FindByNameAsync(createRole.Name);
            if(roleInDb is not null)
            {
                return await AppResponse.FailAsync("Role already taken");
            }
            //Create new role
            var newRole = new ApplicationRole
            {
                Name = createRole.Name,
                Description = createRole.Description
            };

            var identityRoleResult = await roleManager.CreateAsync(newRole);
            if (identityRoleResult.Succeeded)
            {
                return await AppResponse.SuccessAsync("Role created Successfully");
            }
            //Return this if there was any error
            return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityRoleResult));

        }

        public async Task<IResponseWrapper> DeleteRoleAsync(string roleId)
        {   //Verify if it exists
            var roleInDb = await roleManager.FindByIdAsync(roleId);

            //If role is not null we go inside the if statement
           if(roleInDb is not null)
            {
                //If role is not admin 
                //We do not want user to delete our default admin role
                if (roleInDb.Name != AppRoles.Admin)
                {
                    //Get all users
                    var allUsers = await userManager.Users.ToListAsync();
                    //We check the current role if user is assigned we failed it 
                    foreach (var user in allUsers)
                    {       
                        if (await userManager.IsInRoleAsync(user, roleInDb.Name))
                        {   //If the role is currently assigned to user it cannot be deleted
                            return await AppResponse.FailAsync($"Role: {roleInDb.Name} is currently assigned to a user");
                        }
                    }//end of for

                    //If the role is not assigned to any user delete
                    var identityRoleResult = await roleManager.DeleteAsync(roleInDb);
                    if (identityRoleResult.Succeeded)
                    {   //show this if the deletion was successful
                        return await AppResponse.SuccessAsync("Role Deleted Successfully");
                    }
                    //Return this if there was any error
                    return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityRoleResult));
                }//End of If
                return await AppResponse.FailAsync("Cannot delete admin role");
            }

            return await AppResponse.FailAsync("Role does not exists");
        }

        public Task<IResponseWrapper> GetPermissionsAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponseWrapper> GetRoleAsync()
        {
            var allRoles = await roleManager.Roles.ToListAsync();
            //Check if lenth is greater than zero
            if (allRoles.Count>0)
            {
                //map role to response 
                var mappedRoles = allRoles.Adapt<RoleResponse>();

                //Return the role using the response wrapper of type rolerResponse
                return await ResponseWrapper<RoleResponse>.SuccessAsync(mappedRoles);
            }

            return await AppResponse.FailAsync("No roles were found");
        }

        public async Task<IResponseWrapper> GetRoleByIdAsync(string roleId)
        {
            var roleInDb = await roleManager.FindByIdAsync(roleId);
            if (roleInDb is not null)
            {
                //map role to response 
                var mappedRole = roleInDb.Adapt<RoleResponse>();

                //Return the role using the response wrapper of type rolerResponse
                return await ResponseWrapper<RoleResponse>.SuccessAsync(mappedRole);
            }

            return await AppResponse.FailAsync("Role does not exists");
        }

        public Task<IResponseWrapper> UpdateRoleAsync(UpdateRolerequest updateRole)
        {
           
        }

        public Task<IResponseWrapper> UpdateRolePermissionAsync(UpdateRoleClaimsRequest updateRoleClaims)
        {
            throw new NotImplementedException();
        }


        //Descriptions are freindly error messages 
        private static List<string> GetIdentityResultErrorDescription(IdentityResult identityResult)
        {
            //Create a list of errorDescr
            var errorDescriptions = new List<string>();
            foreach (var error in identityResult.Errors)
            { //Add all error descriptions
                errorDescriptions.Add(error.Description);
            }
            //Return the descriptions
            return errorDescriptions;
        }
    }
}
