using Microsoft.Extensions.DependencyInjection;

namespace Kliens
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // Add services to the container.
            DbContext dbContext = new DbContext(
                "Host=localhost;" +
                "Port=5432;" +
                "Database=Bejelentkezes;" +
                "Username=postgres;" +
                "Password=adat");

            services.AddSingleton<DbContext>(dbContext);

            // repositories
            services.AddSingleton<ILoginRepo, LoginRepo>();

            // services
            services.AddSingleton<IAuthService, AuthService>();

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}