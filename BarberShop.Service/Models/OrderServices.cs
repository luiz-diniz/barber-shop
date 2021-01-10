using System.Collections.Generic;

namespace BarberShop.Service.Models
{
    public class OrderServices
    {
        public int Id { get; set; }
        public OrderInfo Order { get; set; }
        public List<ServiceInfo> Service { get; set; }
    }
}