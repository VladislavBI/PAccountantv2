﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PAccountantv2.Host.Api.Controllers
{
    [AllowAnonymous]
    [Route("/auth")]
    public class AuthViewController : Controller
    {
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Need to remove this later
        /// </summary>
        /// <returns></returns>
        [Route("wheel")]
        [HttpGet]
        public IActionResult Wheel()
        {
            return View();
        }
    }
}