using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICustomerService : ICRUDService<Customer, Customer>
    {
        void CreatePhone(Customer customerPhone);
        void DeletePhone(string phone);
        List<string> ReadPhone(int id);
        Customer UpdatePhone(Customer customerPhone);
    }
}