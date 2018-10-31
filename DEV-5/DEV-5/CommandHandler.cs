using System;

namespace DEV_5
{
    public class CommandHandler
    {
        private Catalog catalog;
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
        
        public CommandHandler()
        {
            // TODO
        }

        public void RunCommandReader()
        {
            bool exit = false;
            while (!exit)
            {
                var command = Console.ReadLine().Split(' ');
                TypeOfCommands CommandType = GetTypeOfCommands(command);
                switch (CommandType)
                {
                    case TypeOfCommands.None :
                        Console.WriteLine("Invalid command.");
                        break;
                    case TypeOfCommands.Add :
                        if (catalog == null)
                        {
                            catalog = new Catalog(AddedCarHandler);
                        }
                        catalog.AddCar(command[0], command[1], Convert.ToInt32(command[2]), Convert.ToInt32(command[3]));
                        break;
                    case TypeOfCommands.CountAll :
                        break;
                    case TypeOfCommands.CountTypes :
                        break;
                    case TypeOfCommands.AveragePriceAll:
                        break;
                    case TypeOfCommands.AveragePriceType :
                        break;
                    case TypeOfCommands.Exit :
                        exit = true;
                        break;
                        
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
            
            if ((command.Length == 4) && (int.TryParse(command[2], out var numberOfCars)) && (int.TryParse(command[3], out var price)))
            {
                return TypeOfCommands.Add;
            }
            else
            {
                return TypeOfCommands.None;
            }
        }
        
        private static void AddedCarHandler(object sender, CatalogEventArgs e)
        {    
            Console.WriteLine(e.Message);
        }
    }
}