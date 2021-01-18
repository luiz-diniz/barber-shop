using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
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
                if (customer == null) throw new ArgumentNullException();
                if (String.IsNullOrEmpty(customer.Cpf) || String.IsNullOrEmpty(customer.Name)) throw new ArgumentException();                

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

                _customerRepository.DeleteAllPhones(customer.Id);
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
            Customer customer = new Customer();

            try
            {
                customer = _customerRepository.Read(cpf);
                customer.Phone = _customerRepository.ReadPhone(cpf);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                for (int i = 0; i < customer.Phone.Count; i++)
                {
                    _logger.CreateLog("Database", "Update", "Customer", new string[] { customer.Id.ToString(), customer.Cpf, customer.Name, customer.Birth.ToString(), customer.Phone[i] });
                }
            }

            return customer;
        }

        public void Update(Customer customerArgument)
        {
            try
            {
                _customerRepository.Update(customerArgument);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "Customer", new string[] { customerArgument.Cpf, customerArgument.Name, customerArgument.Birth.ToString() });
            }
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
                    _logger.CreateLog("Database", "Insert", "CustomerPhone", new string[] { customer.Cpf, customer.Phone[i] });

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
                _logger.CreateLog("Database", "Delete", "CustomerPhone", new string[] { phone });
            }
        }

        public List<string> ReadPhone(string cpf)
        {
            List<string> phones = new List<string>();

            try
            {
                phones = _customerRepository.ReadPhone(cpf);
            }
            catch(Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "CustomerPhone", new string[] { cpf });
            }

            return phones;
        }

        public void UpdatePhone(string[] phone)
        {
            try
            {
                _customerRepository.UpdatePhone(phone);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "CustomerPhone", new string[] { phone[0], phone[1] });
            }
        }
    }
}