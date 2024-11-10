using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.DatabaseModel
{
    public class Bill
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateTimeOfPurchase { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
