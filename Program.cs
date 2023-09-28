using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks_Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine= new VendingMachine();
            Drink d1 = new Coffee("Coffee 1",10.50);
            Drink d2 = new Tea("Tea 1", 9.75);
            Drink d3 = new chocolate("chocolate 1",12.40);
            int exitnum = 0;

            try
            {
                vendingMachine.AddDrink(d1);
                vendingMachine.AddDrink(d2);
                vendingMachine.AddDrink(d3);
            }
            catch (TooManyDrinksException e)
            {
                Console.WriteLine("Exception caught, type: {0}", e.GetType());
                Console.WriteLine(e);
            }
            while (exitnum != 9)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(vendingMachine);
                    Console.ForegroundColor = ConsoleColor.White;


                    Console.WriteLine("Please selcet a drink by entering his number:");
                    int num = int.Parse(Console.ReadLine());


                    Console.ForegroundColor = ConsoleColor.Red;
                    vendingMachine.SelectDrink(num);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Exception caught, type: {0}", e.GetType());
                    Console.WriteLine("The number is not valid.");
                    Console.WriteLine();
                }
                catch (LackOfResourceException e)
                {
                    Console.WriteLine("Exception caught, type: {0}", e.GetType());
                    Console.WriteLine();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Exception caught, type: {0}", e.GetType());
                    Console.WriteLine("The drink is not Avilable.");
                    Console.WriteLine();
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(vendingMachine.Restock());
                    Console.ForegroundColor = ConsoleColor.White;


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you for your purchase!");
                    Console.ForegroundColor= ConsoleColor.White;



                    Console.WriteLine();
                    Console.WriteLine("If you would like to exit enter '9', otherwise enter any other number: ");
                    exitnum = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("GoodBye.");
            Console.ReadLine();
        }
    }
}
