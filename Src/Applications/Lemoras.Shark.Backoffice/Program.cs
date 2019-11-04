using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
//using System.Net;

namespace Lemoras.shark.backoffice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
  //          .UseKestrel(options => {
  //    options.Listen(IPAddress.Loopback, 5000); //HTTP port
  //  })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<SharkStartup>();
    }
}
