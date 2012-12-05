using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileService;
using System.ServiceModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCollectorService service = new FileCollectorService();
            var host = new ServiceHost(service, new Uri[] { });
            host.Open();
            Console.WriteLine("Service started");
            while (Console.ReadKey().Key != ConsoleKey.F1) ;
        }
    }
}
