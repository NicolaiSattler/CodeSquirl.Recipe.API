using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace CodeSquirrel.RecipeApp.API
{
    public class Program
    {
        protected Program() { }

        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config")
                                    .GetCurrentClassLogger();
            
            try
            {
                
                logger.Debug("Initialize API");
                
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "The API stopped due to an exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .ConfigureLogging(logging => 
                          {
                              logging.ClearProviders();
                              logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                          })
                          .UseNLog()
                          .Build();
        }
    }
}
