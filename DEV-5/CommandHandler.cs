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
                var command = Console.ReadLine();
                // Finds out the type of command.
                TypeOfCommands CommandType = GetTypeOfCommands(command);
                
                // Check for access to an empty catalog.
                if ((CommandType != TypeOfCommands.Add) && (CommandType != TypeOfCommands.None) &&
                    (CommandType != TypeOfCommands.Exit) && (catalog.Counter == 0))
                {
                    Console.WriteLine("Empty catalog.\n");
                    continue;
                }
                var splitCommand = command.Split(' ');
                // Execute the command, depending on the type.
                switch (CommandType)
                {
                    case TypeOfCommands.None :
                        Console.WriteLine("Invalid command.\n");
                        break;
                    case TypeOfCommands.Add :
                        catalogCommand = new Add(catalog,splitCommand[1], splitCommand[2],
                            int.Parse(splitCommand[3]), int.Parse(splitCommand[4]));
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
        private TypeOfCommands GetTypeOfCommands(string command)
        {   
            if ((command == null) || (command == string.Empty))
            {
                return TypeOfCommands.None;
            }
            
            var splitCommand = command.Split(' ');
            
            if (command.ToLower() == "exit")
            {
                return TypeOfCommands.Exit;
            }
            
            if (command.ToLower()  == "count types")
            {
                return TypeOfCommands.CountTypes;
            }
            
            if (command.ToLower()  == "count all")
            {
                return TypeOfCommands.CountAll;
            }
            
            if (command.ToLower() == "average price")
            {
                return TypeOfCommands.AveragePriceAll;
            }

            if (command.ToLower().Contains("average price") && (splitCommand.Length == 3) )
            {
                return TypeOfCommands.AveragePriceType;
            }
            
            if ((splitCommand[0] == "add") && (splitCommand.Length == 5) && 
                (int.TryParse(splitCommand[3], out var numberOfCars)) &&
                (double.TryParse(splitCommand[4], out var price)))
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