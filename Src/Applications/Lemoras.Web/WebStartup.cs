using System.Diagnostics;
using System.IO;
using System.Reflection;
using Lemoras.Remora.Api;
using Lemoras.Remora.Kernel.Api;
using Lemoras.shark.backoffice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Lemoras.Web
{
    public class WebStartup : Startup
    {
        private readonly KernelStartup kernelStartup;
        private readonly SharkStartup sharkStartup;

        public WebStartup(IConfiguration configuration)
            : base(configuration)
        {
            this.kernelStartup = new KernelStartup(configuration);
            this.sharkStartup = new SharkStartup(configuration);
        }

        public override void CustomConfigure()
        {
            kernelStartup.CustomConfigure();
        }

        public override void CustomServiceRegister()
        {
            kernelStartup.CustomServiceRegister();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (IsDebug())
            {
                var path = $"{Directory.GetParent(Directory.GetCurrentDirectory())}" +
                        $"\\Lemoras.Shark.Backoffice";

                var fileOptions = new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                Path.Combine(path, "wwwroot"))
                };

                sharkStartup.CustomConfigure(app, env, fileOptions);
            }
            else
            {
                sharkStartup.CustomConfigure(app, env);
            }

            base.Configure(app, env);
        }

        private static bool IsDebug()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(DebuggableAttribute), false);
            if ((customAttributes != null) && (customAttributes.Length == 1))
            {
                DebuggableAttribute attribute = customAttributes[0] as DebuggableAttribute;
                return (attribute.IsJITOptimizerDisabled && attribute.IsJITTrackingEnabled);
            }
            return false;
        }

        private void Copy(string Prmt1, string prmt2, bool prmt3)
        {
            DirectoryInfo DrInf = new DirectoryInfo(Prmt1);
            DirectoryInfo[] DrInfLst = DrInf.GetDirectories();
            if (!Directory.Exists(prmt2))
            {
                Directory.CreateDirectory(prmt2);
            }

            FileInfo[] dosya = DrInf.GetFiles();
            string path1 = "";
            foreach (FileInfo FFF in dosya)
            {
                path1 = Path.Combine(prmt2, FFF.Name);
                FFF.CopyTo(path1, false);
            }
            if (true)
            {
                foreach (DirectoryInfo bilgi in DrInfLst)
                {
                    path1 = Path.Combine(prmt2, bilgi.Name);
                    Copy(bilgi.FullName, path1, true);
                }
            }
        }
    }
}
