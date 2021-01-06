using BarberShop.Service.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace BarberShop.Service.Repository.IO
{
    public class Logger : ILogger
    {
        public void CreateLog(string header, string log)
        {
            string fileName = $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}";
            string path = $@"../logs/{fileName}.txt";

            if (!Directory.Exists($@"../logs/"))
            {
                Directory.CreateDirectory($@"../logs/");
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"---{header}---");
                sw.WriteLine($"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}_{DateTime.Now.Hour}h{DateTime.Now.Minute}m{DateTime.Now.Second}s");
                sw.WriteLine(log);
                sw.Write("\n\n");
            }
        }

        public void CreateLog(string header, string log, string type, string[] data)
        {
            string fileName = $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}";
            string path = $@"../logs/{fileName}.txt";

            if (!Directory.Exists($@"../logs/"))
            {
                Directory.CreateDirectory($@"../logs/");
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"---{header}---");
                sw.WriteLine($"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}_{DateTime.Now.Hour}h{DateTime.Now.Minute}m{DateTime.Now.Second}s");
                sw.WriteLine(log);
                sw.WriteLine(type);
                sw.WriteLine("Data:");
                for (int i = 0;i < data.Length;i++)
                {
                    sw.WriteLine(data[i]);
                }
                sw.Write("\n\n");
            }
        }
    }
}
