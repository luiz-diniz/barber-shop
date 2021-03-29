﻿using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarberShop.Service.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Create(Employee employee)
        {
             _employeeService.Create(employee);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult Delete(Employee employee)
        {
            _employeeService.Delete(employee);
            return Ok();
        }

        [HttpGet]
        [Route("ReadEmployee/{cpf}")]
        public Employee Read(string cpf)
        {
            return _employeeService.Read(cpf);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return _employeeService.GetAll();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public void Update(Employee employee)
        {
            _employeeService.Update(employee);
        }
    }
}