using BarberShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Repository.Interfaces.ModelsRepository
{
    public interface IOrderPaymentRepository : ICRUD<OrderPayment, OrderPayment, int>
    {
    }
}
