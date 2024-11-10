using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Model.DatabaseModel;
using System.Windows.Input;
using Bookstore.Model.ViewObjects;
using System.Windows;
using Haley.Utils;

namespace Bookstore.ViewModel
{
    public class PurchaseViewModel : ViewModelBase
    {
        private List<BillItemDTO> BillItems;
        private DateTime DateOfPurchase;
        public ICommand AddBillItemCommand { get; }
        public ICommand AddBillCommand { get; }
        private string ArticleName;
        private double Price;
        private int Amount;
        private List<string> Articles;
        public PurchaseViewModel()
        {
            AddBillCommand = new ViewModelCommand(ExecuteAddBillCommand);
            AddBillItemCommand = new ViewModelCommand(ExecuteAddBillItemCommand);
            ArticlesProperty = App.BookstoreDatabase.ReadAllArticlesNames();
            BillItems = new();
        }

        private void ExecuteAddBillCommand(object obj)
        {
            if (BillItemsProperty.Count == 0)
                return;
            BillDTO bill = new()
            {
                DateTimeOfPurchase = DateOfPurchaseProperty,
                BillItems = BillItems
            };
            DateOfPurchaseProperty = DateTime.Now;
            var articles = App.BookstoreDatabase.GetArticles(Articles);
            foreach(var article in articles) 
            {
                foreach(var billItem in bill.BillItems)
                {
                    if(article.Name == billItem.ArticleName)
                    {
                        if(article.Amount <= billItem.Amount)
                        {
                            MessageBox.Show(LangUtils.Translate("PurchaseAmountError"));
                        }
                    }
                }
                
            } 
            App.BookstoreDatabase.AddBill(bill);
        }

        private void ExecuteAddBillItemCommand(object obj)
        {
            BillItemsProperty.Add(new BillItemDTO()
            {
                Amount = AmountProperty,
                Price = PriceProperty,
                ArticleName = ArticleNameProperty
            });
            var list = new List<BillItemDTO>(BillItemsProperty);
            BillItemsProperty = list;
            AmountProperty = 0;
            PriceProperty = 0;
            ArticleNameProperty = null;
        }

        public List<string> ArticlesProperty
        {
            get
            {
                return Articles;
            }
            set
            {
                Articles = value;
                OnPropertyChanged(nameof(ArticlesProperty));
            }
        }

        public List<BillItemDTO> BillItemsProperty
        {
            get
            {
                return BillItems;
            }
            set
            {
                BillItems = value;
                OnPropertyChanged(nameof(BillItemsProperty));
            }
        }

        public double PriceProperty
        {
            get
            {
                return Price;
            }
            set
            {
                Price = value;
                OnPropertyChanged(nameof(PriceProperty));
            }
        }

        public int AmountProperty
        {
            get
            {
                return Amount;
            }
            set
            {
                Amount = value;
                OnPropertyChanged(nameof(AmountProperty));
                if (ArticleName != null)
                {
                    PriceProperty = App.BookstoreDatabase.GetPriceOfArticle(ArticleName).Price * Amount; //automatically setting the price
                }
            }
        }

        public string ArticleNameProperty
        {
            get
            {
                return ArticleName;
            }
            set
            {
                ArticleName = value;
                OnPropertyChanged(nameof(ArticleNameProperty));
            }
        }

        public DateTime DateOfPurchaseProperty
        {
            get
            {
                return DateOfPurchase;
            }
            set
            {
                DateOfPurchase = value;
                OnPropertyChanged(nameof(DateOfPurchaseProperty));
            }
        }
    }
}
