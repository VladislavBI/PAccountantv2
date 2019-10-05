using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountantv2.Host.Api.ViewModels.Authentification;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/authentification")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthentificationService authService;

        public AuthentificationController(IMapper mapper,
            IAuthentificationService authService)
        {
            this.mapper = mapper;
            this.authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser(RegistrationViewModel model)
        {
            var registerItem = mapper.Map<RegisterViewItem>(model);
            authService.RegisterUser(registerItem);

            return Ok();
        }
    }
}