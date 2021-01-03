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

        //Customer table
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

        [HttpPut]
        [Route("UpdateCustomer")]
        public void Update(Customer customer)
        {
            _customerService.Update(customer);
        }

        //CustomerPhone table
        [HttpPost]
        [Route("CreateCustomerPhone")]
        public void CreatePhone(Customer customer)
        {
            _customerService.CreatePhone(customer);
        }

        [HttpDelete]
        [Route("DeleteCustomerPhone/{phone}")]
        public void DeletePhone(string phone)
        {
            _customerService.DeletePhone(phone);
        }

        [HttpGet]
        [Route("ReadCustomerPhone/{cpf}")]
        public List<string> ReadPhone(string cpf)
        {
            return _customerService.ReadPhone(cpf);
        }

        [HttpPut]
        [Route("UpdateCustomerPhone")]
        public void UpdatePhone(string[] phones)
        {
            _customerService.UpdatePhone(phones);
        }
    }
}