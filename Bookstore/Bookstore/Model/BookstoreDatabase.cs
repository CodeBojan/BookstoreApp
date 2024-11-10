using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Model.DatabaseModel;
using Bookstore.Model.ViewObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Model
{
    public class BookstoreDatabase
    {
        private BookstoreDbContext Db = new();
        public BookstoreDatabase()
        {
            Db = new BookstoreDbContext();
            Db.Database.EnsureCreated();
        }
        public bool IsEmployeeRegistered(string username)
        {
            var employee = Db.Employees.FirstOrDefault(e => e.Name == username);
            if (employee == null)
                return false;
            return true;
        }

        public void UpdateEmployee(Employee employee)
        {
            employee.Theme = App.CurrentTheme;
            Db.SaveChanges();
        }

        public void DeleteArticle(ArticleDTO articleDTO)
        {
            var article = Db.Articles.FirstOrDefault(a => a.Name == articleDTO.Name);
            Db.Articles.Remove(article);
            Db.SaveChanges();
        }
        public void DeleteBook(BookDTO bookDTO)
        {
            var book = Db.Books.FirstOrDefault(b => b.Name == bookDTO.Name);
            Db.Books.Remove(book);
            Db.SaveChanges();
        }
        public void DeletePublisher(PublisherDTO publisherDTO)
        {
            var publisher = Db.Publishers.FirstOrDefault(p => p.Name == publisherDTO.Name);
            Db.Publishers.Remove(publisher);
            Db.SaveChanges();
        }
        public void DeleteAuthor(AuthorDTO authorDTO)
        {
            var author = Db.Authors.FirstOrDefault(a => a.Name == authorDTO.Name && a.Surname == authorDTO.Surname);
            Db.Authors.Remove(author);
            Db.SaveChanges();
        }

        public void AddBill(BillDTO billDTO)
        {
            
            Bill bill = new()
            {
                DateTimeOfPurchase = billDTO.DateTimeOfPurchase,
                EmployeeId = App.CurrentEmployee.Id,
                Employee = App.CurrentEmployee,
            };
            Db.Bills.Add(bill);
            Db.SaveChanges();
            foreach(var billItemDTO in billDTO.BillItems)
            {
                Article articleTemp = Db.Articles.FirstOrDefault(a => a.Name == billItemDTO.ArticleName);
                BillItem billItem = new()
                {
                    Amount = billItemDTO.Amount,
                    Price = billItemDTO.Price,
                    Article = articleTemp,
                    ArticleId = articleTemp.Id,
                    Bill = bill,
                    BillId = bill.Id
                };
                Db.BillItems.Add(billItem);
                Db.SaveChanges();
            }
        }

        public void AddArticle(string name, string description, double price, int amount)
        {
            Article article = new()
            {
                Name = name,
                Description = description,
                Price = price,
                Amount = amount,
                BillItems = new List<BillItem>()
            };
            Db.Articles.Add(article);
            Db.SaveChanges();
        }

        public Article GetPriceOfArticle(string articleName)
        {
            return Db.Articles.FirstOrDefault(a => a.Name == articleName);
        }

        public void UpdateArticle(string oldName, string name, string description, double price, int amount)
        {
            var article = Db.Articles.FirstOrDefault(a => a.Name == oldName);
            article.Description = description;
            article.Price = price;
            article.Amount = amount;
            article.Name = name;
            Db.SaveChanges();
        }
        public void UpdateBook(string oldName, string title, string ISBN, string description, string publisherName, string language, int yearOfIssue, int yearOfPublication, int amount, double price, IList authors)
        {
            var book = Db.Books.FirstOrDefault(b => b.Name == oldName);
            book.Name = title;
            book.Description = description;
            book.ISBN = ISBN;
            book.Publisher = Db.Publishers.FirstOrDefault(p => p.Name == publisherName);
            book.Language.Name = language;
            book.YearOfIssue = yearOfIssue;
            book.YearOfPublication = yearOfPublication;
            book.Amount = amount;
            book.Price = price;
            List<Author> dbAuthors = new();
            foreach (var temp in authors)
            {
                var author = temp as AuthorDTO;
                dbAuthors.Add(Db.Authors.First(a => a.Name == author.Name && a.Surname == author.Surname));
            }
            book.Authors = dbAuthors;
            Db.SaveChanges();
        }
        public void UpdateAuthor(string oldName, string newName, string newSurname)
        {
            var author = Db.Authors.FirstOrDefault(a => a.Name == oldName);
            author.Name = newName;
            author.Surname = newSurname;
            Db.SaveChanges();
        }

        public void UpdatePublisher(string oldName, string newName)
        {
            var publisher = Db.Publishers.FirstOrDefault(p => p.Name == oldName);
            publisher.Name = newName;
            Db.SaveChanges();
        }

        public void AddPublisher(string name)
        {
            Publisher publisher = new()
            {
                Name = name,
                Books = new List<Book>()
            };
            Db.Publishers.Add(publisher);
            Db.SaveChanges();
        }

        public void AddAuthor(string name, string surname)
        {
            Author author = new Author()
            {
                Name = name,
                Surname = surname,
                Books = new List<Book>()
            };
            Db.Authors.Add(author);
            Db.SaveChanges();
        }

        public bool CheckIfBooksExists(string title)
        {
            var book = Db.Books.FirstOrDefault(b => b.Name == title);
            if (book == null)
                return false;
            return true;
        }

        public List<Article> GetArticles(List<string> articleNames)
        {
            return Db.Articles.Where(a => articleNames.Any(an => an == a.Name)).ToList();
        }

        public List<string> ReadAllArticlesNames()
        {
            List<string> result = new();
            var articles = Db.Articles.Where(a => a.Discriminator == "Book" || a.Discriminator == "Article").ToList();
            foreach(var article in articles)
            {
                if(article.Amount > 0)
                    result.Add(article.Name);
            }
            return result;
        }

        public void AddBook(string title, string ISBN, string description, string publisherName, string Language, int yearOfIssue, int yearOfPublication, int amount, double price, IList authors)
        {
            var publisher = Db.Publishers.FirstOrDefault(p => p.Name == publisherName);
            var language = Db.Languages.FirstOrDefault(l => l.Name == Language);
            List<Author> dbAuthors = new();
            foreach(var temp in authors)
            {
                var author = temp as AuthorDTO;
                dbAuthors.Add(Db.Authors.First(a => a.Name == author.Name && a.Surname == author.Surname));
            }
            Book book = new()
            {
                Name = title,
                ISBN = ISBN,
                Description = description,
                LanguageId = language.Id,
                Language = language,
                YearOfIssue = yearOfIssue,
                Amount = amount,
                Price = price,
                YearOfPublication = yearOfPublication,
                PublisherId = publisher.Id,
                Publisher = publisher,
                Authors = dbAuthors
            };
            Db.Books.Add(book);
            Db.SaveChanges();
        }

        public void AddEmployee(string username, string password, string uin, ThemesEnum theme)
        {
            var hasher = SHA256.Create();
            var hashedPassword = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            var text = Encoding.UTF8.GetString(hashedPassword);
            Employee employee = new Employee()
            {
                Name = username,
                UIN = uin,
                Password = text,
                IsAdmin = false,
                Theme = theme,
                Bills = new List<Bill>()
            };
            Db.Employees.Add(employee);
            Db.SaveChanges();
        }

        public void DeleteEmployee(EmployeeDTO employee)
        {
            Employee toDelete = Db.Employees.Where(e => e.Name == employee.Username).ToList()[0];
            Db.Employees.Remove(toDelete);
            Db.SaveChanges();
        }

        public List<EmployeeDTO> ReadAllEmployees()
        {
            List<EmployeeDTO> employees = new();
            var fromDatabase = Db.Employees.ToList();
            foreach (var employee in fromDatabase)
            {
                employees.Add(new EmployeeDTO()
                {
                    Username = employee.Name,
                    IsAdmin = employee.IsAdmin,
                    UIN = employee.UIN,
                    Bills = TransformBills(employee.Bills)
                });
            }
            return employees;
        } 
        public List<string> ReadAllLanguages()
        {
            List<string> languages = new();
            var fromDatabase = Db.Languages.ToList();
            foreach(var language in fromDatabase)
            {
                languages.Add(language.Name);
                //TODO ASK: include all books with this language as a collection?
            }
            return languages;
        }

        public List<ArticleDTO> ReadAllArticles()
        {
            List<ArticleDTO> articles = new();
            var fromDatabase = Db.Articles.Where(a => a.Discriminator == "Article").ToList();
            foreach(var article in fromDatabase)
            {
                articles.Add(new ArticleDTO()
                {
                    Amount = article.Amount,
                    Description = article.Description,
                    Price = article.Price,
                    Name = article.Name,
                });
            }
            return articles;
        }

        public List<AuthorDTO> ReadAllAuthors()
        {
            List<AuthorDTO> authors = new();
            var fromDatabase = Db.Authors.Include(a => a.Books).ThenInclude(b => b.Language).Include(a => a.Books).ThenInclude(b => b.Publisher).ToList();
            foreach (var author in fromDatabase)
            {
                authors.Add(new AuthorDTO()
                {
                    Name = author.Name,
                    Surname = author.Surname,
                    Books = TransformBooks(author.Books)
                });
            }
            return authors;
        }
        public List<BookDTO> ReadAllBooks()
        {
            List<BookDTO> books = new();
            var fromDatabase = Db.Books.Include(b => b.BillItems).Include(b => b.Authors).Include(b => b.Language).Include(b => b.Publisher).ToList();
            foreach (var book in fromDatabase)
            {
                books.Add(new BookDTO()
                {
                    Amount = book.Amount,
                    Description = book.Description,
                    Price = book.Price,
                    Name = book.Name,
                    ISBN = book.ISBN,
                    PublisherName = book.Publisher.Name,
                    LanguageName = book.Language.Name,
                    YearOfIssue = book.YearOfIssue,
                    YearOfPublication = book.YearOfPublication,
                    Authors = TransformAuthors(book.Authors)
                });
            }
            return books;
        } 

        private List<BookDTO> TransformBooks(ICollection<Book> books)
        {
            List<BookDTO> result = new();
            foreach(var book in books)
            {
                result.Add(new BookDTO()
                {
                    Description = book.Description,
                    Name = book.Name,
                    Price = book.Price,
                    Amount = book.Amount,
                    ISBN = book.ISBN,
                    LanguageName = book.Language.Name,
                    PublisherName = book.Publisher.Name,
                    YearOfIssue = book.YearOfIssue,
                    YearOfPublication = book.YearOfPublication
                });
            }
            return result;
        }

        private List<BillDTO> TransformBills(ICollection<Bill> bills)
        {
            List<BillDTO> result = new();
            if (bills is null)
                return result;
            foreach (var bill in bills)
            {
                result.Add(new BillDTO()
                {
                     DateTimeOfPurchase = bill.DateTimeOfPurchase
                });
            }
            return result;
        }

        private List<AuthorDTO> TransformAuthors(ICollection<Author> authors)
        {
            List<AuthorDTO> result = new();
            if (authors is null)
                return result;
            foreach(var author in authors)
            {
                result.Add(new AuthorDTO()
                {
                    Name = author.Name,
                    Surname = author.Surname
                });
            }
            return result;
        } 
        public List<string> ReadAllPublishers()
        {
            List<string> publishers = new();
            var fromDatabase = Db.Publishers.ToList();
            foreach(var publisher in fromDatabase)
            {
                publishers.Add(publisher.Name);
            }
            return publishers;
        }

        public List<BillDTO> ReadAllBills()
        {
            List<BillDTO> bills = new();
            IQueryable<Bill> fromDatabase;
            if (App.CurrentEmployee.IsAdmin)
                fromDatabase = Db.Bills;
            else
                fromDatabase = Db.Bills.Where(b => b.EmployeeId == App.CurrentEmployee.Id);
            foreach (var bill in fromDatabase)
            {
                bills.Add(new BillDTO()
                {
                    DateTimeOfPurchase = bill.DateTimeOfPurchase
                });
            }
            return bills;
        }
        public Employee GetEmployee(string username)
        {
            return Db.Employees.FirstOrDefault(p => p.Name == username);
        }
        public bool IsEmployeeAuthenticated(string username, string password)
        {
            Employee employee = Db.Employees.FirstOrDefault(p => p.Name == username);
            using SHA256 hasher = SHA256.Create();
            var bytesPassword = Encoding.UTF8.GetBytes(password);
            byte[] hash = hasher.ComputeHash(bytesPassword);
            var text = Encoding.UTF8.GetString(hash);
            if (text == employee.Password)
                return true;
            return false;
        }
    }
}
