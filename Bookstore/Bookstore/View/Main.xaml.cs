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
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;
using Bookstore.Model.DatabaseModel;
using FontAwesome.Sharp;
using Bookstore.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Haley.MVVM;
using Haley.Services;
using Haley.Abstractions;
using Haley.Models;
using Bookstore.Model;

namespace Bookstore.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private MainViewModel ViewModel;
        public Main()
        {
            var mainViewModel = App.ServiceProvider.GetService<MainViewModel>();
            ViewModel = mainViewModel;
            DataContext = mainViewModel;
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MouseLeftButtonDownEventHandler(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void MouseEnterEventHandler(object sender, MouseEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void CloseButtonEventHandler(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButtonEventHandler(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void MinimizeButtonEventHandler(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ChangeStyleEventHandler(object sender, RoutedEventArgs e)
        {
            if(ViewModel.CurrentThemeProperty == ThemesEnum.Blue)
            {
                App.ThemesService.ChangeTheme(ThemesEnum.Orange);
                App.CurrentTheme = ThemesEnum.Orange;
                ViewModel.CurrentThemeProperty = ThemesEnum.Orange;
            }
            else if(ViewModel.CurrentThemeProperty == ThemesEnum.Orange)
            {
                App.ThemesService.ChangeTheme(ThemesEnum.White);
                App.CurrentTheme = ThemesEnum.White;
                ViewModel.CurrentThemeProperty = ThemesEnum.White;
            }
            else if(ViewModel.CurrentThemeProperty == ThemesEnum.White)
            {
                App.ThemesService.ChangeTheme(ThemesEnum.Blue);
                App.CurrentTheme = ThemesEnum.Blue;
                ViewModel.CurrentThemeProperty = ThemesEnum.Blue;
            }
        }

        private void WindowShownEventHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            App.ThemesService.ChangeTheme(App.CurrentEmployee.Theme);
        }
    }
}
