using MediatR;
using ResponseWrapper.Models.Requests.Identity;
using ResponseWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.User.Commands
{
    public class UpdateUserRolesCommand:IRequest<IResponseWrapper>
    {
      public  UpdateUserRolesRequest UpdateUserRoles { get; set; }
    }

    public class UpdateUserRolesHander : IRequestHandler<UpdateUserRolesCommand, IResponseWrapper>
    {
        private readonly IUserService userService;
        public Task<IResponseWrapper> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            return userService.UpdateUserRolesAsync(request.UpdateUserRoles);
            
        }
    }
}
