using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;

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
                _shopAddressRepository.Delete(shopAddress);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
            }
        }

        public ShopAddress Read(string name)
        {
            ShopAddress shopAddress = new ShopAddress();

            try
            {
                shopAddress = _shopAddressRepository.Read(name);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
            }

            return shopAddress;
        }

        public void Update(ShopAddress shopAddress)
        {
            try
            {
                _shopAddressRepository.Update(shopAddress);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
            }
        }
    }
}