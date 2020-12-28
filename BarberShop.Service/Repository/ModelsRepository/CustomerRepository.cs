using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using System;

namespace BarberShop.Service.Repository.ModelsRepository
{
    public class CustomerRepository : DatabaseConfiguration, ICustomerRepository
    {
        public void Create(Customer type)
        {
            throw new NotImplementedException();
        }

        public void Delete(string type)
        {
            throw new NotImplementedException();
        }

        public Customer Read(string type)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer type)
        {
            throw new NotImplementedException();
        }
    }
}