using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.DatabaseModel
{
    public class Book : Article
    {
        public string ISBN { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public int YearOfIssue { get; set; }
        public int YearOfPublication { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), ISBN, LanguageId, YearOfIssue, YearOfPublication); //TODO: possibly not good?
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            if (obj is Author)
            {
                Author other = (Author)obj;
                if (other.Id == Id)
                    return true;
            }
            return false;
        }
    }
}
