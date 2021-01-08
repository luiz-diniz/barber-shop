using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;

namespace BarberShop.Service.Services
{
    public class OrderServicesService : IOrderServicesService
    {
        private IOrderServicesRepository _orderServicesRepository;

        public OrderServicesService(IOrderServicesRepository orderServicesRepository)
        {
            _orderServicesRepository = orderServicesRepository;
        }

        public void Create(OrderServices type)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(OrderServices type)
        {
            throw new System.NotImplementedException();
        }

        public OrderServices Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public void Update(OrderServices type)
        {
            throw new System.NotImplementedException();
        }
    }
}
