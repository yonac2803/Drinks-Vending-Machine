using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    internal class TooManyDrinksException : Exception
    {
        public TooManyDrinksException() { }
        public TooManyDrinksException(string message) : base(message) { }

       
    }
}
