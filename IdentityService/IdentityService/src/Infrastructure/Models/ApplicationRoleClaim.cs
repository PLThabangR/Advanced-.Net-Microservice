using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
        //key is type string
    public class ApplicationRoleClaim:IdentityRoleClaim<string>
    {
        public string Description { get; set; }
        public string Group { get; set; }

    }
}
