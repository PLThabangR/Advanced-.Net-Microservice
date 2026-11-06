using ResponseWrapper.Models.Requests.Identity;
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
    }
}
