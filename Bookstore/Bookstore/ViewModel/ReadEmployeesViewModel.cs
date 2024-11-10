using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Bookstore.Model.ViewObjects;
using System.Windows.Input;
using System.Windows.Controls;

namespace Bookstore.ViewModel
{
    public class ReadEmployeesViewModel : ViewModelBase
    {
        private IEnumerable Items;
        private string SearchText;
        private EmployeeDTO SelectedEmployee;
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public ReadEmployeesViewModel()
        {
            Items = App.BookstoreDatabase.ReadAllEmployees();
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);
        }

        private void ExecuteSearchCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchTextProperty))
            {
                ItemsProperty = App.BookstoreDatabase.ReadAllEmployees();
                return;
            }
            var items = ItemsProperty as List<EmployeeDTO>;
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            foreach (var item in items)
            {
                if(item.Username.Contains(SearchTextProperty))
                    employees.Add(item);
            }
            ItemsProperty = employees;
        }

        private void ExecuteDeleteCommand(object obj)
        {
            App.BookstoreDatabase.DeleteEmployee(SelectedEmployeeProperty);
            SelectedEmployeeProperty = null;
            Items = App.BookstoreDatabase.ReadAllEmployees();
        }
        public string SearchTextProperty
        {
            get
            {
                return SearchText;
            }
            set
            {
                SearchText = value;
                OnPropertyChanged(nameof(SearchTextProperty));
            }
        }

        public IEnumerable ItemsProperty
        {
            get
            {
                return Items;
            }
            set
            {
                Items = value;
                OnPropertyChanged(nameof(ItemsProperty));
            }
        }

        public EmployeeDTO SelectedEmployeeProperty
        {
            get
            {
                return SelectedEmployee;
            }
            set
            {
                SelectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployeeProperty));
            }
        }
    }
}
