using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data;
using System.Data.SqlClient;

namespace BarberShop.Service.Repository.Database
{
    public class PaymentRepository : DatabaseConfiguration, IPaymentRepository
    {
        public void Create(Payment payment)
        {
            string query = "insert into payment values(@P0)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", payment.Name));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Payment name)
        {
            throw new System.NotImplementedException();
        }

        public Payment Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Payment payment)
        {
            throw new System.NotImplementedException();
        }
    }
}
