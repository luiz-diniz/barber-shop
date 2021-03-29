using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICustomerService : ICRUDService<Customer, Customer, string>
    {
    }
}