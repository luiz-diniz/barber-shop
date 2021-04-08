using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Service.Utilities
{
    public interface ILogger
    {
        void CreateLog(string header, string log);
        void CreateLog(string header, string log, string type, string[] data);
    }
}
