using System;
using System.Collections.Generic;
using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
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
                employee.SaltPassword = _hasher.CreateSalt(20);
                employee.Password = _hasher.GenerateHash(employee.Password, employee.SaltPassword);
           
                _employeeRepository.Create(employee);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "Employee", new List<string> { employee.Cpf, employee.Name, employee.Username });
            }
        }

        public void Delete(string type)
        {
            throw new System.NotImplementedException();
        }

        public Employee Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public Employee Update(Employee type)
        {
            throw new System.NotImplementedException();
        }
    }
}
