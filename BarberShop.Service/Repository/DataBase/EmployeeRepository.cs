using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data;
using System.Data.SqlClient;

namespace BarberShop.Service.Repository.Database
{
    public class EmployeeRepository : DatabaseConfiguration, IEmployeeRepository
    {
        public void Create(Employee employee)
        {
            string query = "insert into employee values(@P0, @P1, @P2, @P3, @P4)";

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

        public void Delete(string cpf)
        {
            string query = "delete from employee where cpf_employee = @P0";

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

        public Employee Read(string cpf)
        {
            string query = "select cpf_employee, name_employee, username_employee from employee where cpf_employee = @P0";                       
        }

        public Employee Update(Employee type)
        {
            string query = "update employee set name_employee = @P0, username_employee = @P1 where cpf_employee = @P2";
        }
    }
}
