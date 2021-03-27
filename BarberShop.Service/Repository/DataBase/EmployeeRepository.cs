using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BarberShop.Service.Repository.Database
{
    public class EmployeeRepository : DatabaseConfiguration, IEmployeeRepository
    {
        public void Create(Employee employee)
        {
            string query = "insert into employee values(@P0, @P1, @P2, @P3, @P4, default)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", employee.Cpf));
                    cmd.Parameters.Add(new SqlParameter("P1", employee.Name));
                    cmd.Parameters.Add(new SqlParameter("P2", employee.Username));
                    cmd.Parameters.Add(new SqlParameter("P3", employee.Password));
                    cmd.Parameters.Add(new SqlParameter("P4", employee.SaltPassword));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Employee employee)
        {
            string query = "delete from employee where cpf_employee = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", employee.Cpf));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Employee Read(string cpf)
        {
            string query = "select id_employee, cpf_employee, name_employee, username_employee from employee where cpf_employee = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", cpf));

                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee employee = new Employee();

                    if(reader.Read())
                    {
                        employee.Id = Convert.ToInt32(reader["id_employee"]);
                        employee.Cpf = Convert.ToString(reader["cpf_employee"]);
                        employee.Name = Convert.ToString(reader["name_employee"]);
                        employee.Username = Convert.ToString(reader["username_employee"]);
                    }

                    return employee;
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            string query = "select id_employee, cpf_employee, name_employee, username_employee from Employee";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    List<Employee> employees = new List<Employee>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employees.Add(new Employee()
                        {
                            Id = Convert.ToInt32(reader["id_employee"]),
                            Cpf = Convert.ToString(reader["cpf_employee"]),
                            Name = Convert.ToString(reader["name_employee"]),
                            Username = Convert.ToString(reader["username_employee"])
                        });
                    }

                    return employees;
                }
            }
        }

        public void Update(Employee employee)
        {
            string query = "update employee set cpf_employee = @P0, name_employee = @P1, username_employee = @P2 where id_employee = @P3";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", employee.Cpf));
                    cmd.Parameters.Add(new SqlParameter("P1", employee.Name));
                    cmd.Parameters.Add(new SqlParameter("P2", employee.Username));
                    cmd.Parameters.Add(new SqlParameter("P3", employee.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
