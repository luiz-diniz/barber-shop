using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using BarberShop.Service.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Tests
{
    public class ServiceInfoServiceTests
    {
        private Mock<IServiceInfoRepository> _ServiceInfoService;
        private Mock<ILogger> _logger;

        public ServiceInfoServiceTests()
        {
            _ServiceInfoService = new Mock<IServiceInfoRepository>();
            _logger = new Mock<ILogger>();
        }

        private ServiceInfoService GetInstance()
        {
            return new ServiceInfoService(_ServiceInfoService.Object, _logger.Object);
        }
    }
}
