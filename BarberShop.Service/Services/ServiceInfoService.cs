﻿using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Services
{
    public class ServiceInfoService : IServiceInfoService
    {
        private IServiceInfoRepository _shopServiceRepository;
        private ILogger _logger;

        public ServiceInfoService(IServiceInfoRepository shopServiceRepository, ILogger logger)
        {
            _shopServiceRepository = shopServiceRepository;
            _logger = logger;
        }

        public void Create(ServiceInfo shopService)
        {
            try
            {
                _shopServiceRepository.Create(shopService);
            }
            catch (Exception ex)
            {
                _logger.CreateLog("Error", ex.Message);
            }
            finally
            {
                _logger.CreateLog("Database", "Insert", "ShopService", new List<string> { shopService.Name, shopService.Description, shopService.Value.ToString() });
            }
        }

        public void Delete(ServiceInfo shopService)
        {
            throw new System.NotImplementedException();
        }

        public ServiceInfo Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ServiceInfo shopService)
        {
            throw new System.NotImplementedException();
        }
    }
}