using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.ViewObjects
{
    public class BillDTO
    {
        public DateTime DateTimeOfPurchase { get; set; }
        public List<BillItemDTO> BillItems { get; set; }
    }
}
