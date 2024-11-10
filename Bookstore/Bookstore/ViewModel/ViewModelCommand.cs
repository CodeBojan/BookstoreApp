using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookstore.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        private readonly Action<object> ExecuteAction;
        private readonly Predicate<object> CanExecuteAction;

        public ViewModelCommand(Action<object> executeAction)
        {
            ExecuteAction = executeAction;
            CanExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction) : this(executeAction)
        {
            CanExecuteAction = canExecuteAction;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteAction is null)
                return true;
            else
                return CanExecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
    }
}
