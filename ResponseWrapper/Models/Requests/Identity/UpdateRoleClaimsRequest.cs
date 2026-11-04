using ResponseWrapper.Models.Responses.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    public class UpdateRoleClaimsRequest
    {
        public string RoleId { get; set; }
        //We need to have a list of claims that the role can have,
        //so we need to have a list of claims that the role can be assigned
        public List<RoleClaimViewModel> RoleClaims { get; set; }

    }
}
