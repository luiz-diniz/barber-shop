using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Service.Models;

namespace BarberShop.Tests
{
    public class ShopAddressTests
    {
        private Mock<IShopAddressRepository> _shopAddressRepository;
        private Mock<ILogger> _logger;
        private int _id = 1;
        private string _name = "Name";
        private string _street = "Street";
        private int _number = 100;
        private string _city = "City";
        private string _state = "State";

        public ShopAddressTests()
        {
            _shopAddressRepository = new Mock<IShopAddressRepository>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void CreateShopAddressNullTest()
        {
            ShopAddress shopAddress = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressNameNullTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = null,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressNameEmptyTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = "",
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStreetNullTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = null,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStreetEmptyTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = "",
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressCityNullTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = _street,
                City = null,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressCityEmptyTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = _street,
                City = "",
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStateNullTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = _street,
                City = _state,
                State = null,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStateEmptyTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = _street,
                City = _state,
                State = "",
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressNumberLessThanZeroTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(X => X.CreateLog("Database", "Insert", "ShopAddress", new string[] { shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State }));
            _shopAddressRepository.Setup(x => x.Create(shopAddress));

            var instance = GetInstance();

            instance.Create(shopAddress);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        [Fact]
        public void DeleteShopAddressNullTest()
        {
            ShopAddress shopAddress = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Delete(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void DeleteShopAddressIdLessThanZeroTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Id = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Delete(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void DeleteShopAddressTest()
        {
            ShopAddress shopAddress = new ShopAddress()
            {
                Id = _id,
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Database", "Delete", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State }));
            _shopAddressRepository.Setup(x => x.Delete(shopAddress));

            var instance = GetInstance();

            instance.Delete(shopAddress);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        public ShopAddressService GetInstance()
        {
            return new ShopAddressService(_shopAddressRepository.Object, _logger.Object);
        }
    }
}
