using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    internal class chocolate : Drink
    {
        public chocolate(string name, double price) : base(name, price)
        {

        }
        public override string ToString()
        {
            return base.ToString() + "Hot Chocolate for " + Price + " Shekels";
        }

        #region preparation of the drink
        public override string AddingIngredients()
        {
            if (VendingMachine.Cups < 1)
                throw new LackOfResourceException("Out of cups");
            if (VendingMachine.Cocoa < 1)
                throw new LackOfResourceException("Out of Cocoa");
            if (VendingMachine.Sugar < 1)
                throw new LackOfResourceException("Out of Sugar");
            if (VendingMachine.Milk < 15)
                throw new LackOfResourceException("There isn't enough milk");

            return "Taking cup and Adding cocoa powder, Adding sugar\n";
        }
        public override string AddingHotWater()
        {
            return "Adding hot water and milk\n";
        }
        public override string Stirring()
        {
            return "Stirring the Hot Chocolate";
        }
        #endregion
    }
}
