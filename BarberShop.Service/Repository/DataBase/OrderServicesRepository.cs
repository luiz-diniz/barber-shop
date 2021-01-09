using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace BarberShop.Service.Repository.Database
{
    public class OrderServicesRepository : DatabaseConfiguration, IOrderServicesRepository
    {
        public void Create(OrderServices orderServices)
        {

            string query = "insert into orderServices values (@P0, @P1)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderServices.Order.Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderServices.Service.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(OrderServices orderServices)
        {
            string query = "delete from orderServices where id_order_info = @P0 and id_service_shop = @P1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderServices.Order.Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderServices.Service.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ServiceInfo> Read(int orderInfoId)
        {
            string query = "select * from ServiceInfo si inner join OrderServices os on si.id_service = os.id_service_shop " +
                "where os.id_order_info = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderInfoId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ServiceInfo> services = new List<ServiceInfo>();

                    while (reader.Read())
                    {
                        services.Add(new ServiceInfo
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

        public void Update(OrderServices type)
        {
            throw new System.NotImplementedException();
        }
    }
}
