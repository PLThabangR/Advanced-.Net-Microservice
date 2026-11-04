using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Responses.Identity
{
    //SHow the roles of the user
    public class UserRoleViewModel
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsAssignedToUser { get; set; }
    }
}
