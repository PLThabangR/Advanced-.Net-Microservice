using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    public  class UserRegistrationRequest
    {
        //Mirror of the IdentityUser class
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int PhoneNumber { get; set; }

        public bool AutoConfirmEmail { get; set; }

        public bool ActivateUser{ get; set; }







    }
}
