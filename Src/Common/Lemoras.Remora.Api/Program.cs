using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using OYASAR.Framework.Log4Net;

namespace Lemoras.Remora.Api
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            Run<Startup>(args);
        }

        public static IWebHostBuilder CreateWebHostBuilder<TStartup>(string[] args)
            where TStartup : class
            => 
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<TStartup>();

        private static void SetLog()
        {
            Log.SetLog4NetConfiguraiton(typeof(Program));
        }

        public static void Run<TStartup>(string[] args, bool forS3 = false) where TStartup : class
        {
            SetLog();

            CreateWebHostBuilder<TStartup>(args).Build().Run();
        }

        public static void LambdaEntryPoint<TStartup>(IWebHostBuilder builder) where TStartup : class
        {
            SetLog();

            builder
                .UseStartup<TStartup>();
        }
    }
}
