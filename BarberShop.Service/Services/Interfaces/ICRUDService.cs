namespace BarberShop.Service.Services.Interfaces
{
    public interface ICRUDService<T, X>
    {
        void Create(X type);
        T Read(string type);
        void Update(X type);
        void Delete(X type);
    }
}