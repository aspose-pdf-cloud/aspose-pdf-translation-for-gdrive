using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Aspose.PDF.Translator.GDrive {

  public class Program {

    public static void Main(string[] args) {
      Common.Init();
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {
      IHostBuilder hostBuilder =
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => {
          webBuilder
            .UseStartup<Startup>()
            .ConfigureKestrel(options => {
              options.AllowSynchronousIO = true;
              options.ListenAnyIP(8910);
            });
        });
      return hostBuilder;
    }
  }
}
