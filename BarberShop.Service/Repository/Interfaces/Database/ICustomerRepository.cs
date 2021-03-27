using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Repository.Interfaces
{
    public interface ICustomerRepository : ICRUD<Customer, Customer, string>
    {
        List<Customer> GetAllCustomers();
    }
}