using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("/login")]
    public class AuthViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}