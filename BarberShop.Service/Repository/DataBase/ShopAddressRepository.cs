﻿using BarberShop.Service.Models;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Repository.Database
{
    public class ShopAddressRepository : DatabaseConfiguration, IShopAddressRepository
    {
        public void Create(ShopAddress shopAddress)
        {
            string query = "insert into shopAddress values(@P0, @P1, @P2, @P3, @P4)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", shopAddress.Name));
                    cmd.Parameters.Add(new SqlParameter("P1", shopAddress.Street));
                    cmd.Parameters.Add(new SqlParameter("P2", shopAddress.Number));
                    cmd.Parameters.Add(new SqlParameter("P3", shopAddress.City));
                    cmd.Parameters.Add(new SqlParameter("P4", shopAddress.State));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(ShopAddress shopAddress)
        {
            string query = "delete from shopAddress where id_shop = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", shopAddress.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ShopAddress Read(string name)
        {
            string query = "select * from shopaddress where name_shop = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("P0", name));

                    SqlDataReader reader = cmd.ExecuteReader();

                    ShopAddress shopAddress = new ShopAddress();

                    if (reader.Read())
                    {
                        shopAddress.Id = Convert.ToInt32(reader["id_shop"]);
                        shopAddress.Name = Convert.ToString(reader["name_shop"]);
                        shopAddress.Street = Convert.ToString(reader["street_shop"]);
                        shopAddress.Number = Convert.ToInt32(reader["number_shop"]);
                        shopAddress.City = Convert.ToString(reader["city_shop"]);
                        shopAddress.State = Convert.ToString(reader["state_shop"]);
                    }

                    return shopAddress;
                }
            }
        }

        public void Update(ShopAddress shopAddress)
        {
            throw new NotImplementedException();
        }
    }
}