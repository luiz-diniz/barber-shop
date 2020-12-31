namespace BarberShop.Service.Models
{
    public class CustomerPhone
    {
        public int Id { get; set; }
        public Customer CustomerInfo { get; set; }
        public string Phone { get; set; }
    }
}
