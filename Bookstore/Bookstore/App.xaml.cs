using System;
using System.Windows;
using Bookstore.View;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bookstore.ViewModel;
using Bookstore.Model;
using Bookstore.Model.DatabaseModel;
using Haley.Models;
using Haley.Services;
using Haley.Abstractions;
using Haley.Utils;

namespace Bookstore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _Host;
        public static IServiceProvider ServiceProvider { get; private set; }
        public static Employee CurrentEmployee { get; set; }
        public static BookstoreDatabase BookstoreDatabase { get; private set; }
        public static IThemeService ThemesService;
        public static ThemesEnum CurrentTheme { get; set; }
        public static LanguagesEnum CurrentLanguage { get; set; }

        public App()
        {
            _Host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                ConfigureServices(context.Configuration, services);
            }).Build();
            ServiceProvider = _Host.Services;
            BookstoreDatabase = new BookstoreDatabase();
            ThemesService = ThemeService.Singleton;
            LangUtils.Register();
            RegisterThemes();
        }

        private void RegisterThemes()
        {
            var assemblyThemeBuilder = new AssemblyThemeBuilder();
            assemblyThemeBuilder.Add(ThemesEnum.Blue, new Uri(@"pack://application:,,,/Bookstore;component/Styles/GUIColors.xaml"));
            assemblyThemeBuilder.Add(ThemesEnum.Orange, new Uri(@"pack://application:,,,/Bookstore;component/Styles/GUIColors2.xaml"));
            assemblyThemeBuilder.Add(ThemesEnum.White, new Uri(@"pack://application:,,,/Bookstore;component/Styles/GUIColors3.xaml"));
            ThemesService.RegisterGroup(assemblyThemeBuilder);
            ThemesService.SetStartupTheme(ThemesEnum.Blue);
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // Register all ViewModels.
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<PurchaseViewModel>();
            services.AddSingleton<DatabaseViewModel>();
            services.AddSingleton<AddItemsViewModel>();
            services.AddSingleton<ManageAccountsViewModel>();
            services.AddSingleton<AddEmployeeViewModel>();
            services.AddSingleton<ReadEmployeesViewModel>();
            services.AddSingleton<AddArticleViewModel>();
            services.AddSingleton<AddBookViewModel>();
            services.AddSingleton<AddPublisherViewModel>();
            services.AddSingleton<AddItemsViewModel>();
            services.AddSingleton<AddAuthorViewModel>();

            // Register all the Windows of the applications.
            services.AddTransient<Main>();
            services.AddTransient<Login>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _Host.StartAsync();

            var loginView = _Host.Services.GetRequiredService<Login>();
            loginView.Show();
            loginView.IsVisibleChanged += (s, e) =>
            {
                if (loginView.IsVisible is false && loginView.IsLoaded)
                {
                    var mainView = new Main();
                    mainView.Show();
                    loginView.Close();
                }
            };
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_Host)
            {
                await _Host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
        private void ApplicationStartEventHandler(object sender, StartupEventArgs e)
        {
            var loginView = new Login();
            loginView.Show();
            loginView.IsVisibleChanged += (s, e) =>
            {
                if (loginView.IsVisible is false && loginView.IsLoaded)
                {
                    var mainView = new Main();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }

        private void AppExitEventHandler(object sender, ExitEventArgs e)
        {
            if(App.CurrentEmployee is not null)
                App.BookstoreDatabase.UpdateEmployee(App.CurrentEmployee);
        }
    }
}
