using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Models.Requests.Identity
{
    public  class TokenResponse
    {
        //This is waht we return to the user after they login or refresh their token
        public string Token { get; set; }
        //We do not want our users to be logged out this will auto refresh their token when it expires
        public string RefreshToken { get; set; }

        //Becuase refresh token have a longer expiry time than the access token, we need to know when the refresh token expires so we can log the user out
        public DateTime RefreshTokenExpiryTime { get; set; }


    }
}
