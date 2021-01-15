using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;

namespace BarberShop.Service.Services
{
    public class OrderPaymentService : IOrderPaymentService
    {
        private IOrderPaymentRepository _orderPaymentRepository;
        private ILogger _logger;

        public OrderPaymentService(IOrderPaymentRepository orderPaymentRepository, ILogger logger)
        {
            _orderPaymentRepository = orderPaymentRepository;
            _logger = logger;
        }

        public void Create(OrderPayment orderPayment)
        {            
            try
            {
                _orderPaymentRepository.Create(orderPayment);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
                throw ex;
            }
            finally
            {
                for (int i = 0; i < orderPayment.PaymentInfo.Count; i++)
                {
                    _logger.CreateLog("Database", "Insert", "OrderPayment", new string[] { orderPayment.Id.ToString(), orderPayment.Order.Id.ToString(), orderPayment.PaymentInfo[i].Id.ToString() });
                }
            }
        }

        public void Delete(OrderPayment orderPayment)
        {
            try
            {
                _orderPaymentRepository.Delete(orderPayment);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Delete", "OrderPayment", new string[] { orderPayment.Id.ToString(), orderPayment.Order.Id.ToString(), orderPayment.PaymentInfo[0].Id.ToString() });
            }
        }

        public OrderPayment Read(int orderId)
        {
            OrderPayment orderPayment = new OrderPayment();

            try
            {
                orderPayment = _orderPaymentRepository.Read(orderId);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Read", "OrderPayment", new string[] { orderId.ToString() });
            }

            return orderPayment;
        }

        public void Update(OrderPayment orderPayment)
        {
            try
            {
                _orderPaymentRepository.Update(orderPayment);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.ToString());
            }
            finally
            {
                _logger.CreateLog("Database", "Update", "OrderPayment", new string[] { orderPayment.Order.Id.ToString(), orderPayment.PaymentInfo[0].Id.ToString(), orderPayment.PaymentInfo[1].Id.ToString() });
            }
        }
    }
}