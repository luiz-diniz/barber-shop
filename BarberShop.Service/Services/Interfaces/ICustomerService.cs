using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICustomerService : ICRUDService<Customer, Customer, string>
    {
        List<Customer> GetAllCustomers();
        void CreatePhone(Customer customerPhone);
        void DeletePhone(string phone);
        List<string> ReadPhone(string cpf);
        void UpdatePhone(string[] phone);
    }
}