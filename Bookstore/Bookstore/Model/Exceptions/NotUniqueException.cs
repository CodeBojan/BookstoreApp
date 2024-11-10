using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.Exceptions
{
    public class NotUniqueException : Exception
    {
        public NotUniqueException() : base()
        {

        }

        public NotUniqueException(string message) : base(message)
        {

        }
    }
}
