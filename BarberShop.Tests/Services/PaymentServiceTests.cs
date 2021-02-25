using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BarberShop.Tests
{
    public class PaymentServiceTests
    {
        private Mock<IPaymentRepository> _paymentRepository;
        private Mock<ILogger> _logger;
        private int _id = 666;
        private string _name = "Money";

        public PaymentServiceTests()
        {
            _paymentRepository = new Mock<IPaymentRepository>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void CreatePaymentNullTest()
        {
            Payment payment = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(payment));

            _logger.Verify();
        }

        [Fact]
        public void CreatePaymentNameNullTest()
        {
            Payment payment = new Payment
            {
                Name = null
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(payment));

            _logger.Verify();
        }

        [Fact]
        public void CreatePaymentNameEmptyTest()
        {
            Payment payment = new Payment
            {
                Name = ""
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(payment));

            _logger.Verify();
        }

        [Fact]
        public void CreatePaymentTest()
        {
            Payment payment = new Payment
            {
                Name = "Credit Card"
            };

            _logger.Setup(x => x.CreateLog("Database", "Create", "Payment", new string[] { payment.Name }));
            _paymentRepository.Setup(x => x.Create(payment));

            var instance = GetInstance();

            instance.Create(payment);

            _logger.Verify();
            _paymentRepository.Verify();
        }

        [Fact]
        public void DeletePaymentNullTest()
        {
            Payment payment = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Delete(payment));

            _logger.Verify();
        }

        [Fact]
        public void DeletePaymentNameNullTest()
        {
            Payment payment = new Payment()
            {
                Name = null
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(payment));

            _logger.Verify();
        }

        [Fact]
        public void DeletePaymentNameEmptyTest()
        {
            Payment payment = new Payment()
            {
                Name = ""
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Delete(payment));

            _logger.Verify();
        }

        [Fact]
        public void DeletePaymentTest()
        {
            Payment payment = new Payment()
            {
                Id = _id,
                Name = _name
            };

            _logger.Setup(x => x.CreateLog("Database", "Delete", "Payment", new string[] { payment.Name }));
            _paymentRepository.Setup(x => x.Delete(payment));

            var instance = GetInstance();

            instance.Delete(payment);

            _logger.Verify();
            _paymentRepository.Verify();
        }

        [Fact]
        public void ReadPaymentNameNullTest()
        {
            string name = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(name));

            _logger.Verify();
        }

        [Fact]
        public void ReadPaymentNameEmptyTest()
        {
            string name = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(name));

            _logger.Verify();
        }

        [Fact]
        public void ReadPaymentTest()
        {
            string name = "Money";

            Payment payment = new Payment()
            {
                Id = _id,
                Name = _name
            };

            _logger.Setup(x => x.CreateLog("Database", "Read", "Payment", new string[] { payment.Name }));
            _paymentRepository.Setup(x => x.Read(name)).Returns(payment);

            var instance = GetInstance();

            instance.Read(name);

            _logger.Verify();
            _paymentRepository.Verify();
        }

        [Fact]
        public void UpdatePaymentNullTest()
        {
            Payment payment = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Update(payment));

            _logger.Verify();
        }

        [Fact]
        public void UpdatePaymentIdLessThanZeroTest()
        {
            Payment payment = new Payment()
            {
                Id = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(payment));

            _logger.Verify();
        }

        [Fact]
        public void UpdatePaymentNameNullTest()
        {
            Payment payment = new Payment()
            {
                Name = null
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(payment));

            _logger.Verify();
        }

        [Fact]
        public void UpdatePaymentNameEmptyTest()
        {
            Payment payment = new Payment()
            {
                Name = ""
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(payment));

            _logger.Verify();
        }

        [Fact]
        public void UpdatePaymentTest()
        {
            Payment payment = new Payment()
            {
                Id = _id,
                Name = _name
            };

            _logger.Setup(x => x.CreateLog("Database", "Update", "Payment", new string[] { payment.Name }));
            _paymentRepository.Setup(x => x.Update(payment));

            var instance = GetInstance();

            instance.Update(payment);

            _logger.Verify();
            _paymentRepository.Verify();
        }

        private PaymentService GetInstance()
        {
            return new PaymentService(_paymentRepository.Object, _logger.Object);
        }
    }
}
