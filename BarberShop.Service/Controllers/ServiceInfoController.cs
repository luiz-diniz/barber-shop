using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/serviceinfo")]
    [ApiController]
    public class ServiceInfoController
    {
        private IServiceInfoService _serviceInfoService;

        public ServiceInfoController(IServiceInfoService serviceInfoService)
        {
            _serviceInfoService = serviceInfoService;
        }

        [HttpPost]
        [Route("CreateServiceInfo")]
        public void Create(ServiceInfo shopService)
        {
            _serviceInfoService.Create(shopService);
        }

        [HttpDelete]
        [Route("DeleteServiceInfo")]
        public void Delete(ServiceInfo shopService)
        {
            _serviceInfoService.Delete(shopService);
        }

        [HttpGet]
        [Route("ReadServiceInfo/{name}")]
        public ServiceInfo Read(string name)
        {
            return _serviceInfoService.Read(name);
        }

        [HttpPut]
        [Route("UpdateServiceInfo")]
        public void Update(ServiceInfo serviceInfo)
        {
            _serviceInfoService.Update(serviceInfo);
        }
    }
}