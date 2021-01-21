using System;
using System.Collections.Generic;
using System.Text;
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

        public EmployeeServiceTests()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _logger = new Mock<ILogger>();
        }

        

        private EmployeeService GetInstance()
        {
            return new EmployeeService(_employeeRepository.Object, _logger.Object, _hasher.Object);
        }
    }
}
