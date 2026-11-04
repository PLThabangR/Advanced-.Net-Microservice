using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Responses.Identity
{
    public class RoleClaimViewModel
    {
        public string RoleId { get; set; }
        //Claim type is the name of the claim, for example "Permission", "Role", "Email", etc.
        //Is created in our Constants/ClaimTypes.cs file, and is used to identify the claim in the database
        public string ClaimType { get; set; }
        //Claim value is the value of the claim, for example "CanViewUsers", "Admin", "
        public string ClaimValue { get; set; }
        public string Description { get; set; }

        public string Group { get; set; }
        public bool IsAssignedToRole { get; set; }


    }
}
