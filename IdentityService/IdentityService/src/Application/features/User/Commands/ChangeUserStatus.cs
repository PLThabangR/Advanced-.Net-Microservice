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
    public class ChangeUserStatusCommand:IRequest<IResponseWrapper>
    {   //This one come from our DTO
        public  ChangeUserStatusRequest ChangeUserStatus { get; set; }

    }

    public class ChangeUserStatusHandler : IRequestHandler<ChangeUserStatusCommand, IResponseWrapper>
    {
        private readonly IUserService userservice;

        public ChangeUserStatusHandler(IUserService userservice)
        {
            this.userservice = userservice;
        }

        public async Task<IResponseWrapper> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            return await userservice.ChangeUserStatusAsync(request.ChangeUserStatus);
        }
    }
}
