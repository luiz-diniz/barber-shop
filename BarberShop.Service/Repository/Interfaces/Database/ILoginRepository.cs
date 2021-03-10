﻿using BarberShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Repository.Interfaces.Database
{
    public interface ILoginRepository
    {
        Employee GetEmployee(string username);
    }
}
