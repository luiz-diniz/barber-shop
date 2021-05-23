﻿using BarberShop.Service.Models;
using System.Collections.Generic;

namespace BarberShop.Service.Repository.Interfaces.ModelsRepository
{
    public interface IPaymentRepository : ICRUD<Payment, Payment, string>
    {
    }
}
