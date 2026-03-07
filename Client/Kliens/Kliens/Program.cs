namespace Kliens
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Add services to the container.
            DbContext dbContext = new DbContext(
                "Host=localhost;" +
                "Port=5432;" +
                "Database=Bejelentkezes;" +
                "Username=postgres;" +
                "Password=adat");

            builder.Services.AddSingleton(typeof(DbContext), dbContext);

            //repok hozzáadása
            builder.Services.AddSingleton<ILoginRepo, LoginRepo>();


            //servicek hozzáadása
            builder.Services.AddSingleton<IAuthService, AuthService>();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}