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
                _shopAddressRepository.Create(shopAddress);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "ShopAddress", new string[] { shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State });
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
            throw new System.NotImplementedException();
        }
    }
}