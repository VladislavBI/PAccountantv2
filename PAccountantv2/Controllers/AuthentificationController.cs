using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountantv2.Host.Api.Infrastructure.Helper;
using PAccountantv2.Host.Api.Infrastructure.Models;
using PAccountantv2.Host.Api.ViewModels.Authentification;

namespace PAccountantv2.Host.Api.Controllers
{
    [Authorize]
    [Route("api/authentification")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthentificationService authService;
        private readonly AppSettings appSettings;

        public AuthentificationController(IMapper mapper,
            IAuthentificationService authService,
            IOptions<AppSettings> appSettings)
        {
            this.mapper = mapper;
            this.authService = authService;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser(RegistrationViewModel model)
        {
            var registerItem = mapper.Map<RegisterViewItem>(model);
            authService.RegisterUser(registerItem);

            return Ok();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel model)
        {
            var userItem = mapper.Map<LoginViewItem>(model);
            try
            {
                await authService.LoginUserAsync(userItem);
            }
            catch (WrongCredentialsException e)
            {
                return BadRequest(e.Message);
            }

            var token = new TokenHelper().CreateToken(userItem.Email, appSettings.Secret);
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