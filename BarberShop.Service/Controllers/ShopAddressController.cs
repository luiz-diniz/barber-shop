using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Service.Controllers
{
    [Route("api/shopaddress")]
    [ApiController]
    public class ShopAddressController : Controller
    {
        private IShopAddressService _shopAddressService;

        public ShopAddressController(IShopAddressService shopAddressService)
        {
            _shopAddressService = shopAddressService;
        }

        [HttpPost]
        [Route("CreateShopAddress")]
        public void Create(ShopAddress shopAddress)
        {
            _shopAddressService.Create(shopAddress);
        }

        [HttpDelete]
        [Route("DeleteShopAddress")]
        public void Delete(ShopAddress shopAddress)
        {
            _shopAddressService.Delete(shopAddress);
        }

        [HttpGet]
        [Route("ReadShopAddress/{name}")]
        public ShopAddress Read(string name)
        {
            return _shopAddressService.Read(name);
        }
    }
}