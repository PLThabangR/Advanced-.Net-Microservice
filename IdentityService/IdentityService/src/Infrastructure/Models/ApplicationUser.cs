using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    //We are inheriting from IdentityUser class to add more properties to the user class in future if needed.
    public class ApplicationUser:IdentityUser
    {

        //We can add more properties to the user class in future if needed. For example,
        //we can add FirstName and LastName properties to the user class.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //We can also add a property to store the refresh token for the user.
        //if user token expires,
        //we can use the refresh token to get a new access token without asking the user to login again.
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        //Other user can be turned off by admin,
        //so we can add a property to check if the user is active or not.
        public bool IsActive { get; set; } = true;


    }
}
