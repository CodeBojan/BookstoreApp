using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections;
using Bookstore.Model.ViewObjects;

namespace Bookstore.ViewModel
{
    public class DatabaseViewModel : ViewModelBase
    {
        private IEnumerable Items;
        private IEnumerable Collection;
        private string SearchText = "Search...";
        private string DataType = "Articles";
        public ICommand SearchCommand { get; }
        public DatabaseViewModel()
        {
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);
        }

        private void ExecuteSearchCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchTextProperty))
            {
                ItemsProperty = App.BookstoreDatabase.ReadAllBooks();
                return;
            }
            var items = ItemsProperty as List<BookDTO>;
            List<BookDTO> books = new List<BookDTO>();
            foreach (var item in items)
            {
                if (item.Name.Contains(SearchTextProperty) || item.PublisherName.Contains(SearchTextProperty))
                    books.Add(item);
            }
            ItemsProperty = books;
        }

        public IEnumerable CollectionProperty
        {
            get
            {
                return Collection;
            }
            set
            {
                Collection = value;
                OnPropertyChanged(nameof(CollectionProperty));
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
        public string DataTypeProperty
        {
            get
            {
                return DataType;
            }
            set
            {
                DataType = value;
                OnPropertyChanged(nameof(DataTypeProperty));
            }
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
    }
}
