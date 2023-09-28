using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    internal class LackOfResourceException : Exception
    {
        public LackOfResourceException() { }
        public LackOfResourceException(string message) : base(message) { }

    }
}
