using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data.SqlClient;
using System.Data;

namespace BarberShop.Service.Repository.Database
{
    public class ShopServiceRepository : DatabaseConfiguration, IServiceInfoRepository
    {
        public void Create(ServiceInfo shopService)
        {
            string query = "insert into shopservice values(@P0, @P1, @P2)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", shopService.Name));
                    cmd.Parameters.Add(new SqlParameter("P1", shopService.Description));
                    cmd.Parameters.Add(new SqlParameter("P3", shopService.Value));
                }
            }
        }

        public void Delete(ServiceInfo shopService)
        {
            throw new System.NotImplementedException();
        }

        public ServiceInfo Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ServiceInfo shopService)
        {
            throw new System.NotImplementedException();
        }
    }
}
