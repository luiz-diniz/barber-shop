using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/orderpayment")]
    [ApiController]
    public class OrderPaymentController
    {
        private IOrderPaymentService _orderPaymentService;

        public OrderPaymentController(IOrderPaymentService orderPaymentService)
        {
            _orderPaymentService = orderPaymentService;
        }

        [HttpPost]
        [Route("CreateOrderPayment")]
        public void Create(OrderPayment orderPayment)
        {
            _orderPaymentService.Create(orderPayment);
        }

        [HttpDelete]
        [Route("DeleteOrderPayment")]
        public void Delete(OrderPayment orderPayment)
        {
            _orderPaymentService.Delete(orderPayment);
        }
    }
}
