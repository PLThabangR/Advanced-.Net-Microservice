

using ResponseWrapper.Models.Requests.Identity;
using ResponseWrapper.Wrappers;

namespace Application.features.Roles
{
    public interface IRoleService
    {
        //Methods 
        Task<IResponseWrapper> CreateRoleAsync(CreateRoleRequest createRole);
        Task<IResponseWrapper> GetRoleAsync();
        Task<IResponseWrapper> UpdateRoleAsync(UpdateRolerequest updateRole);
        Task<IResponseWrapper> GetRoleByIdAsync(string roleId);
        Task<IResponseWrapper> DeleteRoleAsync(string roleId);
        Task<IResponseWrapper> GetPermissionsAsync(string roleId);

        Task<IResponseWrapper> UpdateRolePermissionAsync(UpdateRoleClaimsRequest updateRoleClaims);
    }
}
