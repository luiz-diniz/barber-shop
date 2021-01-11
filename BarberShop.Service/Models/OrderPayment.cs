using System.Collections.Generic;

namespace BarberShop.Service.Models
{
    public class OrderPayment
    {
        public int Id { get; set; }
        public List<Payment> PaymentInfo{ get; set; }
        public OrderInfo Order { get; set; }
    }
}