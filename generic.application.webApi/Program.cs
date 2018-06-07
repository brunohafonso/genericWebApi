using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using generic.application.repository.context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace generic.application.webApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var ambient = BuildWebHost(args);
            using (var escopo = ambient.Services.CreateScope())
            {
                var service = escopo.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<GenericContext>();
                    InitDatabase.initDb(context);
                }
                catch (Exception e)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "Ocorreu um erro ao inserir dados.");
                }
            }

            ambient.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
