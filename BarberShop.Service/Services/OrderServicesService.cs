using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using BarberShop.Service.Utilities;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class OrderServicesService : IOrderServicesService
    {
        private IOrderServicesRepository _orderServicesRepository;
        private ILogger _logger;

        public OrderServicesService(IOrderServicesRepository orderServicesRepository, ILogger logger)
        {
            _orderServicesRepository = orderServicesRepository;
            _logger = logger;
        }

        public void Create(OrderInfo orderInfo)
        {
            try
            {
                if (orderInfo.ServicesInfo.Count == 0) throw new ArgumentException();

                _orderServicesRepository.Create(orderInfo);
                
                foreach (var service in orderInfo.ServicesInfo)
                {
                    _logger.CreateLog("Database", "Insert", "OrderServices", new string[] { service.Id.ToString(), service.Name });
                }
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw;
            }
        }

        public List<ServiceInfo> Read(int id)
        {
            try
            {
                if (id < 0) throw new ArgumentOutOfRangeException();

                var services = _orderServicesRepository.Read(id);

                foreach (var service in services)
                {
                    _logger.CreateLog("Database", "Read", "OrderServices join Services", new string[] { service.Id.ToString(), service.Name });
                }

                return services;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw;
            }
        }
    }
}