using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    internal class VendingMachine
    {
        Drink[] drinks;
        int _countDrinks = 0;
        bool _active = false;
        #region Static variables for Ingredients and theirs properties
        private static int _cups = 10;
        private static int _cupsOfMilk = 100;
        private static int _sugar = 20;
        private static int _coffeeBeans = 20;
        private static int _teaLeaves = 20;
        private static int _cocoa = 20;

        public static int Sugar { get { return _sugar; } }
        public static int Cups { get { return _cups; } }
        public static int Milk { get { return _cupsOfMilk; } }
        public static int CoffeeBeans { get { return _coffeeBeans; } }
        public static int TeaLeaves { get { return _teaLeaves; } }
        public static int Cocoa { get { return _cocoa; } }
        #endregion

        public VendingMachine(int size = 10)
        {
            drinks = new Drink[size];
        }

        #region Methods of the Vanding Machine
        public void AddDrink(Drink drink)
        {
            if (_countDrinks < drinks.Length)
            {
                drinks[_countDrinks] = drink;
                _countDrinks++;
            }
            else
            {
                throw new TooManyDrinksException("Vending machine is full");
            }
        }
        public void RemoveDrink(Drink drink)
        {
            for (int i = 0; i < _countDrinks; i++)
            {
                if (drinks[i] == drink)
                {
                    for (int j = i; j < _countDrinks - 1; j++)
                    {
                        drinks[j] = drinks[j + 1];
                    }
                    drinks[_countDrinks - 1] = null;
                    _countDrinks--;
                    return;
                }
            }
        }
        public Drink this[int index]
        {
            get
            {
                if (index < 0 || index > _countDrinks)
                {
                    throw new ArgumentOutOfRangeException("index not valid");
                }
                return drinks[index];
            }
        }
        public void SelectDrink(int num)
        {
            if (num >= _countDrinks || num < 0)
            {
                throw new ArgumentException();
            }
            UseIngredient(drinks[num]);
            Console.WriteLine(drinks[num].Prepare());
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("The Vending Machine Options:\n");
            for (int i = 0; i < _countDrinks; i++)
            {
                sb.AppendLine($"{i} - {drinks[i].ToString()}");
            }
            return sb.ToString();
        }
        public string Restock()
        {
            StringBuilder restock = new StringBuilder();
                
            if (_cups < 3) { _cups += 10; _active = true; }
            if (_cupsOfMilk < 10){ _cupsOfMilk += 200; _active = true; }
            if (_sugar < 3) { _sugar += 10; _active = true; }
            if (_coffeeBeans < 3) { _coffeeBeans += 10; _active = true; }
            if (_teaLeaves < 3){ _teaLeaves += 10; _active = true; }
            if (_cocoa< 3){ _cocoa += 10; _active = true;}
            if (_active)
            {
                restock.AppendLine("We noticed that materials are missing from the machine - Here's a restock");
                restock.AppendLine($"Cups: {_cups}");
                restock.AppendLine($"Milk: {_cupsOfMilk}");
                restock.AppendLine($"Sugar: {_sugar}");
                restock.AppendLine($"CoffeeBeans: {_coffeeBeans}");
                restock.AppendLine($"Tea Leaves:{_teaLeaves}");
                restock.AppendLine($"Cocoa: {_cocoa}");
            }
            _active = false;
            return restock.ToString();
        }
        public void UseIngredient(Drink drink)
        {
            if (drink is Coffee)
            {
                _cups--;
                _coffeeBeans --;
                _sugar --;
                _cupsOfMilk -= 15;
            }
            if (drink is Tea)
            {
                _cups--;
                _teaLeaves--;
            }
            if (drink is chocolate)
            {
                _cups--;
                _cocoa--;
                _sugar--;
                _cupsOfMilk -= 20;
            }
        }
        #endregion
    }
}
