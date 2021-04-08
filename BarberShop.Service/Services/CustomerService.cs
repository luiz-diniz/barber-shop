using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Services.Interfaces;
using BarberShop.Service.Utilities;
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
                if (customer == null) throw new ArgumentNullException();
                if (String.IsNullOrEmpty(customer.Cpf) || String.IsNullOrEmpty(customer.Name)
                    || String.IsNullOrEmpty(customer.Phone)) throw new ArgumentException();                

                _customerRepository.Create(customer);

                _logger.CreateLog("Database", "Insert", "Customer", new string[] { customer.Cpf, customer.Name, customer.Birth.ToString() });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Database", "Insert", "Customer", new string[] { ex.ToString() });
                throw ex;
            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                if (customer == null) throw new ArgumentNullException();
                if (String.IsNullOrEmpty(customer.Cpf)) throw new ArgumentException();

                _customerRepository.Delete(customer);

                _logger.CreateLog("Database", "Delete", "Customer", new string[] { customer.Cpf });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public Customer Read(string cpf)
        {
            try
            {
                if (String.IsNullOrEmpty(cpf)) throw new ArgumentException();

                Customer customer = new Customer();

                customer = _customerRepository.Read(cpf);

                _logger.CreateLog("Database", "Update", "Customer", new string[] { customer.Id.ToString(), customer.Cpf, customer.Name, customer.Birth.ToString() });

                return customer;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                var result = _customerRepository.GetAll();

                if (result == null) throw new Exception("Null values from the database.");

                _logger.CreateLog("Database", "GetAllCustomers");

                return result;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Update(Customer customerArgument)
        {
            try
            {
                if (customerArgument == null) throw new ArgumentNullException();

                _customerRepository.Update(customerArgument);

                _logger.CreateLog("Database", "Update", "Customer", new string[] { customerArgument.Cpf, customerArgument.Name, customerArgument.Birth.ToString() });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }
    }
}