using System;
using System.Collections.Generic;

namespace BarberShop.Service.Models
{
    public class Customer
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public List<string> Phone { get; set; }
    }
}