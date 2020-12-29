using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private ILogger _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public void Create(Customer customer)
        {
            try
            {
                _customerRepository.Create(customer);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "Customer", new List<string> { customer.Cpf, customer.Name, customer.Birth.ToString(), customer.Phone });
            }
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