using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    public class UpdateUserRequest
    {
        //Mirror of the IdentityUser class
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Username { get; set; }
        
        public int PhoneNumber { get; set; }

    


    }
}
