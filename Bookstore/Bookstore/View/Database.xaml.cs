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
using Bookstore.Model.DatabaseModel;
using Bookstore.Model.ViewObjects;
using System.Collections;
using Haley.Utils;

namespace Bookstore.View
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : UserControl
    {
        private DatabaseViewModel ViewModel;
        private MainViewModel MainViewModel;
        public Database()
        {
            InitializeComponent();
            var databaseViewModel = App.ServiceProvider.GetService<DatabaseViewModel>();
            MainViewModel = App.ServiceProvider.GetService<MainViewModel>();
            ViewModel = databaseViewModel;
            DataContext = databaseViewModel;
            ViewModel.ItemsProperty = App.BookstoreDatabase.ReadAllArticles();
        }

        private void KeyDownSearchBarEventHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ViewModel.SearchCommand.Execute(null);
            }
        }

        private void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            string type = ViewModel.DataTypeProperty.Split(": ")[1];
            switch (type)
            {
                case "Books":
                    ViewModel.ItemsProperty = App.BookstoreDatabase.ReadAllBooks();
                    break;
                case "Articles":
                    ViewModel.ItemsProperty = App.BookstoreDatabase.ReadAllArticles();
                    break;
                case "Authors":
                    ViewModel.ItemsProperty = App.BookstoreDatabase.ReadAllAuthors();
                    break;
                case "Bills":
                    ViewModel.ItemsProperty = App.BookstoreDatabase.ReadAllBills();
                    break;
                case "Publishers":
                    ViewModel.ItemsProperty = App.BookstoreDatabase.ReadAllPublishers();
                    break;
            }
        }

        private void SelectionEventHandler(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach(var cell in DataGrid.SelectedCells)
            {
                if(cell.Item is List)
                {
                    ViewModel.CollectionProperty = (IEnumerable)(cell.Item as List);
                }
            }
        }

        private void SelectedRowEventHandler(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = e.AddedItems[0];
                if (item is BookDTO)
                {
                    var book = item as BookDTO;
                    ViewModel.CollectionProperty = book.Authors;
                }
                else if (item is AuthorDTO)
                {
                    var author = item as AuthorDTO;
                    ViewModel.CollectionProperty = author.Books;
                }
                else if (item is BillDTO)
                {
                    var bill = item as BillDTO;
                    ViewModel.CollectionProperty = bill.BillItems;
                }
            }
            catch (Exception)
            {

            }
        }

        private void UpdateItemEventHandler(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            var selectedItem = DataGrid.SelectedItem;
            if(selectedItem is BookDTO)
            {
                var bookDTO = selectedItem as BookDTO;
                var addViewModel = App.ServiceProvider.GetService<AddBookViewModel>();
                MainViewModel.CurrentChildViewProperty = addViewModel;
                addViewModel.NameProperty = bookDTO.Name;
                addViewModel.OldNameProperty = bookDTO.Name;
                addViewModel.ISBNProperty = bookDTO.ISBN;
                addViewModel.LanguageProperty = bookDTO.LanguageName;
                addViewModel.PriceProperty = bookDTO.Price;
                addViewModel.PublisherNameProperty = bookDTO.PublisherName;
                addViewModel.DescriptionProperty = bookDTO.Description;
                addViewModel.AmountProperty = bookDTO.Amount;
                addViewModel.SelectedAuthorsProperty = bookDTO.Authors;
                addViewModel.ButtonTextProperty = LangUtils.Translate("AddBookButtonTextUpdate");
            }
            else if(selectedItem is AuthorDTO)
            {
                var authorDTO = selectedItem as AuthorDTO;
                var addViewModel = App.ServiceProvider.GetService<AddAuthorViewModel>();
                addViewModel.NameProperty= authorDTO.Name;
                addViewModel.SurnameProperty = authorDTO.Surname;
                addViewModel.OldNameProperty = authorDTO.Name;
                addViewModel.OldSurnameProperty = authorDTO.Surname;
                addViewModel.ButtonTextProperty = LangUtils.Translate("AddAuthorButtonTextUpdate");
                MainViewModel.CurrentChildViewProperty = addViewModel;
            }
            else if(selectedItem is ArticleDTO)
            {
                var articleDTO = selectedItem as ArticleDTO;
                var addViewModel = App.ServiceProvider.GetService<AddArticleViewModel>();
                addViewModel.NameProperty = articleDTO.Name;
                addViewModel.OldNameProperty = articleDTO.Name;
                addViewModel.DescriptionProperty= articleDTO.Description;
                addViewModel.AmountProperty = articleDTO.Amount;
                addViewModel.PriceProperty = articleDTO.Price;
                addViewModel.ButtonTextProperty = LangUtils.Translate("AddArticleButtonTextUpdate");
                MainViewModel.CurrentChildViewProperty= addViewModel;
            }
            else if(selectedItem is BillDTO)
            {
                MessageBox.Show("Bills can't be edited!");
            }
            else if(selectedItem is PublisherDTO)
            {
                var publisherDTO = selectedItem as PublisherDTO;
                var addViewModel = App.ServiceProvider.GetService<AddPublisherViewModel>();
                addViewModel.NameProperty = publisherDTO.Name;
                addViewModel.OldNameProperty = publisherDTO.Name;
                addViewModel.ButtonTextProperty = LangUtils.Translate("AddPublisherButtonTextUpdate");
                MainViewModel.CurrentChildViewProperty = addViewModel;
            }
        }

        private void KeyDownDataGridEventHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                if(DataGrid.SelectedItem != null)
                {
                    if(DataGrid.SelectedItem is ArticleDTO)
                    {
                        App.BookstoreDatabase.DeleteArticle(DataGrid.SelectedItem as ArticleDTO);
                    }
                    else if(DataGrid.SelectedItem is BillDTO)
                    {
                        MessageBox.Show("Bills can't be deleted!");
                    }
                    else if(DataGrid.SelectedItem is PublisherDTO)
                    {
                        App.BookstoreDatabase.DeletePublisher(DataGrid.SelectedItem as PublisherDTO);
                    }
                    else if(DataGrid.SelectedItem is BookDTO)
                    {
                        App.BookstoreDatabase.DeleteBook(DataGrid.SelectedItem as BookDTO);
                    }
                    else if(DataGrid.SelectedItem is AuthorDTO)
                    {
                        App.BookstoreDatabase.DeleteAuthor(DataGrid.SelectedItem as AuthorDTO);
                    }
                }
            }
        }
    }
}
