using System;
using System.Collections.Generic;

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
        private readonly List<ICatalogCommand> ListOfCommand;
        
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
        /// Method AddCommandInList
        /// Add command in actual list.
        /// </summary>
        /// <param name="command">Console command</param>
        private void AddCommandInList(string command)
        {
            ICatalogCommand catalogCommand = null;
            var splitCommand = command?.ToLower().Split(' ');

            if ((command == null) || (command == string.Empty) || (2 > splitCommand.Length))
            {
                Console.WriteLine("Invalid command.");
                return;
            }
            IReceiver Catalog;
            switch (splitCommand[1])
            {
                case "car" :
                    Catalog = CatalogOfCar;
                    break;
                case "truck" :
                    Catalog = CatalogOfTruck;
                    break;
                default :
                    throw new Exception();
            }
            
            switch (splitCommand[0])
            {
                case "count_all":
                    catalogCommand = new CountAllCommand(Catalog);
                    break;
                case "count_types":
                    catalogCommand = new CountTypeCommand(Catalog);
                    break;
                case "average_price":    
                    catalogCommand = new AveragePriceCommand(Catalog);
                    break;
                case "average_price_type":    
                    catalogCommand = new AveragePriceTypeCommand(Catalog, splitCommand[2]);
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