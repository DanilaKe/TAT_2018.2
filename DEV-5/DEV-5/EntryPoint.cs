using System;

namespace DEV_5
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
                // Creates objects of the class catalog of cars and passes delegates there.
                var catalogOfCar = new Catalog(printer.AddedCarHandler, printer.CountCarHandler,
                    printer.CountTypeHandler, printer.AverageCarPriceHandler);
                var commandHandler = new CommandHandler(catalogOfCar, printer);
                commandHandler.RunCommandReader();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}