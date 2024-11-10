using Bookstore.Model.ViewObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Haley.Utils;

namespace Bookstore.ViewModel
{
    public class AddBookViewModel : ViewModelBase
    {
        public ICommand AddBookCommand { get; }
        private string Name;
        private string OldName;
        private string ISBN;
        private string Description;
        private string PublisherName;
        private string Language;
        private int YearOfIssue = DateTime.Now.Year;
        private int YearOfPublication = DateTime.Now.Year;
        private int Amount = 1;
        private double Price = 0;
        private List<string> Languages;
        private List<AuthorDTO> Authors;
        private IList SelectedAuthors;
        private List<string> Publishers;
        private string ButtonText;

        public AddBookViewModel()
        {
            AddBookCommand = new ViewModelCommand(ExecuteAddBookCommand);
            AuthorsProperty = App.BookstoreDatabase.ReadAllAuthors();
            LanguagesProperty = App.BookstoreDatabase.ReadAllLanguages();
            PublishersProperty = App.BookstoreDatabase.ReadAllPublishers();
            ButtonTextProperty = LangUtils.Translate("AddBookButtonTextAdd");
        }

        private void ExecuteAddBookCommand(object obj)
        {
            if (ButtonTextProperty == LangUtils.Translate("AddBookButtonTextAdd"))
            {
                if (App.BookstoreDatabase.CheckIfBooksExists(Name))
                {
                    MessageBox.Show(LangUtils.Translate("AddBookExistenceWarning"));
                    return;
                }
                App.BookstoreDatabase.AddBook(Name, ISBN, Description, PublisherName, Language, YearOfIssue, YearOfPublication, Amount, Price, SelectedAuthors);
                MessageBox.Show(LangUtils.Translate("AddBookInfoAdd"));
            }
            else
            {
                App.BookstoreDatabase.UpdateBook(OldNameProperty, NameProperty, ISBNProperty, DescriptionProperty, PublisherNameProperty, LanguageProperty, YearOfIssueProperty, YearOfPublicationProperty, AmountProperty, PriceProperty, AuthorsProperty);
                MessageBox.Show(LangUtils.Translate("AddBookInfoUpdate"));
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

        public List<string> PublishersProperty
        {
            get
            {
                return Publishers;
            }
            set
            {
                Publishers = value;
                OnPropertyChanged(nameof(PublishersProperty));
            }
        }

        public IList SelectedAuthorsProperty
        {
            get
            {
                return SelectedAuthors;
            }
            set
            {
                SelectedAuthors = value;
                OnPropertyChanged(nameof(SelectedAuthorsProperty));
            }
        }

        public List<AuthorDTO> AuthorsProperty
        {
            get
            {
                return Authors;
            }
            set
            {
                Authors = value;
                OnPropertyChanged(nameof(AuthorsProperty));
            }
        }

        public List<string> LanguagesProperty
        {
            get
            {
                return Languages;
            }
            set
            {
                Languages = value;
                OnPropertyChanged(nameof(LanguagesProperty));
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
        public string ISBNProperty
        {
            get
            {
                return ISBN;
            }
            set
            {
                ISBN= value;
                OnPropertyChanged(nameof(ISBNProperty));
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
        public string PublisherNameProperty
        {
            get
            {
                return PublisherName;
            }
            set
            {
                PublisherName = value;
                OnPropertyChanged(nameof(PublisherNameProperty));
            }
        }
        public string LanguageProperty
        {
            get
            {
                return Language;
            }
            set
            {
                Language = value;
                OnPropertyChanged(nameof(LanguageProperty));
            }
        }
        public int YearOfIssueProperty
        {
            get
            {
                return YearOfIssue;
            }
            set
            {
                YearOfIssue = value;
                OnPropertyChanged(nameof(YearOfIssueProperty));
            }
        }
        public int YearOfPublicationProperty
        {
            get
            {
                return YearOfPublication;
            }
            set
            {
                YearOfPublication = value;
                OnPropertyChanged(nameof(YearOfPublicationProperty));
            }
        }

    }
}
