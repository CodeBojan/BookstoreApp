using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace Bookstore.ViewModel
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        public ICommand AddEmployeeCommand { get; }

        private string Username;
        private string Password;
        private string ConfirmPassword;
        private string UIN;

        public string UsernameProperty
        {
            get
            {
                return Username;
            }
            set
            {
                Username = value;
                OnPropertyChanged(nameof(UsernameProperty));
            }
        }
        public string PasswordProperty
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
                OnPropertyChanged(nameof(PasswordProperty));
            }
        }
        public string ConfirmPasswordProperty
        {
            get
            {
                return ConfirmPassword;
            }
            set
            {
                ConfirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPasswordProperty));
            }
        }
        public string UINProperty
        {
            get
            {
                return UIN;
            }
            set
            {
                UIN = value;
                OnPropertyChanged(nameof(UINProperty));
            }
        }
        public AddEmployeeViewModel()
        {
            AddEmployeeCommand = new ViewModelCommand(ExecuteAddEmployeeCommand);
        }

        private void ExecuteAddEmployeeCommand(object obj)
        {
            var employee = App.BookstoreDatabase.GetEmployee(UsernameProperty);
            if (employee != null)
            {
                MessageBox.Show("Username already exists in the database");
                return;
            }
            if (ConfirmPasswordProperty != PasswordProperty)
            {
                MessageBox.Show("Passwords don't match");
                return;
            }
            var mainViewModel = App.ServiceProvider.GetService<MainViewModel>();
            App.BookstoreDatabase.AddEmployee(UsernameProperty, PasswordProperty, UINProperty, mainViewModel.CurrentThemeProperty);
            MessageBox.Show("Employee successfully added!");
        }

        private bool CanExecuteAddEmployeeCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(UsernameProperty) || string.IsNullOrWhiteSpace(PasswordProperty) || string.IsNullOrWhiteSpace(UINProperty) || PasswordProperty.Length < 4 || UsernameProperty.Length < 3 || UIN.Length != 13 || !int.TryParse(UINProperty, out int temp))
                return false;
            return true;
        }
    }
}
