using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Models
{
    public class OrderPayment
    {
        public int Id { get; set; }
        public Payment PaymentInfo{ get; set; }
        public OrderInfo Order { get; set; }
    }
}
