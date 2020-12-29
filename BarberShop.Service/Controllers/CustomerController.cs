using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
                
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public void Create(Customer customer)
        {
            _customerService.Create(customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{cpf}")]
        public void Delete(string cpf)
        {
            _customerService.Delete(cpf);
        }

        [HttpGet]
        [Route("ReadCustomer/{cpf}")]
        public Customer Read(string cpf)
        {
            return _customerService.Read(cpf);
        }

        //UpdateCustomer
        [HttpPut]
        [Route("UpdateCustomer")]
        public Customer Update(Customer customer)
        {
            return _customerService.Update(customer);
        }
    }
}