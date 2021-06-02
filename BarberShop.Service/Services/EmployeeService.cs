using System;
using System.Collections.Generic;
using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using BarberShop.Service.Utilities;

namespace BarberShop.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private ILogger _logger;
        private IHasher _hasher;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger logger, IHasher hasher)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _hasher = hasher;
        }

        public void Create(Employee employee)
        {
            try
            {
                if (employee == null) throw new ArgumentNullException();
                if (String.IsNullOrEmpty(employee.Cpf) || String.IsNullOrEmpty(employee.Name) || 
                    String.IsNullOrEmpty(employee.Username) || String.IsNullOrEmpty(employee.Password) ||
                    String.IsNullOrEmpty(employee.UserType)) throw new ArgumentException();

                employee.SaltPassword = _hasher.CreateSalt(20);
                employee.Password = _hasher.GenerateHash(employee.Password, employee.SaltPassword);
           
                _employeeRepository.Create(employee);

                _logger.CreateLog("Database", "Insert", "Employee", new string[] { employee.Cpf, employee.Name, employee.Username });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
                throw ex;
            }
        }

        public void Delete(Employee employee)
        {
            try
            {
                if (employee == null) throw new ArgumentNullException();
                if (String.IsNullOrEmpty(employee.Cpf)) throw new ArgumentException();
                
                _employeeRepository.Delete(employee);

                _logger.CreateLog("Database", "Delete", "Employee", new string[] { employee.Cpf });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public Employee Read(string cpf)
        {
            try
            {
                if (String.IsNullOrEmpty(cpf)) throw new ArgumentException();

                Employee employee = new Employee();

                employee = _employeeRepository.Read(cpf);

                _logger.CreateLog("Database", "Read", "Employee", new string[] { employee.Id.ToString(), employee.Cpf, employee.Name, employee.Username });

                return employee;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public Employee Read(int id)
        {
            try
            {
                if (id < 0) throw new ArgumentOutOfRangeException();

                var employee = _employeeRepository.Read(id);

                _logger.CreateLog("Database", "Read", "Customer", new string[] { employee.Id.ToString(), employee.Cpf, employee.Name, employee.Username });

                return employee;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw;
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                var result = _employeeRepository.GetAll();

                if (result == null) throw new Exception("Null values from the database.");

                _logger.CreateLog("Database", "GetAllEmployees");

                return result;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                if (employee == null) throw new ArgumentNullException();
                if (String.IsNullOrEmpty(employee.Cpf) || String.IsNullOrEmpty(employee.Name) ||
                    String.IsNullOrEmpty(employee.Username) || String.IsNullOrEmpty(employee.UserType)) throw new ArgumentException();

                _employeeRepository.Update(employee);

                _logger.CreateLog("Database", "Update", "Employee", new string[] { employee.Cpf, employee.Name, employee.Username });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }       
    }
}