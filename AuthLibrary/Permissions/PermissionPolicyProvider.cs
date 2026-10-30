using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using AuthLibrary.Constants.Authentication;


namespace AuthLibrary.Permissions
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {   //creatiing a local variable
        public DefaultAuthorizationPolicyProvider FallBackPolicyProvider {  get; }


        //constructor
        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            //initialize
            FallBackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallBackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {   //return null if no permission
           return Task.FromResult<AuthorizationPolicy>(null);
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            //policy name is a permission
            //We must check the provided string
            if (policyName.StartsWith(AppClaim.Permission, StringComparison.OrdinalIgnoreCase))
            {
                //Create a requirement based on permission we found 
                var policy = new AuthorizationPolicyBuilder();
                //We are creating policy dynamically
                policy.AddRequirements(new PermissionRequirement(policyName));

                return Task.FromResult(policy.Build());

            }

            //No requirment are being satisfied
            return FallBackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
