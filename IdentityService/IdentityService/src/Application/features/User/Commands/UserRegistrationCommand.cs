using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//my response wrapper package
using ResponseWrapper.Wrappers;
using ResponseWrapper.Models.Requests.Identity;
//
namespace Application.features.User.Commands
{
   //Every mediat request must have a handler
    public class UserRegistrationCommand : IRequest<IResponseWrapper>
    {
        public UserRegistrationRequest userRegistrationRequest { get; set; }

    }

    ///This is the handler
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, IResponseWrapper>
    {
        private readonly IUserService userService;
        
        //Inject the user IUserService
        public UserRegistrationCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IResponseWrapper> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
                //
            return await userService.RegisterUserAsync(request.userRegistrationRequest);
        }
    }
}
