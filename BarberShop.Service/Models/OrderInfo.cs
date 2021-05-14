using System;

namespace BarberShop.Service.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public Customer CustomerInfo { get; set; }
        public Employee EmployeeInfo { get; set; }
        public ShopAddress ShopAddressInfo { get; set; }
        public Payment[] PaymentsInfo { get; set; }
        public ServiceInfo[] ServicesInfo { get; set; }
        public DateTime OrderDate { get; set; }
    }
}