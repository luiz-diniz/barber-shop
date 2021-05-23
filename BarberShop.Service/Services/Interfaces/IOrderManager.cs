using BarberShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Services.Interfaces
{
    public interface IOrderManager
    {
        void CreateOrder(OrderInfo orderInfo);
    }
}