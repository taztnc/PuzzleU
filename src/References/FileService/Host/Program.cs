using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace FileService
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCollectorService service = new FileCollectorService();
            //var host = new ServiceHost(service, new Uri[] { });
            //host.Open();

        }
    }
}
