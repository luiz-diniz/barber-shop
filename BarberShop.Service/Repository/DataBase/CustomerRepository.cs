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
            string query = "insert into customer values(@P0, @P1, @P2, @P3)";

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

        public void Delete(string cpf)
        {
            string query = "delete from customer where cpf_customer = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", cpf));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Customer Read(string cpf)
        {
            string query = "select * from customer where cpf_customer = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", cpf));

                    SqlDataReader reader = cmd.ExecuteReader();

                    Customer customer = new Customer();

                    if (reader.Read())
                    {
                        customer.Cpf = Convert.ToString(reader["cpf_customer"]);
                        customer.Name = Convert.ToString(reader["name_customer"]);
                        customer.Birth = Convert.ToDateTime(reader["birth_customer"]);
                        customer.Phone = Convert.ToString(reader["phone_customer"]);
                    }

                    return customer;
                }
            }
        }

        public Customer Update(Customer customer)
        {
            string query = "update customer set name_customer = @P0, birth_customer = @P1, phone_customer = @P2 where " +
                "cpf_customer = @P3";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("P1", customer.Birth));
                    cmd.Parameters.Add(new SqlParameter("P2", customer.Phone));
                    cmd.Parameters.Add(new SqlParameter("P3", customer.Cpf));

                    cmd.ExecuteNonQuery();

                    return customer;
                }
            }
        }
    }
}