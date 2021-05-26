﻿using System.Collections.Generic;

namespace BarberShop.Service.Repository
{
    public interface ICRUD<T,X,Z>
    {
        void Create(X type);
        T Read(Z type);
        T Read(int id);
        void Update(X type);
        void Delete(X type);
        List<T> GetAll();
    }
}