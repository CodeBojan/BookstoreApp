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
    /// Interaction logic for Purchase.xaml
    /// </summary>

    public partial class Purchase : UserControl
    {
        private PurchaseViewModel ViewModel;
        public Purchase()
        {
            ViewModel = App.ServiceProvider.GetService<PurchaseViewModel>();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void BillItemsListBoxKeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                if(BillItemsListBox.SelectedItem is not null)
                {
                    ViewModel.BillItemsProperty.Remove(BillItemsListBox.SelectedItem as BillItemDTO);
                    var list = new List<BillItemDTO>(ViewModel.BillItemsProperty);
                    ViewModel.BillItemsProperty = list;
                }
            }
        }
    }
}
