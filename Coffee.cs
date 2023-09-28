using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    internal class Coffee : Drink
    {
        public Coffee(string name, double price) : base(name, price)
        {

        }
        public override string ToString()
        {
            return base.ToString() + "Coffee for " + Price + " Shekels";
        }

        # region preparation of the drink
        public override string AddingIngredients()
        {
            if (VendingMachine.Cups < 1)
            {
                throw new LackOfResourceException("Out of cups");
            }
            if (VendingMachine.CoffeeBeans < 2)
            {
                throw new LackOfResourceException("Out of CoffeeBeans");
            }
            if (VendingMachine.Sugar < 1)
            {
                throw new LackOfResourceException("Out of Sugar");
            }
            return "Taking cup and Adding CoffeeBeans, Adding sugar\n";
        }
        public override string AddingHotWater()
        {
            return "Adding hot water and milk\n";
        }
        public override string Stirring()
        {
            return "Stirring the Hot Coffee";
        }
        #endregion
    }
}
