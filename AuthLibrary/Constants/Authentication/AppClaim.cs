using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Constants.Authentication
{   //Help to create json web token
    public class AppClaim
    {
        public const string Permission = "permission";
        public const string Expiration = "exp";
        //Issuer a service that created the token
        public const string Issuer = "gateway";
    }
}
