namespace BarberShop.Service.Repository
{
    public interface ICRUD<T,X>
    {
        void Create(X type);
        T Read(string type);
        T Update(X type);
        void Delete(string type);
    }
}