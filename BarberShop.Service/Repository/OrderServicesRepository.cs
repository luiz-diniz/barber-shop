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
        public void Create(OrderInfo orderInfo)
        {
            string query = "insert into orderServices values (@P0, @P1)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var service in orderInfo.ServicesInfo)
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SqlParameter("P0", orderInfo.Id));
                        cmd.Parameters.Add(new SqlParameter("P1", service.Id));

                        cmd.ExecuteNonQuery();
                    } 
                }
            }
        }

        public List<ServiceInfo> Read(int orderId)
        {
            string query = "select si.id_service, si.name_service, si.value_service, si.description_service from ServiceInfo si " +
                "inner join OrderServices os on si.id_service = os.id_service where os.id_order_info = @P0 order by si.id_service";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", orderId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    var servicesInfo = new List<ServiceInfo>();

                    while (reader.Read())
                    {
                        servicesInfo.Add(new ServiceInfo()
                        {
                            Id = Convert.ToInt32(reader["id_service"]),
                            Name = Convert.ToString(reader["name_service"]),
                            Value = Convert.ToDecimal(reader["value_service"]),
                            Description = Convert.ToString(reader["description_service"])
                        });
                    }

                    return servicesInfo;
                }
            }
        }



        //public void Delete(OrderServices orderServices)
        //{
        //    string query = "delete from orderServices where id_order_info = @P0 and id_service = @P1";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;

        //            cmd.Parameters.Add(new SqlParameter("P0", orderServices.Order.Id));
        //            cmd.Parameters.Add(new SqlParameter("P1", orderServices.Service[0].Id));

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public List<OrderServices> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public OrderServices Read(int orderInfoId)
        //{
        //    string query = "select * from ServiceInfo si right join OrderServices os on si.id_service = os.id_service " +
        //        "right join OrderInfo oi on oi.id_order_info = os.id_order_info where os.id_order_info = @P0";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;

        //            cmd.Parameters.Add(new SqlParameter("P0", orderInfoId));

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            OrderServices services = new OrderServices();
        //            services.Service = new List<ServiceInfo>();

        //            var flag = true;

        //            while (reader.Read())
        //            {
        //                if (flag)
        //                {
        //                    services.Id = Convert.ToInt32(reader["id_order_services"]);

        //                    services.Order = new OrderInfo
        //                    {
        //                        Id = Convert.ToInt32(reader["id_order_info"]),
        //                        CustomerInfo = new Customer
        //                        {
        //                            Id = Convert.ToInt32(reader["id_customer"])
        //                        },
        //                        EmployeeInfo = new Employee
        //                        {
        //                            Id = Convert.ToInt32(reader["id_employee"])
        //                        },
        //                        ShopAddressInfo = new ShopAddress
        //                        {
        //                            Id = Convert.ToInt32(reader["id_shop"])
        //                        },
        //                        OrderDate = Convert.ToDateTime(reader["order_date"])
        //                    };

        //                    flag = false;
        //                }

        //                services.Service.Add(new ServiceInfo
        //                {
        //                    Id = Convert.ToInt32(reader["id_service"]),
        //                    Name = Convert.ToString(reader["name_service"]),
        //                    Description = Convert.ToString(reader["description_service"]),
        //                    Value = Convert.ToDecimal(reader["value_service"])
        //                });
        //            }

        //            return services;
        //        }
        //    }
        //}

        //public void Update(OrderServices orderServices)
        //{
        //    string query = "update OrderServices set id_service = @P0 where id_service = @P1";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;

        //            cmd.Parameters.Add(new SqlParameter("P0", orderServices.Service[0].Id));
        //            cmd.Parameters.Add(new SqlParameter("P1", orderServices.Service[1].Id));

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}