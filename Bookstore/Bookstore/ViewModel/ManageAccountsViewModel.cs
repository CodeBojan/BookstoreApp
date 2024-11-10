using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bookstore.Model.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.ViewModel
{
    public class ManageAccountsViewModel : ViewModelBase
    {
        public ICommand AddEmployeeCommand { get; }
        public ICommand ReadEmployeesCommand { get; }
        private MainViewModel MainViewModel;

        public ManageAccountsViewModel()
        {
            AddEmployeeCommand = new ViewModelCommand(ExecuteAddEmployeeCommand);
            ReadEmployeesCommand = new ViewModelCommand(ExecuteReadEmployeesCommand);
            MainViewModel = App.ServiceProvider.GetService<MainViewModel>();
        }
        private void ExecuteReadEmployeesCommand(object obj)
        {
            MainViewModel.CurrentChildViewProperty = new ReadEmployeesViewModel();
        }
        
        private void ExecuteAddEmployeeCommand(object obj)
        {
            MainViewModel.CurrentChildViewProperty = new AddEmployeeViewModel();
        }
    }
}
