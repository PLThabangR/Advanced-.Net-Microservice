using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Responses.Identity
{
  public class UserResponse
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailConfirmed { get; set; }
      public int PhoneNumber { get; set; }
       // public List<string> Roles { get; set; }
    }
}
