using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [Route("DeleteCustomer")]
        public void Delete(Customer customer)
        {
            _customerService.Delete(customer);
        }

        [HttpGet]
        [Route("ReadCustomer/{cpf}")]
        public Customer Read(string cpf)
        {
            return _customerService.Read(cpf);
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAll();
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public void Update(Customer customer)
        {
            _customerService.Update(customer);
        }
    }
}