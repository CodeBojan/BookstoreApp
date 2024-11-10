using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.DatabaseModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UIN { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ThemesEnum Theme {get; set;}
        public virtual ICollection<Bill> Bills { get; set; }

    }
}
