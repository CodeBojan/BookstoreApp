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
using Bookstore.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        private AddEmployeeViewModel ViewModel; 
        public AddEmployee()
        {
            InitializeComponent();
            ViewModel = App.ServiceProvider.GetService<AddEmployeeViewModel>();
            DataContext = ViewModel;
        }
    }
}
