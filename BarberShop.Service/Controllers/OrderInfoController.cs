﻿using BarberShop.Service.Models;
using BarberShop.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            _orderInfoService.CreateOrder(orderInfo);
        }

        [HttpDelete]
        [Route("DeleteOrderInfo")]
        public void Delete(OrderInfo orderInfo)
        {
            _orderInfoService.Delete(orderInfo);
        }

        [HttpGet]
        [Route("ReadOrderInfo/{orderId}")]
        public OrderInfo Read(int orderId)
        {
            return _orderInfoService.Read(orderId);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<OrderInfo> GetAll()
        {
            return _orderInfoService.GetAll();
        }

        [HttpPut]
        [Route("UpdateOrderInfo")]
        public void Update(OrderInfo orderInfo)
        {
            _orderInfoService.Update(orderInfo);
        }
    }
}
