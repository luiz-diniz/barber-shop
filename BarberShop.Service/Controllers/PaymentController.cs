using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("CreatePayment")]
        public void Create(Payment payment)
        {
            _paymentService.Create(payment);
        }

        [HttpDelete]
        [Route("DeletePayment")]
        public void Delete(Payment payment)
        {
            _paymentService.Delete(payment);
        }

        [HttpGet]
        [Route("ReadPayment/{payment}")]
        public Payment Read(string payment)
        {
            return _paymentService.Read(payment);
        }

        [HttpPut]
        [Route("UpdatePayment")]
        public void Update(Payment payment)
        {
            _paymentService.Update(payment);
        }
    }
}