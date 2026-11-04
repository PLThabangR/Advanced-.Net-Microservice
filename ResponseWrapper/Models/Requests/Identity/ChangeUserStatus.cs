using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    public class ChangeUserStatusRequest
    {
        public string UserId { get; set; }
        public bool ActivateOrDeactivate { get; set; }
    }
}
