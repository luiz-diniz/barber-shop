using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/shopservice")]
    [ApiController]
    public class ServiceInfoController
    {
        private IServiceInfoService _shopServiceService;

        public ServiceInfoController(IServiceInfoService shopServiceService)
        {
            _shopServiceService = shopServiceService;
        }

        [HttpPost]
        [Route("CreateShopService")]
        private void Create(ServiceInfo shopService)
        {
            _shopServiceService.Create(shopService);
        }
    }
}
