using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using BarberShop.Service.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BarberShop.Tests.Services
{
    public class OrderInfoTests
    {
        private Mock<IOrderInfoRepository> _orderInfoRepository;
        private Mock<ILogger> _logger;
        private OrderInfo _orderInfo;
        private Customer _customer;
        private Employee _employee;
        private ShopAddress _shopAddress;
        private DateTime _dateTime;

        public OrderInfoTests()
        {
            _orderInfoRepository = new Mock<IOrderInfoRepository>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void CreateOrderInfoNull()
        {
            OrderInfo orderInfo = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(orderInfo));

            _logger.Verify();
        }

        public OrderInfoService GetInstance()
        {
            return new OrderInfoService(_orderInfoRepository.Object, _logger.Object);
        }
    }
}
