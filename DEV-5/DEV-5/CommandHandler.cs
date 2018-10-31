using System;

namespace DEV_5
{
    public class CommandHandler
    {
        private Catalog catalog;
        
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
                
                // Check for access to an empty catalog.
                if ((CommandType != TypeOfCommands.Add) && (catalog == null))
                {
                    Console.WriteLine("Empty catalog.");
                    continue;
                }
                
                switch (CommandType)
                {
                    case TypeOfCommands.None :
                        Console.WriteLine("Invalid command.");
                        break;
                    case TypeOfCommands.Add :
                        if (catalog == null)
                        {
                            catalog = new Catalog(AddedCarHandler, CountCarHandler, AverageCarPriceHandler);
                        }
                        catalog.AddCar(command[1], command[2], Convert.ToInt32(command[3]), Convert.ToInt32(command[4]));
                        break;
                    case TypeOfCommands.CountAll :
                        catalog.Count(this);
                        break;
                    case TypeOfCommands.CountTypes :
                        catalog.Count(this,"type");
                        break;
                    case TypeOfCommands.AveragePriceAll :
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
            
            if ((command[0] == "add") && (command.Length == 5) && 
                (int.TryParse(command[3], out var numberOfCars)) &&
                (int.TryParse(command[4], out var price)))
            {
                return TypeOfCommands.Add;
            }
            else
            {
                return TypeOfCommands.None;
            }
        }
        
        private void AddedCarHandler(object sender, CatalogEventArgs e)
        {    
            Console.WriteLine(e.Message);
        }
        
        private void CountCarHandler(object sender, CatalogEventArgs e)
        {    
            Console.WriteLine(e.Message);
        }
        
        private void AverageCarPriceHandler(object sender, CatalogEventArgs e)
        {    
            Console.WriteLine(e.Message);
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