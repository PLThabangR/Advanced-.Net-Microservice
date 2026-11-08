using Application.features.User;
using Microsoft.AspNetCore.Identity;
//my response wrapper package
using ResponseWrapper.Wrappers;
using ResponseWrapper.Models.Requests.Identity;
//the compiler get confused between the namespace and class name since they are the same in our packages
using AppResponse = ResponseWrapper.Wrappers.ResponseWrapper;
using Infrastructure.Models;
using Infrastructure.Constants;
using Microsoft.Identity.Client;
using ResponseWrapper.Models.Responses.Identity;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Azure;


namespace Infrastructure.Services
{
    public class UserService : IUserService
    {   
        //We need userManager to create users
        private readonly UserManager<ApplicationUser> userManager;

        //We must include a interface or contract to deal with roles
        private readonly RoleManager<ApplicationRole> roleManager;
            
        //Inject the UserManager using the ApplicationUser
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {   
            //This handle users
            this.userManager = userManager;
            //this handle user roles
            this.roleManager = roleManager;
        }

        public async Task<IResponseWrapper> RegisterUserAsync(UserRegistrationRequest userRegistration)
        {   
            //Check if user exists in the database
            var userWithSameEmail = await userManager.FindByEmailAsync(userRegistration.Email);

            //If userWithSameEmail is not null 
            if (userWithSameEmail is not null) return await  AppResponse.FailAsync("Email already taken");

            //Create new user no user exists 
            var newUser = new ApplicationUser
            {
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Email = userRegistration.Email,
                UserName = userRegistration.Username,
                PhoneNumber = userRegistration.PhoneNumber,
                IsActive = userRegistration.ActivateUser,
                EmailConfirmed = userRegistration.AutoConfirmEmail

            };

            //Passwordhash
            var password = new PasswordHasher<ApplicationUser>();
            newUser.PasswordHash=password.HashPassword(newUser,userRegistration.Password);

            //We create the user in the database
            var identityUserResult = await userManager.CreateAsync(newUser);

            if (identityUserResult.Succeeded)
            {   //assign role
                //Assign user to basic role
               var identityRoleResults= await userManager.AddToRoleAsync(newUser, AppRoles.Basic);

                if (identityRoleResults.Succeeded)
                {
                    return await AppResponse.SuccessAsync("User created Successfully");
                }
                return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityRoleResults));

            }
            //If there is any issure in creating user 
            return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityUserResult));

        }

       
        public async Task<IResponseWrapper> UpdateUserAsync(UpdateUserRequest userUpdate)
        {
            //Look user in database
            var userInDb = await userManager.FindByIdAsync(userUpdate.UserId);

            //check if user exist
            if (userInDb is not null)
            {
                //update user then 
                userInDb.FirstName= userUpdate.FirstName;
                userInDb.LastName = userInDb.LastName;
                userInDb.PhoneNumber = userInDb.PhoneNumber;

                
                var identityResults = await userManager.UpdateAsync(userInDb);
                if (identityResults.Succeeded)
                {
                    return await AppResponse.SuccessAsync("User updated Successfully");
                }
                //We are going to show the exact error
                return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityResults));

               
            }
          
            return await AppResponse.FailAsync("User does not exists");
        }


       

        public async Task<IResponseWrapper> GetUserByIdRequestAsync(string userId)
        {
            //Get user byID
            var userInDb = await userManager.FindByIdAsync(userId);

            if(userInDb is not null)
            { 
                   //mapping user
                var mappedUser = userInDb.Adapt<UserResponse>();

                //We are returning
                return await ResponseWrapper<UserResponse>.SuccessAsync(data: mappedUser);


            }
            //If we do not find any user
            return await AppResponse.FailAsync("User does not exists");

        }

        public async Task<IResponseWrapper> GetAllUsersAsync()
        {
            //Get all users from users db
            var usersInDb = await userManager.Users.ToListAsync();
            //If count is greater than zero which mean we have user or users to return
            if(usersInDb.Count > 0)
            {   //Map to list of users
                var mappedUser = usersInDb.Adapt<List<UserResponse>>();
                //Return users 
                //Data is not neccesaary because we have already mentioned the type as UserResponse
                return await ResponseWrapper<List<UserResponse>>.SuccessAsync(mappedUser);
            }
            //If we do not find any user
            return await AppResponse.FailAsync("No user were found");
        }

        public async Task<IResponseWrapper> ChangeUserPasswordAsync(ChangePasswordRequest changePassword)
        {
            //find user by ID
            var userInDb = await userManager.FindByIdAsync(changePassword.UserId);

            if(userInDb is not null)
            {       //Change the paaword and it will create the new hash
                var identityResult = await userManager.ChangePasswordAsync(userInDb, changePassword.CurrentPassword, changePassword.ConfirmNewPassword);
                //If change passed we return message to user
                if (identityResult.Succeeded) {
                    return await AppResponse.SuccessAsync(message: "User password updated");
                }
                //We are going to show the exact error
                return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityResult));

            }
            //If we do not find any user
            return await AppResponse.FailAsync("No user were found");
        }

        public async Task<IResponseWrapper> ChangeUserStatusAsync(ChangeUserStatusRequest changeUserStatus)
        { //find user by ID
            var userInDb = await userManager.FindByIdAsync(changeUserStatus.UserId);

            if (userInDb is not null)
            {      //Change status set the incoming value to is Active
                userInDb.IsActive = changeUserStatus.ActivateOrDeactivate;

                //Then update the user in the DB
                var identityResult = await userManager.UpdateAsync(userInDb);
                //If change passed we return message to user
                if (identityResult.Succeeded)
                    //Check if the user is activated or not and return the success message
                {   var msg = changeUserStatus.ActivateOrDeactivate ? "User activated successfully": "UserDeactivated successfully ";
                    return await AppResponse.SuccessAsync(msg);
                }
                //We are going to show the exact error description
                return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityResult));

            }
            //If we do not find any user
            return await AppResponse.FailAsync("User does not exist");

        }

        public async Task<IResponseWrapper> UpdateUserRolesAsync(UpdateUserRolesRequest updateUserRoles)
        {
            //find user by ID
            var userInDb = await userManager.FindByIdAsync(updateUserRoles.UserId);

            if (userInDb is not null)
            {
                //Updating of role assign permissions or claims
                //restrict one Admin user to alaways have admin previleges
                if (userInDb.Email == AppCredentials.Email)
                {
                    //We block you from change or updating this user
                    return await AppResponse.FailAsync(message: "User roles not permited");
                }

                //Obtain all roles for specific user 
                var currentAssignedRoles = await userManager.GetRolesAsync(userInDb);

                //We use a filter to check all tht roles that are check from the frontend 
                var rolesToBeAssigned = updateUserRoles.Roles.Where(role => role.IsAssignedToUser).ToList();

                //We remove the current or previous assigned and put the new one
                //we use a remove function and we pass the current user and current roles assigned
                var identityRemovingResult = await userManager.RemoveFromRolesAsync(userInDb,currentAssignedRoles);

                if (identityRemovingResult.Succeeded)
                {
                    //Add the new roles
                    //this will add role names using select
                    var identityAssigningResult = await userManager.AddToRolesAsync(userInDb, rolesToBeAssigned.Select(role => role.RoleName));

                    //verify
                    if (identityAssigningResult.Succeeded)
                    {
                        return await AppResponse.SuccessAsync(message: "User roles updated successfully ");
                    }
                    else
                    {
                        return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityAssigningResult));
                    }

                }
                //We are going to show the exact error description
                return await AppResponse.FailAsync(GetIdentityResultErrorDescription(identityRemovingResult));
            }


            //If we do not find any user
            return await AppResponse.FailAsync("User does not exist");


        }

        public async  Task<IResponseWrapper> GetUserRolesAsync(string userId)
        {
            //create a new object list 
            var userRolesViewModel = new List<UserRoleViewModel>();

            //Verification using usermanager
            //Find user by Id
            var userInDb = await userManager.FindByIdAsync(userId);

            if (userInDb is not null)
            {    //logic to get user roles
                //Find the roles use role manager to obtain all the roles
                var allRoles = await roleManager.Roles.ToListAsync();

                //loop through to check if role is assigned to user or not
                foreach(var role in allRoles)
                {
                    //Create a single user viewModel
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        RoleName = role.Name,
                        RoleDescription = role.Description
                    };
                    //Check if role is assigned to specific user
                    //this will return true and go inside the if statemaent
                    if (await userManager.IsInRoleAsync(userInDb, role.Name))
                    {
                        userRoleViewModel.IsAssignedToUser = true;
                    }
                    else
                    {
                        //Not currently assigned to user
                        userRoleViewModel.IsAssignedToUser = false;
                    }

                    //Go to the list of userRolesView model and add the current role
                    userRolesViewModel.Add(userRoleViewModel);

                }//end of foreach
                //Return the list of User role
                return await ResponseWrapper<List<UserRoleViewModel>>.SuccessAsync(userRolesViewModel);


            }
            //If we do not find any user
            return await AppResponse.FailAsync("User does not exist");

        }

        public async Task<IResponseWrapper> GetUserByEmailAsnc(string email)
        {
            //Find user by email
            var userInDb = await userManager.FindByEmailAsync(email);

            if (userInDb is not null)
            {      //Change status
                var mappedUser = userInDb.Adapt<UserResponse>();

                //Return the Users using the response wrapper of type userResponse
                return await ResponseWrapper<UserResponse>.SuccessAsync(mappedUser);


            }
            //If we do not find any user
            return await AppResponse.FailAsync("User does not exist");

        }

        //Descriptions are freindly error messages 
        private static List<string> GetIdentityResultErrorDescription(IdentityResult identityResult)
        {
            var errorDescriptions = new List<string>();
            foreach (var error in identityResult.Errors)
            {
                errorDescriptions.Add(error.Description);
            }
            return errorDescriptions;
        }
    }
}
