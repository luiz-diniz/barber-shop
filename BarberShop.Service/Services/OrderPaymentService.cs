using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;

namespace BarberShop.Service.Services
{
    public class OrderPaymentService : IOrderPaymentService
    {
        private IOrderPaymentRepository _orderPaymentRepository;

        public OrderPaymentService(IOrderPaymentRepository orderPaymentRepository)
        {
            _orderPaymentRepository = orderPaymentRepository;
        }

        public void Create(OrderPayment orderPayment)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderPayment orderPayment)
        {
            throw new NotImplementedException();
        }

        public OrderPayment Read(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderPayment orderPayment)
        {
            throw new NotImplementedException();
        }
    }
}