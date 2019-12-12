using AutoMapper;
using MediatR;
using PAccountant2.BLL.Domain.Entities.User;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using System.Threading;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Application.Authentification.Commands
{
    public class RegisterUserCommand :IRequest<string>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
        {
            private readonly IAuthentificationDataService _dataService;
            
            private readonly IMapper _mapper;

            public RegisterUserCommandHandler(IAuthentificationDataService dataService, IMapper mapper)
            {
                _dataService = dataService;
                _mapper = mapper;
            }

            public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                if (await _dataService.CheckUserExistsAsync(request.Email))
                {
                    throw new UserExistsException(request.Email);
                }

                var user = _mapper.Map<UserEntity>(request);
                var credentials = user.CreateCredentials();

                var registerModel = _mapper.Map<RegisterDataItem>(credentials);
                var newUserEmail = await _dataService.RegisterUserAsync(registerModel);

                return newUserEmail;
            }
        }
    }
}
