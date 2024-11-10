using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.DatabaseModel
{   
    public class BillItem
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ArticleId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public virtual Article Article { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
