using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DEV_8
{
    /// <summary>
    /// Class CommandHandler
    /// Handles console commands.
    /// </summary>
    public class CommandHandler
    {
        private readonly Catalog<Car> CatalogOfCar;
        private readonly Catalog<Truck> CatalogOfTruck;
        private readonly Printer Printer;
        private List<ICatalogCommand> ListOfCommand;
        
        public CommandHandler(Catalog<Car> catalogOfCar,Catalog<Truck> catalogOfTruck)
        {
            CatalogOfCar = catalogOfCar;
            CatalogOfTruck = catalogOfTruck;
            ListOfCommand = new List<ICatalogCommand>();
        }
        
        /// <summary>
        /// Method RunCommandReader
        /// Starts reading commands.
        /// </summary>
        public void RunCommandReader()
        {
            bool exit = false;
            // The cycle of reading commands, while there is no command "exit".
            while (!exit)
            {
                Console.Write("Write a command : ");
                var command = Console.ReadLine();
                if ("execute" == command)
                {
                    foreach (var i in ListOfCommand)
                    {
                        i.Execute();
                    }
                    continue;
                }
                if ("exit" == command)
                {
                    exit = true;
                    continue;
                }
                // Finds out the type of command.
                AddCommandInList(command);
                // Execute the command, depending ocon the type.
            }
        }

        /// <summary>
        /// Method GetTypeOfCommands
        /// Finds out the type of command.
        /// </summary>
        /// <param name="command">Console command</param>
        /// <returns>Type of command.</returns>
        private void AddCommandInList(string command)
        {
            ICatalogCommand catalogCommand = null;
            var splitCommand = command?.ToLower().Split(' ');

            if ((command == null) || (command == string.Empty) || (2 > splitCommand.Length))
            {
                Console.WriteLine("Invalid command.");
                return;
            }
            Receiver catalog;
            switch (splitCommand[1])
            {
                case "car" :
                    catalog = CatalogOfCar;
                    break;
                case "truck" :
                    catalog = CatalogOfTruck;
                    break;
                default :
                    throw new Exception();
            }
            
            switch (splitCommand[0])
            {
                case "count_all":
                    catalogCommand = new CountAll(catalog);
                    break;
                case "count_types":
                    catalogCommand = new CountType(catalog);
                    break;
                case "average_price":    
                    catalogCommand = new AveragePrice(catalog);
                    break;
                case "average_price_type":    
                    catalogCommand = new AveragePriceType(catalog, splitCommand[2]);
                    break;
            }

            if (catalogCommand != null)
            {
                ListOfCommand.Add(catalogCommand);
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}