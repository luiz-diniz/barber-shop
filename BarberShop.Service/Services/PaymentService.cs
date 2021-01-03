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
                _paymentRepository.Create(payment);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Create", "Payment", new List<string> { payment.Name });
            }
        }

        public void Delete(Payment payment)
        {
            try
            {
                _paymentRepository.Delete(payment);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "Payment", new List<string> { payment.Name });
            }
        }

        public Payment Read(string name)
        {
            Payment payment = new Payment();

            try
            {
                payment = _paymentRepository.Read(name);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "Payment", new List<string> { payment.Name });
            }

            return payment;
        }

        public void Update(Payment payment)
        {
            try
            {
                _paymentRepository.Update(payment);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "Payment", new List<string> { payment.Name });
            }
        }
    }
}