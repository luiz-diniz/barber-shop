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

        public void Delete(Employee employee)
        {
            try
            {
                _employeeRepository.Delete(employee);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "Employee", new List<string> { employee.Cpf });
            }
        }

        public Employee Read(string cpf)
        {
            Employee employee = new Employee();

            try
            {
                employee = _employeeRepository.Read(cpf);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "Employee", new List<string> { employee.Id.ToString(), employee.Cpf, employee.Name, employee.Username });
            }

            return employee;
        }

        public void Update(Employee employeeArgument)
        {
            try
            {
                _employeeRepository.Update(employeeArgument);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "Employee", new List<string> { employeeArgument.Cpf, employeeArgument.Name, employeeArgument.Username });
            }
        }
    }
}
