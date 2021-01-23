﻿using System;
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

        [Fact]
        public void CreateEmployeeNameNullTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = null,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeeNameEmptyTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = "",
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeeUsernameNullTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = _name,
                Username = null,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeeUsernameEmptyTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = _name,
                Username = "",
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeePasswordNullTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = _name,
                Username = _username,
                Password = null
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeePasswordEmptyTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = _name,
                Username = _username,
                Password = ""
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(employee));

            _logger.Verify();
        }

        [Fact]
        public void CreateEmployeeTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = _name,
                Username = _username,
                Password = _password
            };

            var salt = "aaaaaaaaaaaaaaaaaaaa";
            var passwordHash = "eddietopaaaaaaaaaaaaaaaaaaaa";

            _logger.Setup(x => x.CreateLog("Database", "Insert", "Employee", new string[] { employee.Cpf, employee.Name, employee.Username }));
            _hasher.Setup(x => x.CreateSalt(20)).Returns(salt);
            _hasher.Setup(x => x.GenerateHash(_password, salt)).Returns(passwordHash);
            _employeeRepository.Setup(x => x.Create(employee));

            var instance = GetInstance();

            instance.Create(employee);

            _logger.Verify();
            _hasher.Verify();
        }

        private EmployeeService GetInstance()
        {
            return new EmployeeService(_employeeRepository.Object, _logger.Object, _hasher.Object);
        }
    }
}
