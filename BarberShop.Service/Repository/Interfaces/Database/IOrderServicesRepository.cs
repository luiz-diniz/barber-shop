using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Repository.Interfaces.ModelsRepository
{
    public interface IOrderServicesRepository
    {
        void Create(OrderInfo orderInfo);
        List<ServiceInfo> Read(int orderId);
    }
}
