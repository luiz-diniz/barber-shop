using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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

        public void Delete(Customer customer)
        {
            string query = "delete from customer where cpf_customer = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", customer.Cpf));

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
                        customer.Id = Convert.ToInt32(reader["id_customer"]);
                        customer.Cpf = Convert.ToString(reader["cpf_customer"]);
                        customer.Name = Convert.ToString(reader["name_customer"]);
                        customer.Birth = Convert.ToDateTime(reader["birth_customer"]);
                        customer.Phone = Convert.ToString(reader["phone_customer"]);
                    }

                    return customer;
                }
            }
        }

        public Customer Read(int id)
        {
            string query = "select * from customer where id_customer = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    var customer = new Customer();

                    if (reader.Read())
                    {
                        customer.Id = Convert.ToInt32(reader["id_customer"]);
                        customer.Cpf = Convert.ToString(reader["cpf_customer"]);
                        customer.Name = Convert.ToString(reader["name_customer"]);
                        customer.Birth = Convert.ToDateTime(reader["birth_customer"]);
                        customer.Phone = Convert.ToString(reader["phone_customer"]);
                    }

                    return customer;
                }
            }
        }

        public List<Customer> GetAll()
        {
            string query = "select * from Customer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Customer> customers = new List<Customer>();

                    while (reader.Read())
                    {
                        customers.Add(new Customer()
                        {
                            Id = Convert.ToInt32(reader["id_customer"]),
                            Cpf = Convert.ToString(reader["cpf_customer"]),
                            Name = Convert.ToString(reader["name_customer"]),
                            Birth = Convert.ToDateTime(reader["birth_customer"]),
                            Phone = Convert.ToString(reader["phone_customer"])
                    });
                    }

                    return customers;
                }
            }
        }

        public void Update(Customer customer)
        {
            string query = "update customer set cpf_customer = @P0, name_customer = @P1, birth_customer = @P2," +
                "phone_customer = @P3 where id_customer = @P4";

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
                    cmd.Parameters.Add(new SqlParameter("P4", customer.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }      
    }
}