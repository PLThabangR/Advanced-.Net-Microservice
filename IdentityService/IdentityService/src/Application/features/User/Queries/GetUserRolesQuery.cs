using MediatR;
using ResponseWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.User.Queries
{
    public class GetUserRolesQuery:IRequest<IResponseWrapper>
    {
        public string UserId { get; set; }
    }

    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, IResponseWrapper>
    {
        private IUserService userService;

        public GetUserRolesHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IResponseWrapper> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await userService.GetUserRolesAsync(request.UserId);
        }
    }
}
