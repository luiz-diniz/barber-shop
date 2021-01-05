using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;

namespace BarberShop.Service.Services
{
    public class ShopAddressService : IShopAddressService
    {
        private IShopAddressRepository _shopAddressRepository;

        public ShopAddressService(IShopAddressRepository shopAddressRepository)
        {
            _shopAddressRepository = shopAddressRepository;
        }

        public void Create(ShopAddressService type)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ShopAddressService type)
        {
            throw new System.NotImplementedException();
        }

        public ShopAddressService Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ShopAddressService type)
        {
            throw new System.NotImplementedException();
        }
    }
}