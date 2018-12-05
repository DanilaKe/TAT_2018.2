using System;

namespace DEV_8
{
    /// <summary>
    /// Class Printer
    /// Engaged in the correct output to the screen.
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Method CountCarHandler
        /// A method that handles a car counting event.
        /// </summary>
        public void CountMachineHandler(object sender, CatalogEventArgs e)
        {    
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{sender.GetType()}\n");
            Console.WriteLine($"Total number of machine : {(int)e.ResultOfOperation}\n");
            Console.ForegroundColor = color;
        }
        
        /// <summary>
        /// Method CountTypeHandler
        /// A method that handles a car counting type event.
        /// </summary>
        public void CountTypeHandler(object sender, CatalogEventArgs e)
        {    
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Number of brands : {(int)e.ResultOfOperation}\n");
            Console.ForegroundColor = color;
        }
        
        /// <summary>
        /// Method AverageCarPriceHandler
        /// The method that handles the event of calculating the average price of cars.
        /// </summary>
        public void AveragePriceHandler(object sender, CatalogEventArgs e)
        {    
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Average cost of the machine : {e.ResultOfOperation}\n");
            Console.ForegroundColor = color;
        }
        
        /// <summary>
        /// Method DisplayBeginInfo
        /// Displays begin information about existing console commands.
        /// </summary>
        public void DisplayBeginInfo()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n-----------------------------------------------------------");
            Console.WriteLine("Write a console command.");
            Console.WriteLine("\t1. count_types [car/truck]\t3. average_price [car/truck]");
            Console.WriteLine("\t2. count_all [car/truck]\t4. average_price_type [car/truck] [type]");
            Console.WriteLine("-----------------------------------------------------------\n");
            Console.ForegroundColor = color;
        }
    }
}