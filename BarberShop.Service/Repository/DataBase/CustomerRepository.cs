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
        //Customer
        public void Create(Customer customer)
        {
            string query = "insert into customer values(@P0, @P1, @P2)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", customer.Cpf));
                    cmd.Parameters.Add(new SqlParameter("P1", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("P2", customer.Birth));

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
                    }

                    return customer;
                }
            }
        }

        public Customer Update(Customer customer)
        {
            string query = "update customer set cpf_customer = @P0, name_customer = @P1, birth_customer = @P2 where " +
                "id_customer = @P3";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", customer.Cpf));
                    cmd.Parameters.Add(new SqlParameter("P1", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("P2", customer.Birth));
                    cmd.Parameters.Add(new SqlParameter("P3", customer.Id));

                    cmd.ExecuteNonQuery();

                    return customer;
                }
            }
        }

        //CustomerPhone
        public void CreatePhone(Customer customer)
        {
            for (int i = 0; i < customer.Phone.Count; i++)
            {
                string query = "insert into customerPhone values(@P0, @P1)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SqlParameter("P0", customer.Id));
                        cmd.Parameters.Add(new SqlParameter("P1", customer.Phone[i]));

                        cmd.ExecuteNonQuery();
                    }
                } 
            }
        }

        public void DeletePhone(string phone)
        {
            string query = "delete from customerPhone where phone_customer = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", phone));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAllPhones(int id)
        {
            string query = "delete from customerPhone where id_customer = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<string> ReadPhone(int id)
        {
            string query = "select phone_customer from customerPhone where id_customer = @P0";
            List<string> phones = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    Customer customer = new Customer();

                    while(reader.Read())
                    {
                        phones.Add(Convert.ToString(reader["phone_customer"]));
                    }

                    return phones;
                }
            }
        }

        public Customer UpdatePhone(Customer customerPhone)
        {
            throw new NotImplementedException();
        }       
    }
}