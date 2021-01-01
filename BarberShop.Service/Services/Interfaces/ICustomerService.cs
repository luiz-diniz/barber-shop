using BarberShop.Service.Models;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICustomerService : ICRUDService<Customer, Customer>
    {
        void CreatePhone(Customer customerPhone);
        void DeletePhone(string phone);
        Customer ReadPhone(string cpf);
        Customer UpdatePhone(Customer customerPhone);
    }
}