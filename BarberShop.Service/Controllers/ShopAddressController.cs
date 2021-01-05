using BarberShop.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Controllers
{
    public class ShopAddressController
    {
        private IShopAddressService _shopAddressService;

        public ShopAddressController(IShopAddressService shopAddressService)
        {
            _shopAddressService = shopAddressService;
        }
    }
}
