using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PAccountantv2.Host.Api.Controllers
{
    [Route("api/authentification")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IMapper mapper;

        public AuthentificationController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}