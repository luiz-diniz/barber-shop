using System.Collections.Generic;

namespace BarberShop.Service.Services.Interfaces
{
    public interface ICRUDService<T, X, Z>
    {
        void Create(X type);
        T Read(Z type);
        T Read(int id);
        void Update(X type);
        void Delete(X type);
        List<T> GetAll();
    }
}