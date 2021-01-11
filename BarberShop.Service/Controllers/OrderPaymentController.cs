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
    }
}
