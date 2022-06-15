using FahrzeugDatenbank;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace FahrzeugeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<KonfigurationsLeser>(sp => new KonfigurationsLeser(configuration)); 
            services.AddScoped(sp => new DatenbankKontext(sp.GetRequiredService<KonfigurationsLeser>().LiesDatenbankVerbindungZurMariaDB()));
            services.AddScoped<IBuchRepository, BuchOrmRepository>();
            services.AddScoped<FahrzeugeModell>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = ServiceProvider.GetService<MainWindow>();
            MainWindow.DataContext = ServiceProvider.GetService<MainWindowViewModel>();
            MainWindow.Show();
        }
    }
}
