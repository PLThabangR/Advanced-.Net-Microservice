using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Constants.Authentication
{
    public record AppPermission(string Service, string Feature, string Action, string Group, string Description, bool isBasic = false)
    {
        //This is our helper method will be used to populate
        public string Name => NameFor(Service, Feature, Action);
        public static string NameFor(string service, string feature, string action)
        {   //this is how permissions are build 
            return $"Permission.{service}.{feature}.{action}";//Permission.Identity.User.Create
        }



    }
    //Now we are defining permisiions is a collections of permissions
    public class AppPermissions
    {

        private static readonly AppPermission[] all = [
            //For users 
            new(AppService.Identity,AppFeature.Users,AppAction.Create,AppRoleGroup.SystemAccess,"Create users"),
            new(AppService.Identity,AppFeature.Users,AppAction.Read,AppRoleGroup.SystemAccess,"Read users"),
            new(AppService.Identity,AppFeature.Users,AppAction.Update,AppRoleGroup.SystemAccess,"Update users"),
            new(AppService.Identity,AppFeature.Users,AppAction.Delete,AppRoleGroup.SystemAccess,"Delete users"),

            //Roles
           new(AppService.Identity,AppFeature.Roles,AppAction.Create,AppRoleGroup.SystemAccess,"Create roles"),
            new(AppService.Identity,AppFeature.Roles,AppAction.Read,AppRoleGroup.SystemAccess,"Read roles"),
            new(AppService.Identity,AppFeature.Roles,AppAction.Update,AppRoleGroup.SystemAccess,"Update roles"),
            new(AppService.Identity,AppFeature.Roles,AppAction.Delete,AppRoleGroup.SystemAccess,"Delete roles"),

            //User roles
             new(AppService.Identity,AppFeature.UserRoles,AppAction.Read,AppRoleGroup.SystemAccess,"Read User roles"),
            new(AppService.Identity,AppFeature.UserRoles,AppAction.Update,AppRoleGroup.SystemAccess,"Update User roles"),

            //RoleClams
            new(AppService.Identity,AppFeature.RoleClaims,AppAction.Read,AppRoleGroup.SystemAccess,"Read Role Claims/permmision"),
            new(AppService.Identity,AppFeature.RoleClaims,AppAction.Update,AppRoleGroup.SystemAccess,"Update Role Claims/permmision")

];


        ///let make this more helpfull
        ///Admin permission where is not basic 
        public static IReadOnlyList<AppPermission> AdminPermissions { get; } = new ReadOnlyCollection<AppPermission>(all.Where(permission => !permission.isBasic).ToArray());
        //Basic permissions
        public static IReadOnlyList<AppPermission> BasicPermissions { get; } = new ReadOnlyCollection<AppPermission>(all.Where(permission => permission.isBasic).ToArray());
        //All permissions
        public static IReadOnlyList<AppPermission> AllPermissions { get; } = new ReadOnlyCollection<AppPermission>(all);



    }
}
    

