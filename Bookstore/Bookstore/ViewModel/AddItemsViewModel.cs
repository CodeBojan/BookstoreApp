using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookstore.ViewModel
{
    public class AddItemsViewModel : ViewModelBase
    {
        public ICommand AddBookCommand { get; }
        public ICommand AddArticleCommand { get; }
        public ICommand AddPublisherCommand { get; }
        public ICommand AddAuthorCommand { get; }
        private MainViewModel MainViewModel;
        public AddItemsViewModel()
        {
            AddBookCommand = new ViewModelCommand(ExecuteAddBookCommand);
            AddArticleCommand = new ViewModelCommand(ExecuteAddArticleCommand);
            AddPublisherCommand = new ViewModelCommand(ExecuteAddPublisherCommand);
            AddAuthorCommand = new ViewModelCommand(ExecuteAddAuthorCommand);
            MainViewModel = App.ServiceProvider.GetService<MainViewModel>();
        }

        private void ExecuteAddBookCommand(object obj)
        {
            MainViewModel.CurrentChildViewProperty = new AddBookViewModel();
        }
        private void ExecuteAddArticleCommand(object obj)
        {
            MainViewModel.CurrentChildViewProperty = new AddArticleViewModel();
        }
        private void ExecuteAddPublisherCommand(object obj)
        {
            MainViewModel.CurrentChildViewProperty = new AddPublisherViewModel();
        }
        private void ExecuteAddAuthorCommand(object obj)
        {
            MainViewModel.CurrentChildViewProperty = new AddAuthorViewModel();
        }
    }
}
