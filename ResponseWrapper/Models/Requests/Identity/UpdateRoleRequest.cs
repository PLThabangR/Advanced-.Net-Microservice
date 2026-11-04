using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    public class UpdateRolerequest
    {
        //We need to know which role we are updating, so we need the RoleId
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
