using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System;
using System.Data.SqlClient;
using System.Data;

namespace BarberShop.Service.Repository.Database
{
    public class OrderInfoRepository : DatabaseConfiguration, IOrderInfoRepository
    {
        public void Create(OrderInfo orderInfo)
        {
            string query = "insert into orderInfo values(@P0, @P1, @P2, @P3)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderInfo.CustomerInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderInfo.EmployeeInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P2", orderInfo.ShopAddressInfo.Id));
                    cmd.Parameters.Add(new SqlParameter("P3", orderInfo.OrderDate));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public OrderInfo Read(string orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
