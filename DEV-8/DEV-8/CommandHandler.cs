using System;
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
        private ICatalogCommand CatalogCommand;
        
        public CommandHandler(Catalog<Car> catalogOfCar,Catalog<Truck> catalogOfTruck)
        {
            CatalogOfCar = catalogOfCar;
            CatalogOfTruck = catalogOfTruck;
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
                // Finds out the type of command.
                ICatalogCommand CommandType = GetTypeOfCommands(command);
                // Execute the command, depending on the type.
            }
        }

        /// <summary>
        /// Method GetTypeOfCommands
        /// Finds out the type of command.
        /// </summary>
        /// <param name="command">Console command</param>
        /// <returns>Type of command.</returns>
        private ICatalogCommand GetTypeOfCommands(string command)
        {   
            if ((command == null) || (command == string.Empty))
            {
                return null;
            }

            var splitCommand = command.ToLower().Split(' ');

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
                    return new CountAll(catalog);
                case "count_types":
                    return new CountType(catalog);
                case "average_price":    
                    return new AveragePrice(catalog);
                case "average_price_type":    
                    return new AveragePriceType(catalog, splitCommand[2]);
            }
            
            return null;
        }
    }
}