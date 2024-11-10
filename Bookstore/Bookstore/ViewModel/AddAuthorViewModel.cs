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
    public class AddAuthorViewModel : ViewModelBase
    {
        public ICommand AddAuthorCommand { get; }

        private string Name;
        private string Surname;
        private string ButtonText;
        private string OldName;
        private string OldSurname;

        public AddAuthorViewModel()
        {
            AddAuthorCommand = new ViewModelCommand(ExecuteAddAuthorCommand);
            ButtonTextProperty = LangUtils.Translate("AddAuthorButtonTextAdd");
        }

        private void ExecuteAddAuthorCommand(object obj)
        {
            if (ButtonTextProperty == LangUtils.Translate("AddAuthorButtonTextAdd"))
            {
                App.BookstoreDatabase.AddAuthor(NameProperty, SurnameProperty);
                MessageBox.Show(LangUtils.Translate("AddAuthorInfoAdd"));
            }
            else
            {
                App.BookstoreDatabase.UpdateAuthor(OldNameProperty, NameProperty, SurnameProperty);
                MessageBox.Show(LangUtils.Translate("AddAuthorInfoUpdate"));
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
        public string OldSurnameProperty
        {
            get
            {
                return OldSurname;
            }
            set
            {
                OldSurname = value;
                OnPropertyChanged(nameof(OldSurnameProperty));
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
        public string SurnameProperty
        {
            get
            {
                return Surname;
            }
            set
            {
                Surname = value;
                OnPropertyChanged(nameof(SurnameProperty));
            }
        }
    }
}
