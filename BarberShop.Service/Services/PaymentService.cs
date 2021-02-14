using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        private ILogger _logger;

        public PaymentService(IPaymentRepository paymentRepository, ILogger logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public void Create(Payment payment)
        {
            try
            {
                if (payment == null) throw new ArgumentNullException();

                if (String.IsNullOrEmpty(payment.Name)) throw new ArgumentException();

                _paymentRepository.Create(payment);

                _logger.CreateLog("Database", "Create", "Payment", new string[] { payment.Name });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Delete(Payment payment)
        {
            try
            {
                if (payment == null) throw new ArgumentNullException();

                if (String.IsNullOrEmpty(payment.Name)) throw new ArgumentException();

                _paymentRepository.Delete(payment);

                _logger.CreateLog("Database", "Delete", "Payment", new string[] { payment.Name });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public Payment Read(string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name)) throw new ArgumentException();

                Payment payment = new Payment();

                payment = _paymentRepository.Read(name);

                _logger.CreateLog("Database", "Read", "Payment", new string[] { payment.Name });

                return payment;
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
        }

        public void Update(Payment payment)
        {
            try
            {
                if (payment == null) throw new ArgumentNullException();

                if (payment.Id < 0) throw new ArgumentException();
                if (String.IsNullOrEmpty(payment.Name)) throw new ArgumentException();

                _paymentRepository.Update(payment);

                _logger.CreateLog("Database", "Update", "Payment", new string[] { payment.Name });
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;                
            }
        }
    }
}