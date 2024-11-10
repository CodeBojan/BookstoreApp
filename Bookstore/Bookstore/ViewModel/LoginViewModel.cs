using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Bookstore.Model;
using Haley.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string Username;
        private string Password;
        private string Error;
        private bool IsViewVisible = true;

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
        public string PasswordProperty { get { return Password; } set { Password = value; OnPropertyChanged(nameof(PasswordProperty)); } }
        public string ErrorProperty { get { return Error; } set { Error = value; OnPropertyChanged(nameof(ErrorProperty)); } }
        public bool IsViewVisibleProperty { get { return IsViewVisible; } set { IsViewVisible = value; OnPropertyChanged(nameof(IsViewVisibleProperty)); } }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(UsernameProperty) || UsernameProperty.Length < 2 || PasswordProperty is null || PasswordProperty.Length < 4)
                return false;
            return true;
        }

        private void ExecuteLoginCommand(object obj)
        {
            if (App.BookstoreDatabase.IsEmployeeRegistered(UsernameProperty))
            {
                if (App.BookstoreDatabase.IsEmployeeAuthenticated(UsernameProperty, PasswordProperty))
                {
                    App.CurrentEmployee = App.BookstoreDatabase.GetEmployee(UsernameProperty);
                    IsViewVisibleProperty = false;
                    var mainViewModel = App.ServiceProvider.GetService<MainViewModel>();
                    if (!App.CurrentEmployee.IsAdmin)
                        mainViewModel.IsManageAccountsVisibleProperty = false;
                }
                else
                    ErrorProperty = LangUtils.Translate("LoginAuthenticationError");
            }
            else
                ErrorProperty = LangUtils.Translate("LoginNotRegisteredError");
        }
    }
}
