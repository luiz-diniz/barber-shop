using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using System;
using System.Data.SqlClient;
using System.Data;

namespace BarberShop.Service.Repository.ModelsRepository
{
    public class CustomerRepository : DatabaseConfiguration, ICustomerRepository
    {
        public void Create(Customer customer)
        {
            string query = "insert into Customer values(@P0, @P1, @P2, @P5)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", customer.Cpf));
                    cmd.Parameters.Add(new SqlParameter("P1", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("P2", customer.Birth));
                    cmd.Parameters.Add(new SqlParameter("P3", customer.Phone));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string type)
        {
            throw new NotImplementedException();
        }

        public Customer Read(string type)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer type)
        {
            throw new NotImplementedException();
        }
    }
}