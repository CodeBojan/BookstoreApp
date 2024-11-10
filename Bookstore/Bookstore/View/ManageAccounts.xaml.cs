using Bookstore.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookstore.View
{
    /// <summary>
    /// Interaction logic for ManageAccounts.xaml
    /// </summary>
    public partial class ManageAccounts : UserControl
    {
        private ManageAccountsViewModel ViewModel;
        public ManageAccounts()
        {
            InitializeComponent();
            ViewModel = App.ServiceProvider.GetService<ManageAccountsViewModel>();
            DataContext = ViewModel;
        }
    }
}
