using AuthLibrary.Constants.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace AuthLibrary.Attributes
{   
    public class MustHavePermissionAttribute: AuthorizeAttribute
    {
        public MustHavePermissionAttribute( string service,string feature,string action) 
        {
            //we call the method that build or permission
            //Policy comes from a base class we are inheriting AuthorizeAttribuste
            Policy = AppPermission.NameFor(service, feature, action);
        
        }
    }
}
