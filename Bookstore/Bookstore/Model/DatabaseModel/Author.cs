using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.DatabaseModel
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Surname);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            if(obj is Author)
            {
                Author other = (Author)obj;
                if (other.Id == Id)
                    return true;
            }
            return false;
        }
    }
}
