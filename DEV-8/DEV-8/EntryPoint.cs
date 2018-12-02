using System;

namespace DEV_8
{
    /// <summary>
    /// Class Entry point
    /// Entry point.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Creates class objects for display on the screen and
        /// the catalog of cars, then starts reading console commands.
        /// </summary>
        public static void Main(string[] args)
        {
            try
            {
                var parser = new XmlParser(args[0]);
                var printer = new Printer();
                // Creates object of the class catalog of cars and passes delegates there.
                var catalogOfCar = Catalog<Car>.getInstance(printer.CountMachineHandler,printer.CountTypeHandler,printer.AveragePriceHandler);
                Catalog<Car>.getInstance().Add(parser.parseInListOfCars());
                
                var catalogOfTruck = Catalog<Truck>.getInstance(printer.CountMachineHandler,printer.CountTypeHandler,printer.AveragePriceHandler);
                Catalog<Truck>.getInstance().Add(parser.parseInListOfTrucks());
                
                var commandHandler = new CommandHandler(catalogOfCar, catalogOfTruck);
                printer.DisplayBeginInfo();
                commandHandler.RunCommandReader();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}