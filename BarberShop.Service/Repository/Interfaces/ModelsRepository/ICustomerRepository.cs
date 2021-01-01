using BarberShop.Service.Models;

namespace BarberShop.Service.Repository.Interfaces
{
    public interface ICustomerRepository : ICRUD<Customer, Customer>
    {
        void CreatePhone(Customer customer);
        void DeletePhone(string phone);
        Customer ReadPhone(string cpf);
        Customer UpdatePhone(Customer customer);
    }
}
