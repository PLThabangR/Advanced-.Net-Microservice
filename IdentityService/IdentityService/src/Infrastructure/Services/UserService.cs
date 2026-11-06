using Application.features.User;
using Microsoft.AspNetCore.Identity;
//my response wrapper package
using ResponseWrapper.Wrappers;
using ResponseWrapper.Models.Requests.Identity;
//the compiler get confused between the namespace and class name since they are the same in our packages
using AppResponse = ResponseWrapper.Wrappers.ResponseWrapper;
using Infrastructure.Models;
using Infrastructure.Constants;


namespace Infrastructure.Services
{
    public class UserService : IUserService
    {   
        //We need userManager to create users
        private readonly UserManager<IdentityUser> userManager;

        public UserService(UserManager<IdentityUser> userManager)
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

        private static List<string> GetIdentityResultErrorDescription(IdentityResult identityResult)
        {
            var errorDescriptions = new List<string>();
            foreach(var error in identityResult.Errors)
            {
                errorDescriptions.Add(error.Description);
            }
            return errorDescriptions;
        }
    }
}
