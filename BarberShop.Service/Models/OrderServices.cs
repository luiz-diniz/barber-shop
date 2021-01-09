using System.Collections.Generic;

namespace BarberShop.Service.Models
{
    public class OrderServices
    {
        public int Id { get; set; }
        public OrderInfo Order { get; set; }
        public ServiceInfo Service { get; set; }
    }
}
