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
        private IServiceInfoRepository _serviceInfoRepository;
        private ILogger _logger;

        public ServiceInfoService(IServiceInfoRepository serviceInfoRepository, ILogger logger)
        {
            _serviceInfoRepository = serviceInfoRepository;
            _logger = logger;
        }

        public void Create(ServiceInfo serviceInfo)
        {
            try
            {
                if (serviceInfo == null) throw new ArgumentNullException();

                if (String.IsNullOrEmpty(serviceInfo.Name) || String.IsNullOrEmpty(serviceInfo.Description)) throw new ArgumentException();

                if (serviceInfo.Value < 0) throw new ArgumentException();

                _serviceInfoRepository.Create(serviceInfo);

                _logger.CreateLog("Database", "Insert", "ServiceInfo", new string[] { serviceInfo.Name, serviceInfo.Description, serviceInfo.Value.ToString() });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Delete(ServiceInfo serviceInfo)
        {
            try
            {
                _serviceInfoRepository.Delete(serviceInfo);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "ServiceInfo", new string[] { serviceInfo.Name, serviceInfo.Description, serviceInfo.Value.ToString() });
            }
        }

        public ServiceInfo Read(string name)
        {
            ServiceInfo serviceInfo = new ServiceInfo();

            try
            {
                serviceInfo = _serviceInfoRepository.Read(name);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "ServiceInfo", new string[] { name });
            }

            return serviceInfo;
        }

        public void Update(ServiceInfo serviceInfo)
        {
            try
            {
                _serviceInfoRepository.Update(serviceInfo);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "ServiceInfo", new string[] { serviceInfo.Id.ToString(), serviceInfo.Name, serviceInfo.Description, serviceInfo.Value.ToString() });
            }
        }
    }
}