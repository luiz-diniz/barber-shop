using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Tests
{
    public class ShopAddressTests
    {
        private Mock<IShopAddressRepository> _shopAddressRepository;
        private Mock<ILogger> _logger;

        public ShopAddressTests()
        {
            _shopAddressRepository = new Mock<IShopAddressRepository>();
            _logger = new Mock<ILogger>();
        }

        public ShopAddressService GetInstance()
        {
            return new ShopAddressService(_shopAddressRepository.Object, _logger.Object);
        }
    }
}
