using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Repository.Interfaces
{
    public interface ILogger
    {
        void CreateLog(string header, string log);
        void CreateLog(string header, string log, string type, List<string> data);
    }
}
