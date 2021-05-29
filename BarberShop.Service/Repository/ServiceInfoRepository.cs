using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace BarberShop.Service.Repository.Database
{
    public class ServiceInfoRepository : DatabaseConfiguration, IServiceInfoRepository
    {
        public void Create(ServiceInfo serviceInfo)
        {
            string query = "insert into serviceInfo values(@P0, @P1, @P2)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", serviceInfo.Name));
                    cmd.Parameters.Add(new SqlParameter("P1", serviceInfo.Description));
                    cmd.Parameters.Add(new SqlParameter("P2", serviceInfo.Value));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(ServiceInfo serviceInfo)
        {
            string query = "delete from serviceInfo where id_service = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", serviceInfo.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ServiceInfo> GetAll()
        {
            string query = "select * from serviceInfo";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ServiceInfo> services = new List<ServiceInfo>();

                    while (reader.Read())
                    {
                        services.Add(new ServiceInfo()
                        {
                            Id = Convert.ToInt32(reader["id_service"]),
                            Name = Convert.ToString(reader["name_service"]),
                            Description = Convert.ToString(reader["description_service"]),
                            Value = Convert.ToDecimal(reader["value_service"])
                        });
                    }

                    return services;
                }
            }
        }

        public ServiceInfo Read(string name)
        {
            string query = "select * from serviceInfo where name_service = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", name));

                    SqlDataReader reader = cmd.ExecuteReader();

                    ServiceInfo serviceInfo = new ServiceInfo();

                    if (reader.Read())
                    {
                        serviceInfo.Id = Convert.ToInt32(reader["id_service"]);
                        serviceInfo.Name = Convert.ToString(reader["name_service"]);
                        serviceInfo.Description = Convert.ToString(reader["description_service"]);
                        serviceInfo.Value = Convert.ToInt32(reader["value_service"]);
                    }

                    return serviceInfo;
                }
            }
        }

        public ServiceInfo Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceInfo serviceInfo)
        {
            string query = "update serviceInfo set name_service = @P0, description_service = @P1, value_service = @P2 where id_service = @P3";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", serviceInfo.Name));
                    cmd.Parameters.Add(new SqlParameter("P1", serviceInfo.Description));
                    cmd.Parameters.Add(new SqlParameter("P2", serviceInfo.Value)); 
                    cmd.Parameters.Add(new SqlParameter("P3", serviceInfo.Id)); 

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
