using BarberShop.Service.Models;
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
            throw new NotImplementedException();
        }

        public ShopAddress Read(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(ShopAddress shopAddress)
        {
            throw new NotImplementedException();
        }
    }
}