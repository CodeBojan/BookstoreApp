using Bookstore.Model.ViewObjects;
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
    /// Interaction logic for ReadEmployees.xaml
    /// </summary>
    public partial class ReadEmployees : UserControl
    {
        private ReadEmployeesViewModel ViewModel; 
        public ReadEmployees()
        {
            InitializeComponent();
            ViewModel = App.ServiceProvider.GetService<ReadEmployeesViewModel>();
            DataContext = ViewModel;
            DataGrid.SelectionChanged += OnSelectionChanged;
        }

        private void KeyDownSearchBarEventHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ViewModel.SearchCommand.Execute(null);
            }
        }

        private void KeyDownDataGridEventHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                ViewModel.DeleteCommand.Execute(null);
                MessageBox.Show("Employee deleted successfully!");
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ViewModel.SelectedEmployeeProperty = DataGrid.SelectedItem as EmployeeDTO;
        }
    }
}
