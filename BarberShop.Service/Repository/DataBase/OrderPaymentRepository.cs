using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Repository.Database
{
    public class OrderPaymentRepository : DatabaseConfiguration, IOrderPaymentRepository
    {
        public void Create(OrderPayment orderPayment)
        {
            foreach (var x in orderPayment.PaymentInfo)
            {
                string query = "insert into orderPayment values(@P0, @P1)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SqlParameter("P1", orderPayment.Order.Id));
                        cmd.Parameters.Add(new SqlParameter("P0", x.Id));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Delete(OrderPayment orderPayment)
        {
            string query = "delete from orderPayment where id_payment = @P0 and id_order_info = @P1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P1", orderPayment.Order.Id));
                    cmd.Parameters.Add(new SqlParameter("P0", orderPayment.PaymentInfo[0].Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrderPayment Read(int type)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderPayment type)
        {
            throw new NotImplementedException();
        }
    }
}
