using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Repository.Database
{
    public class LoginRepository : ILoginRepository
    {
        public Employee GetEmployee(string username)
        {
            throw new NotImplementedException();
        }
    }
}