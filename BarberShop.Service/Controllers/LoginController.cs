using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        [Route("login/{username}&{password}")]
        public Employee Login(string username, string password)
        {
            return _loginService.Login(username, password);
        }

        [HttpPost]
        [Route("logout")]
        public void Logout(Employee employee)
        {
            _loginService.Logout(employee);
        }
    }
}
