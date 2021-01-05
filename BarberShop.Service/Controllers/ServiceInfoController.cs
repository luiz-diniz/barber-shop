using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/serviceinfo")]
    [ApiController]
    public class ServiceInfoController
    {
        private IServiceInfoService _shopServiceService;

        public ServiceInfoController(IServiceInfoService shopServiceService)
        {
            _shopServiceService = shopServiceService;
        }

        [HttpPost]
        [Route("CreateServiceInfo")]
        public void Create(ServiceInfo shopService)
        {
            _shopServiceService.Create(shopService);
        }

        [HttpDelete]
        [Route("DeleteServiceInfo")]
        public void Delete(ServiceInfo shopService)
        {
            _shopServiceService.Delete(shopService);
        }

        //Read
        //Update
    }
}