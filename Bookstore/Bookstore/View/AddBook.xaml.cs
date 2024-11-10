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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : UserControl
    {
        private AddBookViewModel ViewModel;
        public AddBook()
        {
            ViewModel = App.ServiceProvider.GetService<AddBookViewModel>();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void AddBookEventHandler(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedAuthorsProperty = AuthorsListBox.SelectedItems;
        }

        //private void AuthorsSelectionEventHandler(object sender, SelectionChangedEventArgs e)
        //{
        //    if(AuthorsListBox.SelectedItem != null)
        //    {
        //        var selectedItem = AuthorsListBox.SelectedItem as AuthorDTO;
        //        ViewModel.SelectedAuthorsProperty.Add(selectedItem);
        //        AuthorsListBox.SelectedItem = null;
        //    }
        //    else //it is null, then it is deselected
        //    {
        //        var selectedItems = AuthorsListBox.SelectedItems as List<AuthorDTO>;
        //        if (selectedItems == null)
        //        {
        //            ViewModel.SelectedAuthorsProperty.Clear();
        //            return;
        //        }
        //        int i = 0;
        //        for( ; i < ViewModel.SelectedAuthorsProperty.Count; i++)
        //        {
        //            int j = 0;
        //            for ( ; j < selectedItems.Count; j++) 
        //            {
        //                if (ViewModel.SelectedAuthorsProperty[i].Equals(selectedItems[j]))
        //                    break;
        //            }
        //            if(j == selectedItems.Count)
        //            {
        //                ViewModel.SelectedAuthorsProperty.RemoveAt(i);
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
