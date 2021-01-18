using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Services;
using Moq;
using System;
using Xunit;

namespace BarberShop.Tests
{
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<ILogger> _logger;

        public CustomerServiceTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void CreateCustomerNullTest()
        {
            Customer customer = null;

            _logger.Setup(x => x.CreateLog("Error","Insert","Customer", new string[] { "Error" }));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerCpfNullTest()
        {
            Customer customer = new Customer { 
                Name = "Test",
                Birth = Convert.ToDateTime("2000-01-01T00:00:00")
            };

            _logger.Setup(x => x.CreateLog("Error", "Insert", "Customer", new string[] { "Error" }));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerNameNullTest()
        {
            Customer customer = new Customer
            {
                Cpf = "000000000",
                Birth = Convert.ToDateTime("2000-01-01T00:00:00")
            };

            _logger.Setup(x => x.CreateLog("Error", "Insert", "Customer", new string[] { "Error" }));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(customer));

            _logger.Verify();
        }

        [Fact]
        public void CreateCustomerTest()
        {
            Customer customer = new Customer
            {
                Cpf = "000000000",
                Name = "Test",
                Birth = Convert.ToDateTime("2000-01-01T00:00:00")
            };

            _logger.Setup(x => x.CreateLog("Error", "Insert", "Customer", new string[] { "Error" }));
            _customerRepository.Setup(x => x.Create(customer));

            var instance = GetInstance();

            instance.Create(customer);

            _logger.Verify();
            _customerRepository.Verify();
        }

        public CustomerService GetInstance()
        {
            return new CustomerService(_customerRepository.Object, _logger.Object);
        }
    }
}