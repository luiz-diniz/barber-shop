using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Tests
{
    class PaymentServiceTests
    {
        private Mock<IPaymentRepository> _paymentRepository;
        private Mock<ILogger> _logger;

        public PaymentServiceTests()
        {
            _paymentRepository = new Mock<IPaymentRepository>();
            _logger = new Mock<ILogger>();
        }



        private PaymentService GetInstance()
        {
            return new PaymentService(_paymentRepository.Object, _logger.Object);
        }
    }
}
