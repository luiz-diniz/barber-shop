using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICRUDService<T, X>
    {
        void Create(X type);
        T Read(string type);
        T Update(X type);
        void Delete(string type);
    }
}