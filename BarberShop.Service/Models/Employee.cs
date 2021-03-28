namespace BarberShop.Service.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SaltPassword { get; set; }
        public int LoginAttempts { get; set; }
    }
}