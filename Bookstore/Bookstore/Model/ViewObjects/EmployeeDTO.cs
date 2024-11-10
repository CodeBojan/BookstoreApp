using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.ViewObjects
{
    public class EmployeeDTO
    {
        public string Username { get; set; }
        public string UIN { get; set; }
        public bool IsAdmin { get; set; }
        public List<BillDTO> Bills { get; set; }
    }
}
