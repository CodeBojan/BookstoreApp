using Haley.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bookstore.ViewModel
{
    public class AddArticleViewModel : ViewModelBase
    {
        public ICommand AddArticleCommand { get; }
        private string Name;
        private string OldName;
        private string Description;
        private double Price;
        private int Amount;
        private string ButtonText;

        public AddArticleViewModel()
        { 
            AddArticleCommand = new ViewModelCommand(ExecuteAddArticleCommand);
            ButtonTextProperty = LangUtils.Translate("AddArticleButtonTextAdd");
        }

        private void ExecuteAddArticleCommand(object obj)
        {
            if (ButtonTextProperty == LangUtils.Translate("AddArticleButtonTextAdd"))
            {
                App.BookstoreDatabase.AddArticle(Name, Description, PriceProperty, AmountProperty);
                MessageBox.Show(LangUtils.Translate("AddArticleInfoAdd"));
            }
            else
            {
                App.BookstoreDatabase.UpdateArticle(OldName, Name, Description, PriceProperty, AmountProperty);
                MessageBox.Show(LangUtils.Translate("AddArticleInfoUpdate"));
            }
        }
        public string OldNameProperty
        {
            get
            {
                return OldName;
            }
            set
            {
                OldName = value;
                OnPropertyChanged(nameof(OldNameProperty));
            }
        }

        public string ButtonTextProperty
        {
            get
            {
                return ButtonText;
            }
            set
            {
                ButtonText = value;
                OnPropertyChanged(nameof(ButtonTextProperty));  
            }
        }

        public string NameProperty
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                OnPropertyChanged(nameof(NameProperty));
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
        public string DescriptionProperty
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
                OnPropertyChanged(nameof(DescriptionProperty));
            }
        }
    }
}
