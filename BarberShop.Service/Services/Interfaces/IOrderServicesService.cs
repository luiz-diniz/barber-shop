using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface IOrderServicesService
    {
        void Create(OrderInfo orderInfo);
        List<ServiceInfo> GetAll(List<OrderInfo> orderInfoList);
    }
}