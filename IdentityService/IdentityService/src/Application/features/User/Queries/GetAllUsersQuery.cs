using MediatR;
using ResponseWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.User.Queries
{
    public class GetAllUsersQuery:IRequest<IResponseWrapper>
    {
        //No parameter required since we will just return all users from DB
    }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IResponseWrapper>
    {
        private IUserService userService;

        public GetAllUsersHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public Task<IResponseWrapper> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return userService.GetAllUsersAsync();
        }
    }

}
