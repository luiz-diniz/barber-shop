using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/orderinfo")]
    [ApiController]
    public class OrderInfoController : Controller
    {
        public IOrderInfoService _orderInfoService { get; set; }

        public OrderInfoController(IOrderInfoService orderInfoService)
        {
            _orderInfoService = orderInfoService;
        }

        [HttpPost]
        [Route("CreateOrderInfo")]
        public void Create(OrderInfo orderInfo)
        {
            _orderInfoService.Create(orderInfo);
        }

        [HttpDelete]
        [Route("DeleteOrderInfo")]
        public void Delete(OrderInfo orderInfo)
        {
            _orderInfoService.Delete(orderInfo);
        }

        [HttpGet]
        [Route("ReadOrderInfo")]
        public void Read(string orderId)
        {
            _orderInfoService.Read(orderId);
        }

        [HttpPut]
        [Route("UpdateOrderInfo")]
        public void Update(OrderInfo orderInfo)
        {
            _orderInfoService.Update(orderInfo);
        }
    }
}
