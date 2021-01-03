namespace BarberShop.Service.Repository
{
    public interface ICRUD<T,X>
    {
        void Create(X type);
        T Read(string type);
        void Update(X type);
        void Delete(X type);
    }
}