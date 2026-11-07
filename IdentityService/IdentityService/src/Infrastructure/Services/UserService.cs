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
            
        //Inject the UserManager using the ApplicationUser
        public UserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
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
            //Get all users
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

        public Task<IResponseWrapper> ChangeUserStatusAsync(ChangeUserStatusRequest changeUserStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseWrapper> UpdateUserRolesAsync(UpdateUserRolesRequest updateUserRoles)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseWrapper> GetUserRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseWrapper<UserResponse>> GetUserByEmailAsnc(string email)
        {
            throw new NotImplementedException();
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
