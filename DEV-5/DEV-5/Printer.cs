using System;

namespace DEV_5
{
    /// <summary>
    /// Class Printer
    /// Engaged in the correct output to the screen.
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Method AddedCarHandler
        /// The method that handles the event of adding a car.
        /// </summary>
        public void AddedCarHandler(object sender, CatalogEventArgs e)
        {    
            DisplayAddCar(e);
        }
        
        /// <summary>
        /// Method CountCarHandler
        /// A method that handles a car counting event.
        /// </summary>
        public void CountCarHandler(object sender, CatalogEventArgs e)
        {    
            DisplayCountCar(e);
        }
        
        /// <summary>
        /// Method AverageCarPriceHandler
        /// The method that handles the event of calculating the average price of cars.
        /// </summary>
        public void AverageCarPriceHandler(object sender, CatalogEventArgs e)
        {    
            DisplayAverageCost(e);
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
            Console.WriteLine("\t1. add {brand} {model} {number of cars} {price}\t");
            Console.WriteLine("\t2. count types\t4. average price");
            Console.WriteLine("\t3. count all\t5. average price {brand}");
            Console.WriteLine("-----------------------------------------------------------\n");
            Console.ForegroundColor = color;
        }
        
        /// <summary>
        /// Method DisplayError
        /// Displays errors associated with incorrect input.
        /// </summary>
        public void DisplayError(string error)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{error}\n");
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Method DisplayAddCar
        /// Displays information about the added car.
        /// </summary>
        private void DisplayAddCar(CatalogEventArgs e)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Added car in the catalog. (ID : {e.Count})");
            Console.WriteLine($"Brand : {e.Brand}");
            Console.WriteLine($"Model : {e.Model}");
            Console.WriteLine($"Number of cars : {e.NumberOfCars}");
            Console.WriteLine($"Price : {e.Price}\n");
            Console.ForegroundColor = color;
        }
        
        /// <summary>
        /// Method DisplayCountCar
        /// Displays information about the counting of cars.
        /// </summary>
        private void DisplayCountCar(CatalogEventArgs e)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (e.ThisIsCountTypes)
            {
                Console.WriteLine($"Number of car brands : {e.NumberOfCars}\n");
            }
            else
            {
                Console.WriteLine($"Total number of cars : {e.NumberOfCars}\n");
            }
            Console.ForegroundColor = color;
        }
        
        /// <summary>
        /// Method DisplayAverageCost
        /// Displays information on the calculation of the average price of cars.
        /// </summary>
        private void DisplayAverageCost(CatalogEventArgs e)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (e.Brand == string.Empty)
            {
                Console.WriteLine($"Average cost of the car : {e.Price}\n");
            }
            else
            {
                Console.WriteLine($"Average cost of {e.Brand} cars : {e.Price}\n");
            }
            Console.ForegroundColor = color;
        }
    }
}