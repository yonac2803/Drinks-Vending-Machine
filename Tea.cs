using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    internal class Tea : Drink
    {
        public Tea(string name, double price) : base(name, price)
        {

        }
        public override string ToString()
        {
            return base.ToString() + "Tea for " + Price + " Shekels";
        }

        # region preparation of the drink
        public override string AddingIngredients()
        {
            if (VendingMachine.Cups < 1)
                throw new LackOfResourceException("Out of cups");
            if (VendingMachine.TeaLeaves < 1)
                throw new LackOfResourceException("Out of Tea Leaves");

            return $"Taking cup and Adding tea leaves\n";
        }
        public override string AddingHotWater()
        {
            return "Adding hot water\n";
        }
        public override string Stirring()
        {
            return "Stirring the Tea";
        }
        #endregion
    }
}
