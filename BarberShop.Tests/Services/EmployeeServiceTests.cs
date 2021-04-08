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
        private string _saltPassword = "hash";
        private int _loginAttemts = 0;

        private List<Employee> _employees;

        public EmployeeServiceTests()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _logger = new Mock<ILogger>();
            _hasher = new Mock<IHasher>();

            _employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = _id,
                    Cpf = _cpf,
                    Name = _name,
                    Username = _username,
                    Password = _password,
                    SaltPassword = _saltPassword,
                    LoginAttempts = _loginAttemts
                },
                new Employee()
                {
                    Id = _id,
                    Cpf = _cpf,
                    Name = _name,
                    Username = _username,
                    Password = _password,
                    SaltPassword = _saltPassword,
                    LoginAttempts = _loginAttemts
                }
            };
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

        [Fact]
        public void DeleteEmployeeNullTest()
        {
            Employee employee = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Delete(employee));

            _logger.Verify();
        }

        [Fact]
        public void DeleteEmployeeCpfNullTest()
        {
            Employee employee = new Employee() {
                Cpf = null,
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(employee));

            _logger.Verify();
        }

        [Fact]
        public void DeleteEmployeeEmptyNullTest()
        {
            Employee employee = new Employee()
            {
                Cpf = "",
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(employee));

            _logger.Verify();
        }

        [Fact]
        public void DeleteEmployeeTest()
        {
            Employee employee = new Employee()
            {
                Cpf = _cpf,
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Database", "Delete", "Employee", new string[] { employee.Cpf }));
            _employeeRepository.Setup(x => x.Delete(employee));

            var instance = GetInstance();

            instance.Delete(employee);

            _logger.Verify();
            _employeeRepository.Verify();
        }

        [Fact]
        public void ReadEmployeeCpfNullTest()
        {
            string cpf = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(cpf));

            _logger.Verify();
        }

        [Fact]
        public void ReadEmployeeCpfEmptyTest()
        {
            string cpf = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(cpf));

            _logger.Verify();
        }

        [Fact]
        public void ReadEmployeeTest()
        {
            string cpf = _cpf;

            Employee employee = new Employee()
            {
                Id = _id,
                Cpf = _cpf,
                Name = _name,
                Username = _username
            };

            _logger.Setup(x => x.CreateLog("Database", "Read", "Employee", new string[] { employee.Id.ToString(), employee.Cpf, employee.Name, employee.Username }));
            _employeeRepository.Setup(x => x.Read(cpf)).Returns(employee);

            var instance = GetInstance();

            var result = instance.Read(cpf);

            Assert.NotNull(result);

            _logger.Verify();
            _employeeRepository.Verify();
        }

        [Fact]
        public void UpdateEmployeeNullTest()
        {
            Employee employee = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeCpfNullTest()
        {
            Employee employee = new Employee
            {
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeCpfEmptyTest()
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

            Assert.Throws<ArgumentException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeNameNullTest()
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

            Assert.Throws<ArgumentException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeNameEmptyTest()
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

            Assert.Throws<ArgumentException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeUsernameNullTest()
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

            Assert.Throws<ArgumentException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeUsernameEmptyTest()
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

            Assert.Throws<ArgumentException>(() => instance.Update(employee));

            _logger.Verify();
        }

        [Fact]
        public void UpdateEmployeeTest()
        {
            Employee employee = new Employee
            {
                Cpf = _cpf,
                Name = _name,
                Username = _username,
                Password = _password
            };

            _logger.Setup(x => x.CreateLog("Database", "Update", "Employee", new string[] { employee.Cpf, employee.Name, employee.Username }));
            _employeeRepository.Setup(x => x.Update(employee));

            var instance = GetInstance();

            instance.Update(employee);

            _logger.Verify();
            _employeeRepository.Verify();
        }

        [Fact]
        public void GetAllNullEmployeesTest()
        {
            List<Employee> employees = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));
            _employeeRepository.Setup(x => x.GetAll()).Returns(employees);

            var instance = GetInstance();

            Assert.Throws<Exception>(() => instance.GetAll());

            _logger.Verify();
            _employeeRepository.Verify();
        }

        [Fact]
        public void GetAllEmployeeTest()
        {
            List<Employee> employees = _employees;

            _logger.Setup(x => x.CreateLog("Database", "GetAllEmployees"));
            _employeeRepository.Setup(x => x.GetAll()).Returns(employees);

            var instance = GetInstance();

            var result = instance.GetAll();

            Assert.NotNull(result);

            _logger.Verify();
            _employeeRepository.Verify();
        }

        private EmployeeService GetInstance()
        {
            return new EmployeeService(_employeeRepository.Object, _logger.Object, _hasher.Object);
        }
    }
}