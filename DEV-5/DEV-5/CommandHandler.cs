using System;

namespace DEV_5
{
    /// <summary>
    /// Class CommandHandler
    /// Handles console commands.
    /// </summary>
    public class CommandHandler
    {
        private readonly Catalog catalog;
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
                var command = Console.ReadLine().Split(' ');
                // Finds out the type of command.
                TypeOfCommands CommandType = GetTypeOfCommands(command);
                
                // Check for access to an empty catalog.
                if ((CommandType != TypeOfCommands.Add) && (CommandType != TypeOfCommands.None) &&
                    (CommandType != TypeOfCommands.Exit) && (catalog.Counter == 0))
                {
                    Console.WriteLine("Empty catalog.\n");
                    continue;
                }
                
                // Execute the command, depending on the type.
                switch (CommandType)
                {
                    case TypeOfCommands.None :
                        Console.WriteLine("Invalid command.\n");
                        break;
                    case TypeOfCommands.Add :
                        catalogCommand = new Add(catalog,command[1], command[2], Convert.ToInt32(command[3]), Convert.ToDouble(command[4]));
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
                        catalogCommand = new AveragePriceType(catalog, command[2]);
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
        private TypeOfCommands GetTypeOfCommands(string[] command)
        {   
            if ((command == null) || (command[0] == string.Empty))
            {
                return TypeOfCommands.None;
            }
            
            if (command[0].ToLower() == "exit")
            {
                return TypeOfCommands.Exit;
            }
            
            if ((command.Length == 2) && ($"{command[0]} {command[1]}".ToLower()  == "count types"))
            {
                return TypeOfCommands.CountTypes;
            }
            
            if ((command.Length == 2) && ($"{command[0]} {command[1]}".ToLower()  == "count all"))
            {
                return TypeOfCommands.CountAll;
            }
            
            if ((command.Length >= 2) && ($"{command[0]} {command[1]}".ToLower()  == "average price"))
            {
                if (command.Length == 3)
                {
                    return TypeOfCommands.AveragePriceType;
                }
                else
                {
                    return TypeOfCommands.AveragePriceAll;
                }
            }
            
            if ((command[0] == "add") && (command.Length == 5) && 
                (int.TryParse(command[3], out var numberOfCars)) &&
                (double.TryParse(command[4], out var price)))
            {
                return TypeOfCommands.Add;
            }
            else
            {
                return TypeOfCommands.None;
            }
        }
        
        enum TypeOfCommands
        {
            None,
            Add,
            CountAll,
            CountTypes,
            AveragePriceAll,
            AveragePriceType,
            Exit
        }
    }
}