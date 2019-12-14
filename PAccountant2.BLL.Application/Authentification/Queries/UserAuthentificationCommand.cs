using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PAccountant2.BLL.Domain.Entities.User;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
using PAccountant2.BLL.Interfaces.Authentification;

namespace PAccountant2.BLL.Application.Authentification.Queries
{
    public class UserAuthentificationCommand: IRequest<UserAuthentificationViewItem>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public class UserAuthentificationCommandHandler : IRequestHandler<UserAuthentificationCommand,
                UserAuthentificationViewItem>
        {
            private readonly IAuthentificationDataService _authDataService;

            private readonly IMapper _mapper;

            public UserAuthentificationCommandHandler(IAuthentificationDataService authDataService, IMapper mapper)
            {
                _authDataService = authDataService;
                _mapper = mapper;
            }


            public async Task<UserAuthentificationViewItem> Handle(UserAuthentificationCommand request, CancellationToken cancellationToken)
            {
                var currentPassword = await _authDataService.GetPaswordByEmailAsync(request.Email);

                var user = _mapper.Map<UserEntity>(request);
                user.Password = currentPassword;

                var credentials = user.CreateCredentials();

                if (!credentials.IsPasswordCorrect(request.Password))
                {
                    throw new WrongCredentialsException(user.Email);
                }

                return new UserAuthentificationViewItem
                {
                    Token = string.Empty
                };
            }
        }
    }
}
