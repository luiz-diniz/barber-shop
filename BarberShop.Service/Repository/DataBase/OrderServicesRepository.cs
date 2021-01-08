using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data.SqlClient;
using System.Data;

namespace BarberShop.Service.Repository.Database
{
    public class OrderServicesRepository : DatabaseConfiguration, IOrderServicesRepository
    {
        public void Create(OrderServices orderServices)
        {
            string query = "insert into orderServices values (@P0, @P1)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderServices.Order.Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderServices.Service.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(OrderServices type)
        {
            throw new System.NotImplementedException();
        }

        public OrderServices Read(string type)
        {
            throw new System.NotImplementedException();
        }

        public void Update(OrderServices type)
        {
            throw new System.NotImplementedException();
        }
    }
}
