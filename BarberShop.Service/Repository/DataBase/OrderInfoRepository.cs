using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace BarberShop.Service.Repository.Database
{
    public class OrderInfoRepository : DatabaseConfiguration, IOrderInfoRepository
    {
        public int CreateOrder(OrderInfo orderInfo)
        {
            string query = "insert into orderInfo values(@P0, @P1, @P2, @P3, @P4) select @@Identity";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderInfo.CustomerInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderInfo.EmployeeInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P2", orderInfo.ShopAddressInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P3", orderInfo.PaymentInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P4", orderInfo.OrderDate));


                    var teste = Convert.ToInt32(cmd.ExecuteScalar());

                    return teste;
                }
            };
        }

        public void Delete(OrderInfo orderInfo)
        {
            string query = "delete from orderInfo where id_order_info = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderInfo.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<OrderInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderInfo Read(int orderId)
        {
            string query = "select * from orderInfo where id_order_info = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    OrderInfo orderInfo = new OrderInfo {
                        CustomerInfo = new Customer(),
                        EmployeeInfo = new Employee(),
                        ShopAddressInfo = new ShopAddress()
                    };

                    if (reader.Read())
                    {
                        orderInfo.Id = Convert.ToInt32(reader["id_order_info"]);
                        orderInfo.CustomerInfo.Id = Convert.ToInt32(reader["id_customer"]);
                        orderInfo.EmployeeInfo.Id = Convert.ToInt32(reader["id_employee"]);
                        orderInfo.ShopAddressInfo.Id = Convert.ToInt32(reader["id_shop"]);
                        orderInfo.OrderDate = Convert.ToDateTime(reader["order_date"]);
                    }

                    return orderInfo;
                }
            }
        }

        public void Update(OrderInfo orderInfo)
        {
            string query = "update orderInfo set id_customer = @P0, id_employee = @P1, id_shop = @P2 where id_order_info = @P3";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderInfo.CustomerInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderInfo.EmployeeInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P2", orderInfo.ShopAddressInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P3", orderInfo.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
