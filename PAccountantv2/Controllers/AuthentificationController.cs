using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PAccountant2.BLL.Application.Accounting.Commands;
using PAccountant2.BLL.Application.Authentification.Commands;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountant2.Host.Domain.Models;
using PAccountant2.Host.Domain.ViewModels.Authentification;
using PAccountantv2.Host.Api.Infrastructure.Helper;
using System.Threading.Tasks;
using PAccountant2.BLL.Application.Authentification.Queries;

namespace PAccountantv2.Host.Api.Controllers
{
    [Authorize]
    [Route("api/authentification")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthentificationService _authService;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly IMediator _mediator;

        public AuthentificationController(IMapper mapper,
            IAuthentificationService authService,
            ITokenService tokenService,
            IOptions<JwtSettings> jwtSettings, IMediator mediator)
        {
            _mapper = mapper;
            _authService = authService;
            _jwtSettings = jwtSettings.Value;
            _tokenService = tokenService;
            _mediator = mediator;
        }

        /// <summary>
        /// Registration of new user
        /// </summary>
        /// <param name="model">new user params</param>
        /// <response code="200">new users email</response>
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegistrationViewModel model)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(model);
            var newUserEmail = await _mediator.Send(registerCommand);

            var newAccingId = await _mediator.Send(new CreateAccountingCommand {UserEmail = newUserEmail});
            return Ok(new
            {
                newUserEmail, newAccingId
            });
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="model">User's credentials</param>
        /// <response code="200">login token</response>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel model)
        {
            var userCommand = _mapper.Map<UserAuthentificationCommand>(model);
            var result = await _mediator.Send(userCommand);

            var token = _tokenService.CreateToken(userCommand.Email, _jwtSettings.Key);
            var tokenModel = new TokenViewModel
            {
                Token = token
            };

            return Ok(tokenModel);
        }

    }
}