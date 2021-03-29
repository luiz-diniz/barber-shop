﻿using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICRUDService<T, X, Z>
    {
        void Create(X type);
        T Read(Z type);
        void Update(X type);
        void Delete(X type);
        List<T> GetAll();
    }
}