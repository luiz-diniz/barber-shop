using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using BarberShop.Service.Utilities;
using Moq;
using Xunit;

namespace BarberShop.Tests
{
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _employeeRepository;
        private Mock<ILogger> _logger;
        private Mock<IHasher> _hasher;

        private int _id = 666;
        private string _cpf = "00000000000";
        private string _name = "Eddie";
        private string _username = "eddie";
        private string _password = "eddietop";

        public EmployeeServiceTests()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _logger = new Mock<ILogger>();
            _hasher = new Mock<IHasher>();
        }

        [Fact]
        public void CreateEmployeeNullTest()
        {
            Employee employee = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));
            
            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeeCpfNullTest()
        {
            Employee employee = new Employee
            {
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeeCpfEmptyTest()
        {
            Employee employee = new Employee
            {
                Cpf = "",
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        private EmployeeService GetInstance()
        {
            return new EmployeeService(_employeeRepository.Object, _logger.Object, _hasher.Object);
        }
    }
}
