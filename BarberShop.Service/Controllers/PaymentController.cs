using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController
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
    }
}
