using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks_Vending_Machine
{
    public abstract class Drink
    {
        #region Fields & Properties
        private string _name;
        private double _price;
        public string Name { get { return _name; } set { _name = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        #endregion

        public Drink(string name, double price)
        {
            _name = name;
            _price = price;
        }

        #region Override Methods
        public override string ToString()
        {
            return "Drink: ";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Drink otherDrink = (Drink)obj;
            return _name == otherDrink._name && _price == otherDrink._price;
        }
        #endregion

        #region preparation of the drink
        public abstract string AddingIngredients();
        public abstract string AddingHotWater();
        public abstract string Stirring();
        public string Prepare()
        {
            string prepare = AddingIngredients() + AddingHotWater() + Stirring() + "\n";
            return prepare;
        }
        #endregion
    }
}
