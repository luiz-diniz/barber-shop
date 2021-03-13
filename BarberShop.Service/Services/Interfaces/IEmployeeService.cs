using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface IEmployeeService : ICRUDService<Employee, Employee, string>
    {
        List<Employee> GetAllEmployees(); 
    }
}