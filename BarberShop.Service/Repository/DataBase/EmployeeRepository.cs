using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;

namespace BarberShop.Service.Repository.Database
{
    public class EmployeeRepository : DatabaseConfiguration, IEmployeeRepository
    {
        public void Create(Employee type)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string type)
        {
            throw new System.NotImplementedException();
        }

        public Employee Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public Employee Update(Employee type)
        {
            throw new System.NotImplementedException();
        }
    }
}
