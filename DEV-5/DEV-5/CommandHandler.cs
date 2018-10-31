using System;

namespace DEV_5
{
    public class CommandHandler
    {
        private Catalog catalog;
        private ICatalogCommand catalogCommand;
        private readonly Printer printer;
        
        public CommandHandler(Catalog receivedCatalog, Printer receivedPrinter)
        {
            printer = receivedPrinter;
            catalog = receivedCatalog;
        }

        public void RunCommandReader()
        {
            printer.DisplayBeginInfo();
            bool exit = false;
            while (!exit)
            {
                Console.Write("Write a command : ");
                var command = Console.ReadLine().Split(' ');
                TypeOfCommands CommandType = GetTypeOfCommands(command);
                
                // Check for access to an empty catalog.
                if ((CommandType != TypeOfCommands.Add) && (CommandType != TypeOfCommands.None) &&
                    (CommandType != TypeOfCommands.Exit) && (catalog.Counter.Equals(0)))
                {
                    printer.DisplayError("Empty catalog.");
                    continue;
                }
                
                switch (CommandType)
                {
                    case TypeOfCommands.None :
                        printer.DisplayError("Invalid command.");
                        break;
                    case TypeOfCommands.Add :
                        catalogCommand = new Add(catalog,command[1], command[2], Convert.ToInt32(command[3]), Convert.ToDouble(command[4]));
                        break;
                    case TypeOfCommands.CountAll :
                        catalog.Count(this);
                        break;
                    case TypeOfCommands.CountTypes :
                        catalog.Count(this,"type");
                        break;
                    case TypeOfCommands.AveragePriceAll :
                        catalogCommand = new AveragePrice(catalog);
                        break;
                    case TypeOfCommands.AveragePriceType :
                        catalogCommand = new AveragePrice(catalog, command[2]);
                        break;
                    case TypeOfCommands.Exit :
                        exit = true;
                        break;
                }

                if (!exit)
                {
                    catalogCommand.Execute();
                }
            }
        }

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