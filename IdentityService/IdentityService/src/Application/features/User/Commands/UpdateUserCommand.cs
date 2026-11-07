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
    public class UpdateUserCommand: IRequest<IResponseWrapper>
    {
        public UpdateUserRequest updateUser { get; set; }

    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResponseWrapper>
    {
        private readonly IUserService userService;
            
        //Inject userservice
        public UpdateUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        //
        public async Task<IResponseWrapper> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {


            return await userService.UpdateUserAsync(request.updateUser);
        }


    }

}
