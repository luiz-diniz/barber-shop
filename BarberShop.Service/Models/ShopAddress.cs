using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Models
{
    public class ShopAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
