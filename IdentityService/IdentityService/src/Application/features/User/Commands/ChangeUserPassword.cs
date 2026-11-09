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
    public class ChangeUserPasswordCommand: IRequest<IResponseWrapper>
    {
        public ChangePasswordRequest ChangePassword { get; set; }


    }

    public class ChangeUserPasswordHandler : IRequestHandler<ChangeUserPasswordCommand, IResponseWrapper>
    {
        private readonly IUserService userservice;

        public ChangeUserPasswordHandler(IUserService userservice)
        {
            this.userservice = userservice;
        }

        public async Task<IResponseWrapper> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            return await userservice.ChangeUserPasswordAsync(request.ChangePassword);
            
        }
    }
}
