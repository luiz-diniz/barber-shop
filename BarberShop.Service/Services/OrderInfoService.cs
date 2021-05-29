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
        public ICustomerService _customerService;
        public IEmployeeService _employeeService;
        public ILogger _logger;

        public OrderInfoService(IOrderInfoRepository orderInfoRepository, 
            IOrderServicesService orderService, 
            ICustomerService customerService,
            IEmployeeService employeeService,
            ILogger logger)
        {
            _orderInfoRepository = orderInfoRepository;
            _orderServicesService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;
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

        public List<OrderInfo> GetAll()
        {
            try
            {
                var result = _orderInfoRepository.GetAll();

                foreach(var orderInfo in result)
                {
                    orderInfo.CustomerInfo = _customerService.Read(orderInfo.CustomerInfo.Id);
                    orderInfo.EmployeeInfo = _employeeService.Read(orderInfo.EmployeeInfo.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw;
            }
        }

        public void Update(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}