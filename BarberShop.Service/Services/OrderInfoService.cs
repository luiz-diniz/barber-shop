using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;

namespace BarberShop.Service.Services
{
    public class OrderInfoService : IOrderInfoService
    {
        public IOrderInfoRepository _orderInfoRepository{ get; set; }
        public OrderInfoService(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }

        public void Create(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
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
