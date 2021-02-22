using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using BarberShop.Service.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BarberShop.Tests
{
    public class ServiceInfoServiceTests
    {
        private Mock<IServiceInfoRepository> _serviceInfoRepository;
        private Mock<ILogger> _logger;
        private int _id = 666;
        private string _name = "Name";
        private string _description = "Description";
        private decimal _value = 10.90m;

        public ServiceInfoServiceTests()
        {
            _serviceInfoRepository = new Mock<IServiceInfoRepository>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void CreateServiceInfoNullTest()
        {
            ServiceInfo serviceInfo = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void CreateServiceInfoNameNullTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Name = null,
                Description = _description
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void CreateServiceInfoNameEmptyTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Name = "",
                Description = _description
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void CreateServiceInfoDescriptionNullTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Name = _name,
                Description = null
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void CreateServiceInfoDescriptionEmptyTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Name = _name,
                Description = ""
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void CreateServiceInfoValueLessThanZeroTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Name = _name,
                Description = _description,
                Value = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void CreateServiceInfoTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Name = _name,
                Description = _description,
                Value = _value
            };

            _logger.Setup(x => x.CreateLog("Database", "Insert", "ServiceInfo", new string[] { serviceInfo.Name, serviceInfo.Description, serviceInfo.Value.ToString() }));
            _serviceInfoRepository.Setup(x => x.Create(serviceInfo));

            var instance = GetInstance();

            instance.Create(serviceInfo);

            _logger.Verify();
            _serviceInfoRepository.Verify();
        }

        [Fact]
        public void DeleteServiceInfoNullTest()
        {
            ServiceInfo serviceInfo = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Delete(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void DeleteServiceInfoIdLessThanZeroTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Id = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(serviceInfo));

            _logger.Verify();
        }

        [Fact]
        public void DeleteServiceInfoTest()
        {
            ServiceInfo serviceInfo = new ServiceInfo()
            {
                Id = _id,
                Name = _name,
                Description = _description,
                Value = _value
            };

            _logger.Setup(x => x.CreateLog("Database", "Delete", "ServiceInfo", new string[] { serviceInfo.Name, serviceInfo.Description, serviceInfo.Value.ToString() }));
            _serviceInfoRepository.Setup(x => x.Delete(serviceInfo));

            var instance = GetInstance();

            instance.Delete(serviceInfo);

            _logger.Verify();
            _serviceInfoRepository.Verify();
        }

        private ServiceInfoService GetInstance()
        {
            return new ServiceInfoService(_serviceInfoRepository.Object, _logger.Object);
        }
    }
}
