using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class ServiceInfoService : IServiceInfoService
    {
        private IServiceInfoRepository _shopServiceRepository;
        private ILogger _logger;

        public ServiceInfoService(IServiceInfoRepository shopServiceRepository, ILogger logger)
        {
            _shopServiceRepository = shopServiceRepository;
            _logger = logger;
        }

        public void Create(ServiceInfo shopService)
        {
            try
            {
                _shopServiceRepository.Create(shopService);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "ServiceInfo", new List<string> { shopService.Name, shopService.Description, shopService.Value.ToString() });
            }
        }

        public void Delete(ServiceInfo shopService)
        {
            try
            {
                _shopServiceRepository.Delete(shopService);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "ServiceInfo", new List<string> { shopService.Name, shopService.Description, shopService.Value.ToString() });
            }
        }

        public ServiceInfo Read(string name)
        {
            ServiceInfo serviceInfo = new ServiceInfo();

            try
            {
                serviceInfo = _shopServiceRepository.Read(name);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "ServiceInfo", new List<string> { name });
            }

            return serviceInfo;
        }

        public void Update(ServiceInfo shopService)
        {
            try
            {
                _shopServiceRepository.Update(shopService);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "ServiceInfo", new List<string> { shopService.Id.ToString(), shopService.Name, shopService.Description, shopService.Value.ToString() });
            }
        }
    }
}