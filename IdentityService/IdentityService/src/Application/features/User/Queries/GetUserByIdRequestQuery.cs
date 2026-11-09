using MediatR;
using ResponseWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.User.Queries
{
    public class GetUserByEmailQuery : IRequest<IResponseWrapper>
    {
        public string UserId { get; set; }
        
    }

    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, IResponseWrapper>
    {
        private IUserService userService;

        public GetUserByEmailHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IResponseWrapper> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await userService.GetUserByIdRequestAsync(request.UserId);
        }
    }
}
