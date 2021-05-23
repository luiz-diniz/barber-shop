using System;
using System.Collections.Generic;

namespace BarberShop.Service.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public Customer CustomerInfo { get; set; }
        public Employee EmployeeInfo { get; set; }
        public ShopAddress ShopAddressInfo { get; set; }
        public Payment PaymentInfo { get; set; }
        public List<ServiceInfo> ServicesInfo { get; set; }
        public DateTime OrderDate { get; set; }
    }
}