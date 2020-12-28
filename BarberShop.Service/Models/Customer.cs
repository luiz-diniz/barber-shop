using System;

namespace BarberShop.Service.Models
{
    public class Customer
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Phone { get; set; }
    }
}
