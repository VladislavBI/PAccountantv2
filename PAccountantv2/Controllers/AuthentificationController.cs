using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountant2.Host.Domain.Models;
using PAccountant2.Host.Domain.ViewModels.Authentification;
using PAccountantv2.Host.Api.Infrastructure.Helper;

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

        public AuthentificationController(IMapper mapper,
            IAuthentificationService authService,
            ITokenService tokenService,
            IOptions<JwtSettings> jwtSettings)
        {
            this._mapper = mapper;
            this._authService = authService;
            this._jwtSettings = jwtSettings.Value;
            this._tokenService = tokenService;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegistrationViewModel model)
        {
            var registerItem = _mapper.Map<RegisterViewItem>(model);
            var newUserEmail = await _authService.RegisterUserAsync(registerItem);

            return Ok(newUserEmail);
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel model)
        {
            var userItem = _mapper.Map<LoginViewItem>(model);
            try
            {
                await _authService.LoginUserAsync(userItem);
            }
            catch (WrongCredentialsException e)
            {
                return BadRequest(e.Message);
            }

            var token = _tokenService.CreateToken(userItem.Email, _jwtSettings.Key );
            return Ok(token);
        }

        [Route("test")]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}