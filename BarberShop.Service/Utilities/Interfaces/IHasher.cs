namespace BarberShop.Service.Utilities
{
    public interface IHasher
    {
        string GenerateHash(string input, string salt);
        string CreateSalt(int saltSize);
    }
}
