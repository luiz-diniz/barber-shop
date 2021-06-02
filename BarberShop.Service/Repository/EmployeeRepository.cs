﻿using BarberShop.Service.Models;
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
            string query = "insert into employee values(@P0, @P1, @P2, @P3, @P4, default, @P5)";

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
                    cmd.Parameters.Add(new SqlParameter("P5", employee.UserType));

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

        public List<Employee> GetAll()
        {
            string query = "select id_employee, cpf_employee, name_employee, username_employee, user_type_employee from Employee";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        employees.Add(new Employee()
                        {
                            Id = Convert.ToInt32(reader["id_employee"]),
                            Cpf = Convert.ToString(reader["cpf_employee"]),
                            Name = Convert.ToString(reader["name_employee"]),
                            Username = Convert.ToString(reader["username_employee"]),
                            UserType = Convert.ToString(reader["user_type_employee"])
                        });
                    }

                    return employees;
                }
            }
        }

        public Employee Read(string cpf)
        {
            string query = "select id_employee, cpf_employee, name_employee, username_employee, user_type_employee from employee where cpf_employee = @P0";

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
                        employee.UserType = Convert.ToString(reader["user_type_employee"]);
                    }

                    return employee;
                }
            }
        }

        public Employee Read(int id)
        {
            string query = "select * from employee where id_employee = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    var employee = new Employee();

                    if (reader.Read())
                    {
                        employee.Id = Convert.ToInt32(reader["id_employee"]);
                        employee.Cpf = Convert.ToString(reader["cpf_employee"]);
                        employee.Name = Convert.ToString(reader["name_employee"]);
                        employee.Username = Convert.ToString(reader["username_employee"]);
                        employee.UserType = Convert.ToString(reader["user_type_employee"]);
                    }

                    return employee;
                }
            }
        }

        public void Update(Employee employee)
        {
            string query = "update employee set cpf_employee = @P0, name_employee = @P1, username_employee = @P2, user_type_employee = @P3 where id_employee = @P4";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", employee.Cpf));
                    cmd.Parameters.Add(new SqlParameter("P1", employee.Name));
                    cmd.Parameters.Add(new SqlParameter("P2", employee.Username));
                    cmd.Parameters.Add(new SqlParameter("P3", employee.UserType));
                    cmd.Parameters.Add(new SqlParameter("P4", employee.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
