using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Model.DatabaseModel;
using Bookstore.Model;
using System.Windows.Input;
using FontAwesome.Sharp;
using System.Windows.Controls;
using System.Windows;
using Bookstore.View;
namespace Bookstore.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Employee CurrentEmployee;
        private IconChar CurrentSelectedIcon;
        private string CurrentSelectedText;
        private bool IsManageAccountsVisible = true;
        private ViewModelBase CurrentChildView;
        private PurchaseViewModel PurchaseViewModel; //saving current models
        private DatabaseViewModel DatabaseViewModel; //saving current models
        private AddItemsViewModel AddItemsViewModel; //saving current models
        private ManageAccountsViewModel ManageAccountsViewModel; //saving current models
        private ThemesEnum CurrentTheme;
        
        public ICommand ShowPurchaseViewCommand { get; }
        public ICommand ShowDatabaseViewCommand { get; }
        public ICommand ShowAddItemsViewCommand { get; }
        public ICommand ShowManageAccountsViewCommand { get; }
        public MainViewModel()
        {
            CurrentEmployee = App.CurrentEmployee;
            //if (CurrentEmployee.IsAdmin)
            //    IsManageAccountsVisibleProperty = true;
            //CurrentThemeProperty = CurrentEmployee.Theme;
            ShowPurchaseViewCommand = new ViewModelCommand(ExecuteShowPurchaseViewCommand);
            ShowDatabaseViewCommand = new ViewModelCommand(ExecuteShowDatabaseViewCommand);
            ShowAddItemsViewCommand = new ViewModelCommand(ExecuteShowAddItemsViewCommand);
            ShowManageAccountsViewCommand = new ViewModelCommand(ExecuteShowManageAccountsViewCommand);
        }

        private void ExecuteShowManageAccountsViewCommand(object obj)
        {
            if (ManageAccountsViewModel == null)
            {
                ManageAccountsViewModel = new ManageAccountsViewModel();
            }
            CurrentChildViewProperty = ManageAccountsViewModel;
            CurrentSelectedIconProperty = IconChar.UserEdit;
            CurrentSelectedTextProperty = "Manage Accounts";
        }

        private void ExecuteShowAddItemsViewCommand(object obj)
        {
            if (AddItemsViewModel == null)
            {
                AddItemsViewModel = new AddItemsViewModel();
            }
            CurrentChildViewProperty = AddItemsViewModel;
            CurrentSelectedIconProperty = IconChar.PlusSquare;
            CurrentSelectedTextProperty = "Add Items";
        }

        private void ExecuteShowDatabaseViewCommand(object obj)
        {
            if (DatabaseViewModel == null)
            {
                DatabaseViewModel = new DatabaseViewModel();
            }
            CurrentChildViewProperty = DatabaseViewModel;
            CurrentSelectedIconProperty = IconChar.Database;
            CurrentSelectedTextProperty = "Database";
        }

        private void ExecuteShowPurchaseViewCommand(object obj)
        {
            if (PurchaseViewModel == null)
            {
                PurchaseViewModel = new PurchaseViewModel();
            }
            CurrentChildViewProperty = PurchaseViewModel;
            CurrentSelectedIconProperty = IconChar.SackDollar;
            CurrentSelectedTextProperty = "Purchase";
        }
        public ThemesEnum CurrentThemeProperty
        {
            get
            {
                return CurrentTheme;
            }
            set
            {
                CurrentTheme = value;
                OnPropertyChanged(nameof(CurrentThemeProperty));
            }
        }
        public bool IsManageAccountsVisibleProperty
        {
            get
            {
                return IsManageAccountsVisible;
            }
            set
            {
                IsManageAccountsVisible = value;
                OnPropertyChanged(nameof(IsManageAccountsVisibleProperty));
            }
        }

        public Employee CurrentEmployeeProperty
        {
            get
            {
                return CurrentEmployee;
            }

            set
            {
                CurrentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
            }
        }

        public IconChar CurrentSelectedIconProperty
        {
            get
            {
                return CurrentSelectedIcon;
            }
            set
            {
                CurrentSelectedIcon = value;
                OnPropertyChanged(nameof(CurrentSelectedIconProperty));
            }
        }
        public string CurrentSelectedTextProperty
        {
            get
            {
                return CurrentSelectedText;
            }
            set
            {
                CurrentSelectedText = value;
                OnPropertyChanged(nameof(CurrentSelectedTextProperty));
            }
        }

        public ViewModelBase CurrentChildViewProperty
        {
            get
            {
                return CurrentChildView;
            }
            set
            {
                CurrentChildView = value;
                OnPropertyChanged(nameof(CurrentChildViewProperty));
            }
        }
    }
}
