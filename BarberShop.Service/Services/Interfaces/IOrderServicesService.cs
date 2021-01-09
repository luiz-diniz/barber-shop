using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface IOrderServicesService : ICRUDService<List<ServiceInfo>, OrderServices, int>
    {
    }
}