﻿using System;

namespace DEV_5
{
    public class Printer
    {
        public void AddedCarHandler(object sender, CatalogEventArgs e)
        {    
            DisplayAddCar(e);
        }
        
        public void CountCarHandler(object sender, CatalogEventArgs e)
        {    
            // TODO
        }
        
        public void AverageCarPriceHandler(object sender, CatalogEventArgs e)
        {    
            // TODO
        }
        
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
        
        public void DisplayError(string error)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{error}\n");
            Console.ForegroundColor = color;
        }

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
    }
}