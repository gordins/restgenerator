using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RestGenerator.Web
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build().Run();
        }
    }
}
