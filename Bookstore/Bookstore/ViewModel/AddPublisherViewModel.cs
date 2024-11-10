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
    public class AddPublisherViewModel : ViewModelBase
    {
        public ICommand AddPublisherCommand { get; }
        private string Name;
        private string ButtonText;
        private string OldName;

        public AddPublisherViewModel()
        {
            AddPublisherCommand = new ViewModelCommand(ExecuteAddPublisherCommand);
            ButtonTextProperty = LangUtils.Translate("AddPublisherButtonTextAdd");
        }

        private void ExecuteAddPublisherCommand(object obj)
        {
            if (ButtonTextProperty == LangUtils.Translate("AddPublisherButtonTextAdd"))
            {
                App.BookstoreDatabase.AddPublisher(NameProperty);
                MessageBox.Show(LangUtils.Translate("AddPublisherInfoAdd"));
            }
            else
            {
                App.BookstoreDatabase.UpdatePublisher(OldNameProperty, NameProperty);
                MessageBox.Show(LangUtils.Translate("AddPublisherInfoUpdate"));
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
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
