using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BarberShop.Tests
{
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<ILogger> _logger;

        private int _id = 666;
        private string _cpf = "00000000000";
        private string _name = "Angus";
        private DateTime _birth = Convert.ToDateTime("2000-01-01T00:00:00");
        private string _phone = "00111112222";
        private List<string> _phones = new List<string>
        {
            "00111112222", "00111113333"
        };

        public CustomerServiceTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void CreateCustomerNullTest()
        {
            Customer customer = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerCpfNullTest()
        {
            Customer customer = new Customer { 
                Name = _name,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerCpfEmptyTest()
        {
            Customer customer = new Customer
            {
                Cpf = "",
                Name = _name,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerNameNullTest()
        {
            Customer customer = new Customer
            {
                Cpf = _cpf,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerNameEmptyTest()
        {
            Customer customer = new Customer
            {
                Cpf = _cpf,
                Name = "",
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerTest()
        {
            Customer customer = new Customer
            {
                Cpf = _cpf,
                Name = _name,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Database", "Insert", "Customer", new string[] { customer.Cpf, customer.Name, customer.Birth.ToString() }));
            _customerRepository.Setup(x => x.Create(customer));

            var instance = GetInstance();

            instance.Create(customer);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void DeleteCustomerNullTest()
        {
            Customer customer = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Delete(customer));

            _logger.Verify();
        }

        [Fact]
        public void DeleteCustomerCpfNullTest()
        {
            Customer customer = new Customer();

            customer.Cpf = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(customer));

            _logger.Verify();
        }

        [Fact]
        public void DeleteCustomerCpfEmptyTest()
        {
            Customer customer = new Customer();

            customer.Cpf = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(customer));

            _logger.Verify();
        }

        [Fact]
        public void DeleteCustomerTest()
        {
            Customer customer = new Customer
            {
                Cpf = _cpf,
                Name = _name,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Database", "Delete", "Customer", new string[] { customer.Cpf }));
            _customerRepository.Setup(x => x.Delete(customer));

            var instance = GetInstance();

            instance.Delete(customer);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void ReadCustomerCpfNullTest()
        {
            string cpf = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(cpf));

            _logger.Verify();
        }

        [Fact]
        public void ReadCustomerCpfEmptyTest()
        {
            string cpf = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(cpf));

            _logger.Verify();
        }

        [Fact]
        public void ReadCustomerTest()
        {
            string cpf = _cpf;

            Customer customer = new Customer()
            {
                Id = _id,
                Cpf = _cpf,
                Name = _name,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Database", "Read", "Customer", new string[] { customer.Id.ToString(), customer.Cpf, customer.Name, customer.Birth.ToString() }));
            _customerRepository.Setup(x => x.Read(cpf)).Returns(customer);

            var instance = GetInstance();

            var result = instance.Read(cpf);

            Assert.IsAssignableFrom<Customer>(result);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void UpdateCustomerNullTest()
        {
            Customer customer = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Update(customer));

            _logger.Verify();
        }

        [Fact]
        public void UpdateCustomerTest()
        {
            Customer customer = new Customer
            {
                Id = _id,
                Cpf = _cpf,
                Name = _name,
                Birth = _birth
            };

            _logger.Setup(x => x.CreateLog("Database", "Update", "Customer", new string[] { customer.Cpf, customer.Name, customer.Birth.ToString() }));
            _customerRepository.Setup(x => x.Update(customer));

            var instance = GetInstance();

            instance.Update(customer);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void CreateCustomerPhoneNullTest()
        {
            Customer customer = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.CreatePhone(customer));
        }

        [Fact]
        public void CreatePhoneNullTest()
        {
            Customer customer = new Customer
            {
                Id = _id,
                Name = _name,
                Cpf = _cpf,
                Phone = null
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.CreatePhone(customer));
        }

        [Fact]
        public void CreatePhoneTest()
        {
            Customer customer = new Customer
            {
                Id = _id,
                Name = _name,
                Cpf = _cpf,
                Phone = _phones
            };

            _logger.Setup(x => x.CreateLog("Database", "Insert", "CustomerPhone", new string[] { customer.Cpf, customer.Phone[0] }));
            _customerRepository.Setup(x => x.CreatePhone(customer));

            var instance = GetInstance();

            instance.CreatePhone(customer);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void DeletePhoneNullTest()
        {
            string phone = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.DeletePhone(phone));

            _logger.Verify();
        }

        [Fact]
        public void DeletePhoneEmptyTest()
        {
            string phone = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.DeletePhone(phone));

            _logger.Verify();
        }

        [Fact]
        public void DeletePhoneTest()
        {
            string phone = _phone;

            _logger.Setup(x => x.CreateLog("Database", "Delete", "CustomerPhone", new string[] { phone }));
            _customerRepository.Setup(x => x.DeletePhone(phone));

            var instance = GetInstance();

            instance.DeletePhone(phone);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void ReadPhoneNullTest()
        {
            string cpf = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.ReadPhone(cpf));

            _logger.Verify();
        }

        [Fact]
        public void ReadPhoneEmptyTest()
        {
            string cpf = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.ReadPhone(cpf));

            _logger.Verify();
        }

        [Fact]
        public void ReadPhoneTest()
        {
            string cpf = _cpf;
            List<string> phones = _phones;

            _logger.Setup(x => x.CreateLog("Database", "Read", "CustomerPhone", new string[] { cpf }));
            _customerRepository.Setup(x => x.ReadPhone(cpf)).Returns(phones);

            var instance = GetInstance();

            var result = instance.ReadPhone(cpf);

            Assert.IsAssignableFrom<List<String>>(result);

            _logger.Verify();
            _customerRepository.Verify();
        }

        [Fact]
        public void UpdatePhoneNullTest()
        {
            string[] phones = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.UpdatePhone(phones));

            _logger.Verify();
        }

        [Fact]
        public void UpdatePhoneTest()
        {
            string[] phones = new string[]
            {
                "00111112222", "00111113333"
            };

            _logger.Setup(x => x.CreateLog("Database", "Update", "CustomerPhone", new string[] { phones[0], phones[1] }));
            _customerRepository.Setup(x => x.UpdatePhone(phones));

            var instance = GetInstance();

            instance.UpdatePhone(phones);

            _logger.Verify();
            _customerRepository.Verify();
        }
        
        private CustomerService GetInstance()
        {
            return new CustomerService(_customerRepository.Object, _logger.Object);
        }
    }
}