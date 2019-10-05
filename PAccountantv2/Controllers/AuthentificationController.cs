using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAccountantv2.Host.Api.ViewModels.Authentification;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/authentification")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IMapper mapper;

        public AuthentificationController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser(RegistrationViewModel model)
        {
            return Ok();
        }
    }
}