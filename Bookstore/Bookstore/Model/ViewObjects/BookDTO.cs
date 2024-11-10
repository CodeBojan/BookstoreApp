using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.ViewObjects
{
    public class BookDTO : ArticleDTO
    {
        public string ISBN { get; set; }
        public string PublisherName { get; set; }
        public string LanguageName { get; set; }
        public int YearOfIssue { get; set; }
        public int YearOfPublication { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
