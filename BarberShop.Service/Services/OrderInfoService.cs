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
        public IOrderPaymentService _orderPaymentService;
        public IOrderServicesService _orderServicesService;
        public ILogger _logger;

        public OrderInfoService(IOrderInfoRepository orderInfoRepository, IOrderPaymentService orderPayment, IOrderServicesService orderService, ILogger logger)
        {
            _orderInfoRepository = orderInfoRepository;
            _orderPaymentService = orderPayment;
            _orderServicesService = orderService;
            _logger = logger;
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
            try
            {
                _orderInfoRepository.Delete(orderInfo);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "OrderInfo", new string[] { orderInfo.CustomerInfo.Cpf, orderInfo.EmployeeInfo.Cpf, orderInfo.ShopAddressInfo.Name, orderInfo.OrderDate.ToString() });
            }
        }

        public OrderInfo Read(int orderId)
        {
            OrderInfo orderInfo = new OrderInfo
            {
                CustomerInfo = new Customer(),
                EmployeeInfo = new Employee(),
                ShopAddressInfo = new ShopAddress(),
            };

            try
            {
                orderInfo = _orderInfoRepository.Read(orderId);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "OrderInfo", new string[] { orderId.ToString() });
            }

            return orderInfo;
        }

        public void Update(OrderInfo orderInfo)
        {
            try
            {
                _orderInfoRepository.Update(orderInfo);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "OrderInfo", new string[] { orderInfo.CustomerInfo.Cpf, orderInfo.EmployeeInfo.Cpf, orderInfo.ShopAddressInfo.Name, orderInfo.OrderDate.ToString() });
            }
        }

        public List<OrderInfo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}