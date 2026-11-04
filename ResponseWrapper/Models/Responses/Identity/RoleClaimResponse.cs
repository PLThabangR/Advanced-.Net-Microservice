using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Responses.Identity
{
    public class RoleClaimResponse
    {
        //A role can have multiple claims, so we need to have a list of claims that the role can have
        public RoleResponse Role { get; set; }
        public List<string> RoleClaims { get; set; }
    }
}
