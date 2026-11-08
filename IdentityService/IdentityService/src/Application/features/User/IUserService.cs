using ResponseWrapper.Models.Requests.Identity;
using ResponseWrapper.Models.Responses.Identity;
using ResponseWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.User
{
    public interface IUserService
    {
        //we use this method as a contract to register
        Task<IResponseWrapper> RegisterUserAsync(UserRegistrationRequest userRegistrationRequest);
        Task<IResponseWrapper> UpdateUserAsync(UpdateUserRequest userUpdate);
        Task<IResponseWrapper> GetUserByIdRequestAsync(string userId);
        Task<IResponseWrapper> GetAllUsersAsync();
        Task<IResponseWrapper> ChangeUserPasswordAsync(ChangePasswordRequest changePassword);
        Task<IResponseWrapper> ChangeUserStatusAsync(ChangeUserStatusRequest changeUserStatus);
        Task<IResponseWrapper> UpdateUserRolesAsync(UpdateUserRolesRequest updateUserRoles);
        Task<IResponseWrapper> GetUserRolesAsync(string userId);
        Task<IResponseWrapper> GetUserByEmailAsnc(string email);
    }
}
