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

        public string Teste { get; set; }

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

        public List<Customer> GetAllCustomers()
        {
            string query = "select id_customer, cpf_customer, name_customer, birth_customer from Customer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<Customer> employees = new List<Customer>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employees.Add(new Customer()
                        {
                            Id = Convert.ToInt32(reader["id_customer"]),
                            Cpf = Convert.ToString(reader["cpf_customer"]),
                            Name = Convert.ToString(reader["name_customer"]),
                            Birth = Convert.ToDateTime(reader["birth_customer"])
                        });
                    }

                    return employees;
                }
            }
        }

        public void Update(Customer customer)
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

        public List<string> ReadPhone(string cpf)
        {
            string query = "select p.phone_customer from CustomerPhone p inner join Customer c on p.id_customer = c.id_customer where c.cpf_customer = @P0";
            List<string> phones = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", cpf));

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

        public void UpdatePhone(string[] phone)
        {
            string query = "update CustomerPhone set phone_customer = @P0 where phone_customer = @P1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", phone[1]));
                    cmd.Parameters.Add(new SqlParameter("P1", phone[0]));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}