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

        //Customer
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
                _logger.CreateLog("Database", "Insert", "Customer", new List<string> { customer.Cpf, customer.Name, customer.Birth.ToString() });
            }
        }           

        public void Delete(Customer customer)
        {
            try
            {
                _customerRepository.DeleteAllPhones(customer.Id);
                _customerRepository.Delete(customer);               
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "Customer", new List<string> { customer.Cpf });
            }
        }

        public Customer Read(string cpf)
        {
            Customer customer = new Customer();

            try
            {
                customer = _customerRepository.Read(cpf);
                customer.Phone = _customerRepository.ReadPhone(customer.Id);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                for (int i = 0; i < customer.Phone.Count; i++)
                {
                    _logger.CreateLog("Database", "Update", "Customer", new List<string> { customer.Id.ToString(), customer.Cpf, customer.Name, customer.Birth.ToString(), customer.Phone[i] });
                }
            }

            return customer;
        }

        public Customer Update(Customer customerArgument)
        {
            Customer customer = new Customer();

            try
            {
                customer = _customerRepository.Update(customerArgument);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                for (int i = 0; i < customerArgument.Phone.Count; i++)
                {
                    _logger.CreateLog("Database", "Update", "Customer", new List<string> { customer.Id.ToString(), customerArgument.Cpf, customerArgument.Name, customerArgument.Birth.ToString(), customerArgument.Phone[i] });
                }            
            }

            return customer;
        }

        //CustomerPhone
        public void CreatePhone(Customer customer)
        {
            try
            {
                _customerRepository.CreatePhone(customer);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                for (int i = 0; i < customer.Phone.Count; i++)
                {
                    _logger.CreateLog("Database", "Insert", "CustomerPhone", new List<string> { customer.Cpf, customer.Phone[i] });

                }            
            }
        }

        public void DeletePhone(string phone)
        {
            try
            {
                _customerRepository.DeletePhone(phone);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "CustomerPhone", new List<string> { phone });
            }
        }

        public List<string> ReadPhone(int id)
        {
            return _customerRepository.ReadPhone(id);
        }

        public Customer UpdatePhone(Customer customerPhone)
        {
            throw new NotImplementedException();
        }
    }
}