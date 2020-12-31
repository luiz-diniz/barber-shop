using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public void Create(Employee employee)
        {
            _employeeService.Create(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{cpf}")]
        public void Delete(string cpf)
        {
            _employeeService.Delete(cpf);
        }

        [HttpGet]
        [Route("ReadEmployee/{cpf}")]
        public Employee Read(string cpf)
        {
            return _employeeService.Read(cpf);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public Employee Update(Employee employee)
        {
            return _employeeService.Update(employee);
        }
    }
}