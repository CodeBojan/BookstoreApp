using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.DatabaseModel
{
    public class Article
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Discriminator { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Amount, Description, Name, Price);
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
