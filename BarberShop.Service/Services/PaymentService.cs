using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;

namespace BarberShop.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void Create(Payment payment)
        {
            _paymentRepository.Create(payment);
        }

        public void Delete(Payment payment)
        {
            throw new System.NotImplementedException();
        }

        public Payment Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Payment payment)
        {
            throw new System.NotImplementedException();
        }
    }
}
