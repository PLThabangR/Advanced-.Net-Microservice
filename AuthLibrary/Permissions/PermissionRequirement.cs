using Microsoft.AspNetCore.Authorization;


namespace AuthLibrary.Permissions
{
    public class PermissionRequirement:IAuthorizationRequirement 
    {
        public string Permission {  get; set; }
        //constructor
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
       
    }
}
