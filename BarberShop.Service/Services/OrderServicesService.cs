using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;

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

        public void Create(OrderServices orderServices)
        {
            try
            {
                _orderServicesRepository.Create(orderServices);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "OrderServices", new string[] { orderServices.Id.ToString(), orderServices.Order.Id.ToString(), orderServices.Service.Id.ToString() });
            }
        }

        public void Delete(OrderServices orderServices)
        {
            try
            {
                _orderServicesRepository.Delete(orderServices);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "OrderServices", new string[] { orderServices.Id.ToString(), orderServices.Order.Id.ToString(), orderServices.Service.Id.ToString() });
            }
        }

        public OrderServices Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public void Update(OrderServices type)
        {
            throw new System.NotImplementedException();
        }
    }
}
