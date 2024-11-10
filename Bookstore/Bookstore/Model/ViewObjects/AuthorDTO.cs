using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.ViewObjects
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<BookDTO> Books { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            if(obj is AuthorDTO)
            {
                AuthorDTO other = (AuthorDTO)obj;
                if (other.Name == Name && other.Surname == Surname)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname);
        }
    }
}
