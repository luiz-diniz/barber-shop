using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            _orderServicesService.Create(orderServices);
        }

        [HttpDelete]
        [Route("DeleteOrderServices")]
        public void Delete(OrderServices orderServices)
        {
            _orderServicesService.Delete(orderServices);
        }

        [HttpGet]
        [Route("ReadOrderServices/{orderInfoId}")]
        public OrderServices Read(int orderInfoId)
        {
            return _orderServicesService.Read(orderInfoId);
        }

        [HttpPut]
        [Route("UpdateOrderServices")]
        public void Update(OrderServices orderServices)
        {
            _orderServicesService.Update(orderServices);
        }
    }
}