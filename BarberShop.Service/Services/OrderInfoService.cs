using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;

namespace BarberShop.Service.Services
{
    public class OrderInfoService : IOrderInfoService
    {
        public IOrderInfoRepository _orderInfoRepository{ get; set; }
        public ILogger _logger;

        public OrderInfoService(IOrderInfoRepository orderInfoRepository, ILogger logger)
        {
            _orderInfoRepository = orderInfoRepository;
            _logger = logger;
        }

        public void Create(OrderInfo orderInfo)
        {
            orderInfo.OrderDate = DateTime.Now;

            try
            {
                _orderInfoRepository.Create(orderInfo);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "OrderInfo", new string[] { orderInfo.EmployeeInfo.Cpf, orderInfo.EmployeeInfo.Cpf, orderInfo.ShopAddressInfo.Name, orderInfo.OrderDate.ToString() });
            }
        }

        public void Delete(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public OrderInfo Read(string orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
