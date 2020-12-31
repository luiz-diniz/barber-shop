using BarberShop.Service.Models;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICustomerService : ICRUDService<Customer, Customer>
    {
        void CreatePhone(CustomerPhone customerPhone);
        void DeletePhone(CustomerPhone customerPhone);
        CustomerPhone ReadPhone(string cpf);
        CustomerPhone UpdatePhone(CustomerPhone customerPhone);
    }
}
