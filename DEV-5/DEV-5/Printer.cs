using System;

namespace DEV_5
{
    public class Printer
    {
        public void DisplayBeginInfo(object CallingClass)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception("An attempt to create an object of the class Car is not in Catalog.");
            }
            
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n-----------------------------------------------------------");
            Console.WriteLine("Write a console command.");
            Console.WriteLine("\t1. add {brand} {model} {number of cars} {price}\t");
            Console.WriteLine("\t2. count types\t4. average price");
            Console.WriteLine("\t3. count all\t5. average price {brand}");
            Console.WriteLine("-----------------------------------------------------------\n");
            Console.ForegroundColor = color;
        }
        
        public void DisplayError(object CallingClass, string error)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception("An attempt to create an object of the class Car is not in Catalog.");
            }
            
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{error}\n");
            Console.ForegroundColor = color;
        }
    }
}