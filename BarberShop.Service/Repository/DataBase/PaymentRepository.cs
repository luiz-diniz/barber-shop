using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System;
using System.Collections.Generic;
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

        public void Delete(Payment payment)
        {
            string query = "delete from payment where name_payment = @P0";

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

        public List<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Payment Read(string name)
        {
            string query = "select * from payment where name_payment = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", name));

                    SqlDataReader reader = cmd.ExecuteReader();

                    Payment payment = new Payment();

                    if (reader.Read())
                    {
                        payment.Id = Convert.ToInt32(reader["id_payment"]);
                        payment.Name = Convert.ToString(reader["name_payment"]);
                    }

                    return payment;
                }
            }
        }

        public void Update(Payment payment) 
        {
            string query = "update payment set name_payment = @P0 where id_payment = @P1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@P0", payment.Name));
                    cmd.Parameters.Add(new SqlParameter("@P1", payment.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}