using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Services
{
    public class LoginService : ILoginService
    {
        public Employee Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
