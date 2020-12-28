using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.ModelsRepository;
using BarberShop.Service.Services.Interfaces;

namespace BarberShop.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string type)
        {
            throw new System.NotImplementedException();
        }

        public Customer Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public Customer Update(Customer type)
        {
            throw new System.NotImplementedException();
        }
    }
}