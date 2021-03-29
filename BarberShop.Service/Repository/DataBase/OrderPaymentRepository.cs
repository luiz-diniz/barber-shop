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

        public List<OrderPayment> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderPayment Read(int orderId)
        {
            string query = "select * from Payment pa right join OrderPayment op on pa.id_payment = op.id_order_payment " +
                "right join OrderInfo oi on oi.id_order_info = op.id_order_info where op.id_order_info = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    OrderPayment payments = new OrderPayment();
                    payments.PaymentInfo = new List<Payment>();

                    var flag = true;

                    while (reader.Read())
                    {
                        if (flag)
                        {
                            payments.Id = Convert.ToInt32(reader["id_order_payment"]);

                            payments.Order = new OrderInfo
                            {
                                Id = Convert.ToInt32(reader["id_order_info"]),
                                CustomerInfo = new Customer
                                {
                                    Id = Convert.ToInt32(reader["id_customer"])
                                },
                                EmployeeInfo = new Employee
                                {
                                    Id = Convert.ToInt32(reader["id_employee"])
                                },
                                ShopAddressInfo = new ShopAddress
                                {
                                    Id = Convert.ToInt32(reader["id_shop"])
                                },
                                OrderDate = Convert.ToDateTime(reader["order_date"])
                            };

                            flag = false;
                        }

                        payments.PaymentInfo.Add(new Payment
                        {
                            Id = Convert.ToInt32(reader["id_payment"]),
                            Name = Convert.ToString(reader["name_payment"]),
                        });
                    }

                    return payments;
                }
            }
        }

        public void Update(OrderPayment orderPayment)
        {
            string query = "update orderPayment set id_payment = @P0 where id_payment = @P1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderPayment.PaymentInfo[0].Id));
                    cmd.Parameters.Add(new SqlParameter("P1", orderPayment.PaymentInfo[1].Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
