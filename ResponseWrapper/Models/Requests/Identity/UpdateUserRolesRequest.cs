using ResponseWrapper.Models.Responses.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{   //A user can be assigned to multiple roles, so we need to have a list of roles that the user can be assigned to
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public List<UserRoleViewModel> Roles { get; set; }
    }
}
