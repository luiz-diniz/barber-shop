using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Repository.Interfaces
{
    public interface ICustomerRepository : ICRUD<Customer, Customer, string>
    {
        void CreatePhone(Customer customer);
        void DeletePhone(string phone);
        List<string> ReadPhone(string cpf);
        void UpdatePhone(string[] phones);
        void DeleteAllPhones(int id);
    }
}