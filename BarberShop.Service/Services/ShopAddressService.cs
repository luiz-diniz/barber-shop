using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using BarberShop.Service.Utilities;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class ShopAddressService : IShopAddressService
    {
        private IShopAddressRepository _shopAddressRepository;
        private ILogger _logger;

        public ShopAddressService(IShopAddressRepository shopAddressRepository, ILogger logger)
        {
            _shopAddressRepository = shopAddressRepository;
            _logger = logger;
        }

        public void Create(ShopAddress shopAddress)
        {
            try
            {
                if (shopAddress == null) throw new ArgumentNullException();

                if (String.IsNullOrEmpty(shopAddress.Name) || String.IsNullOrEmpty(shopAddress.Street)
                    || String.IsNullOrEmpty(shopAddress.City) || String.IsNullOrEmpty(shopAddress.State))
                    throw new ArgumentException();

                if (shopAddress.Number < 0) throw new ArgumentOutOfRangeException();

                _shopAddressRepository.Create(shopAddress);

                _logger.CreateLog("Database", "Insert", "ShopAddress", new string[] { shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Delete(ShopAddress shopAddress)
        {
            try
            {
                if (shopAddress == null) throw new ArgumentNullException();

                if (shopAddress.Id < 0) throw new ArgumentOutOfRangeException();

                _shopAddressRepository.Delete(shopAddress);

                _logger.CreateLog("Database", "Delete", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public List<ShopAddress> GetAll()
        {
            try
            {
                var result = _shopAddressRepository.GetAll();

                if (result == null) throw new Exception("Null values from the database.");

                _logger.CreateLog("Database", "GetAllShopAddresses");

                return result;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public ShopAddress Read(string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name)) throw new ArgumentException();

                ShopAddress shopAddress = new ShopAddress();

                shopAddress = _shopAddressRepository.Read(name);

                _logger.CreateLog("Database", "Read", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.City, shopAddress.State });

                return shopAddress;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public ShopAddress Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ShopAddress shopAddress)
        {
            try
            {
                if (shopAddress == null) throw new ArgumentNullException();

                if (String.IsNullOrEmpty(shopAddress.Name) || String.IsNullOrEmpty(shopAddress.Street)
                    || String.IsNullOrEmpty(shopAddress.City) || String.IsNullOrEmpty(shopAddress.State))
                    throw new ArgumentException();

                if (shopAddress.Number < 0) throw new ArgumentOutOfRangeException();

                _shopAddressRepository.Update(shopAddress);

                _logger.CreateLog("Database", "Update", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }
    }
}