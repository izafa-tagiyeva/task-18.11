using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper.Exceptions
{
    public class Exceptionss
    {
       

       public class UserNotFoundException : Exception
       {
        public UserNotFoundException(string message) : base(message) { }
        }

        public class ProductNotFoundException : Exception
        {
        public ProductNotFoundException(string message) : base(message) { }
        }

}
}
