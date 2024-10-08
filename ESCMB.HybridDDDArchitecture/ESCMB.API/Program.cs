namespace ESCMB.API
{
    public class Program
    {
        protected Program()
        {
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.UseKestrel(); // Asegura que uses Kestrel y no otro servidor web.
        });
    }
}