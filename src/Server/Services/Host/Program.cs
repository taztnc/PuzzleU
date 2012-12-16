using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using PuzzleUServices;

namespace PuzzleUHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                host = StartServiceHost();
                Console.WriteLine();
                Console.WriteLine("Press 'F1' to exit");
                while (Console.ReadKey().Key != ConsoleKey.F1) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: {0}", ex.Message));
            }

            if (host != null)
            {
               CloseServiceHost(host);
            }
        }

        private static ServiceHost StartServiceHost()
        {
            
            PuzzleUService service = new PuzzleUService();
            var host = new ServiceHost(service, new Uri [] {});
            host.Open();
            Console.WriteLine("PuzzleUService Service started");
            return host;
        }

        private static void CloseServiceHost(ServiceHost host)
        {
            PuzzleUService service = (PuzzleUService)host.SingletonInstance;
            if (service != null)
                service.Save();

            host.Close();

            Console.WriteLine("PuzzleUService Service closed");
        }
    }
}
