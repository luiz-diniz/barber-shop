using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using BarberShop.Service.Utilities;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class OrderInfoService : IOrderInfoService
    {
        public IOrderInfoRepository _orderInfoRepository;
        public IOrderServicesService _orderServicesService;
        public ILogger _logger;

        public OrderInfoService(IOrderInfoRepository orderInfoRepository, IOrderServicesService orderService, ILogger logger)
        {
            _orderInfoRepository = orderInfoRepository;
            _orderServicesService = orderService;
            _logger = logger;
        }

        public void CreateOrder(OrderInfo orderInfo)
        {
            try
            {
                if (orderInfo == null) throw new ArgumentNullException();

                if (orderInfo.CustomerInfo == null ||
                    orderInfo.EmployeeInfo == null ||
                    orderInfo.ShopAddressInfo == null ||
                    orderInfo.PaymentInfo == null ||
                    orderInfo.ServicesInfo == null) throw new ArgumentException();

                orderInfo.OrderDate = DateTime.Now;

                orderInfo.Id = _orderInfoRepository.CreateOrder(orderInfo);
                
                _orderServicesService.Create(orderInfo);

                _logger.CreateLog("Database", "Insert", "OrderInfo", new string[] { orderInfo.CustomerInfo.Cpf, orderInfo.EmployeeInfo.Cpf, orderInfo.ShopAddressInfo.Name, orderInfo.OrderDate.ToString() });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Create(OrderInfo orderInfo)
        {
            try
            {
                if (orderInfo == null) throw new ArgumentNullException();

                if (orderInfo.CustomerInfo == null ||
                    orderInfo.EmployeeInfo == null ||
                    orderInfo.ShopAddressInfo == null) throw new ArgumentException();

                orderInfo.OrderDate = DateTime.Now;

                _logger.CreateLog("Database", "Insert", "OrderInfo", new string[] { orderInfo.CustomerInfo.Cpf, orderInfo.EmployeeInfo.Cpf, orderInfo.ShopAddressInfo.Name, orderInfo.OrderDate.ToString() });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Delete(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public OrderInfo Read(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public List<OrderInfo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}