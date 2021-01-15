using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Services;
using Moq;
using System;

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

        public CustomerService GetInstance()
        {
            return new CustomerService(_customerRepository.Object, _logger.Object);
        }
    }
}
