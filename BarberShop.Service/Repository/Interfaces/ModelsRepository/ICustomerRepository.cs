using BarberShop.Service.Models;

namespace BarberShop.Service.Repository.Interfaces
{
    public interface ICustomerRepository : ICRUD<Customer, Customer>
    {
        void CreatePhone(CustomerPhone customerPhone);
        void DeletePhone(CustomerPhone customerPhone);
        CustomerPhone ReadPhone(string cpf);
        CustomerPhone UpdatePhone(CustomerPhone customerPhone);
    }
}
