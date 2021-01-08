using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Controllers
{
    [Route("api/orderservices")]
    [ApiController]
    public class OrderServicesController
    {
        private IOrderServicesService _orderServicesService;

        public OrderServicesController(IOrderServicesService orderServicesService)
        {
            _orderServicesService = orderServicesService;
        }

        [HttpPost]
        [Route("CreateOrderServices")]
        public void Create(OrderServices orderServices)
        {
        }

        [HttpDelete]
        [Route("DeleteOrderServices")]
        public void Delete(OrderServices orderServices)
        {
        }

        [HttpGet]
        [Route("ReadOrderServices/{id}]")]
        public OrderServices Read(string id)
        {
        }

        [HttpPut]
        [Route("UpdateOrderServices")]
        public void Update(OrderServices orderServices)
        {
        }
    }
}