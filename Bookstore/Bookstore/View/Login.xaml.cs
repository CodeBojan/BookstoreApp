using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bookstore.Model;
using Bookstore.Model.Database;
using Bookstore.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Globalization;
using Haley.Utils;

namespace Bookstore.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel ViewModel;
        public Login()
        {
            InitializeComponent();
            var loginViewModel = App.ServiceProvider.GetService<LoginViewModel>();
            ViewModel = loginViewModel;
            DataContext = loginViewModel;
            App.ThemesService.ChangeTheme(App.CurrentTheme);
        }

        private void MouseDownEventHandler(object sender, MouseButtonEventArgs args)
        {
            if (args.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButtonEventHandler(object sender, RoutedEventArgs args)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButtonEventHandler(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //TODO: autosave and the rest?
        }

        private void LanguageSelectedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            var languageItem = LanguageComboBox.SelectedItem as ComboBoxItem;
            var language = languageItem.Content;
            switch (language)
            {
                case "English":
                    LangUtils.ChangeCulture("en");
                    break;
                case "Srpski":
                    LangUtils.ChangeCulture("se-SE");
                    break;
            }
        }
    }
}
