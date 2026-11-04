using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    //this will allow user to login
    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
