using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BarberShop.Service.Repository.Database
{
    public class OrderServicesRepository : DatabaseConfiguration, IOrderServicesRepository
    {
        public void Create(OrderServices orderServices)
        {
            foreach (var x in orderServices.Service)
            {
                string query = "insert into orderServices values (@P0, @P1)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SqlParameter("P0", orderServices.Order.Id));
                        cmd.Parameters.Add(new SqlParameter("P1", x.Id));

                        cmd.ExecuteNonQuery();
                    }
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
                    cmd.Parameters.Add(new SqlParameter("P1", orderServices.Service[0].Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrderServices Read(int orderInfoId)
        {
            string query = "select * from ServiceInfo si right join OrderServices os on si.id_service = os.id_service_shop " +
                "right join OrderInfo oi on oi.id_order_info = os.id_order_info where os.id_order_info = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderInfoId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    OrderServices services = new OrderServices();

                    while (reader.Read())
                    {
                        services.Id = Convert.ToInt32(reader["id_order_services"]);
                        services.Order.Id = Convert.ToInt32(reader["id_order_info"]);
                        services.Order.CustomerInfo.Id = Convert.ToInt32(reader["id_customer"]);
                        services.Order.EmployeeInfo.Id = Convert.ToInt32(reader["id_employee"]);
                    }
                }
            }
        }

        public void Update(OrderServices type)
        {
            throw new System.NotImplementedException();
        }
    }
}
