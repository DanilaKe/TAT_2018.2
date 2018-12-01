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
        public static void Main()
        {
            try
            {
                var printer = new Printer();
                // Creates object of the class catalog of cars and passes delegates there.
                var catalogOfCar = new Catalog<Car>(printer.CountMachineHandler,printer.CountTypeHandler,printer.AveragePriceHandler);
                var catalogOfTruck = new Catalog<Truck>(printer.CountMachineHandler,printer.CountTypeHandler,printer.AveragePriceHandler);
                var commandHandler = new CommandHandler(catalogOfCar, catalogOfTruck);
                commandHandler.RunCommandReader();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}