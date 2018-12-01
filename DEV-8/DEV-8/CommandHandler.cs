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
        private readonly Catalog<Car> catalogOfCar;
        private readonly Catalog<Track> catalogOfTrack;
        private readonly Printer printer;
        private ICatalogCommand catalogCommand;
        
        public CommandHandler(Catalog receivedCatalog, Printer receivedPrinter)
        {
            printer = receivedPrinter;
            catalog = receivedCatalog;
        }
        
        /// <summary>
        /// Method RunCommandReader
        /// Starts reading commands.
        /// </summary>
        public void RunCommandReader()
        {
            printer.DisplayBeginInfo();
            bool exit = false;
            // The cycle of reading commands, while there is no command "exit".
            while (!exit)
            {
                Console.Write("Write a command : ");
                var command = Console.ReadLine();
                // Finds out the type of command.
                TypeOfCommands CommandType = GetTypeOfCommands(command);
                var splitCommand = command.Split(' ');
                // Execute the command, depending on the type.
                switch (CommandType)
                {
                    case TypeOfCommands.None :
                        Console.WriteLine("Invalid command.\n");
                        break;
                    case TypeOfCommands.CountAll :
                        catalogCommand = new CountAll(catalog);
                        break;
                    case TypeOfCommands.CountTypes :
                        catalogCommand = new CountType(catalog);
                        break;
                    case TypeOfCommands.AveragePriceAll :
                        catalogCommand = new AveragePrice(catalog);
                        break;
                    case TypeOfCommands.AveragePriceType :
                        catalogCommand = new AveragePriceType(catalog, splitCommand[2]);
                        break;
                    case TypeOfCommands.Exit :
                        exit = true;
                        break;
                }

                if (!exit && (CommandType != TypeOfCommands.None))
                {
                    catalogCommand.Execute();
                }
            }
        }

        /// <summary>
        /// Method GetTypeOfCommands
        /// Finds out the type of command.
        /// </summary>
        /// <param name="command">Console command</param>
        /// <returns>Type of command.</returns>
        private ICommand GetTypeOfCommands(string command)
        {   
            if ((command == null) || (command == string.Empty))
            {
                return null;
            }
            
            switch (command.ToLower())
            {
                case "count all":
                    return TypeOfCommands.CountAll;
                case "count types":
                    return TypeOfCommands.CountTypes;
                case "average price":
                    return TypeOfCommands.AveragePriceAll;
                case command.TakeWhile("average price")
            }

            if (command.ToLower().Contains("average price"))
            {
                return TypeOfCommands.AveragePriceType;
            }
            
            return TypeOfCommands.None;
        }
    }
}