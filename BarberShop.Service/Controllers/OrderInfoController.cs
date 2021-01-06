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
    }
}
