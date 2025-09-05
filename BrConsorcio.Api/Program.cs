
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System;

namespace BrConsorcio.Api
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var host = new WebHostBuilder()
        //        .UseKestrel()
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .UseIISIntegration()
        //        .UseStartup<Startup>()
        //        .UseApplicationInsights()
        //        .UseUrls("http://*:5000/")
        //        .Build();

        //    host.Run();
        //}

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o =>
                {
                    o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(45);
                })
                .UseStartup<Startup>()
                .Build();
    }
}
