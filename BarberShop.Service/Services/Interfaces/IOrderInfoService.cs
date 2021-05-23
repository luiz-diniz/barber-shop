using BarberShop.Service.Models;

namespace BarberShop.Service.Services.Interfaces
{
    public interface IOrderInfoService : IOrderManager, ICRUDService<OrderInfo, OrderInfo, int>
    {
    }
}